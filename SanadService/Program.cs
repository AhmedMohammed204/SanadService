using AI_Layer.AI_Models.Gemini;
using AI_Layer.Interfaces;
using Core_Layer.Services.Concrete.Services;
using Core_Layer.Services.Interfaces;
using Data.Models;
using ExternalAuthentication.Concrete;
using ExternalAuthentication.Interfaces;
using ExternalAuthentication.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SanadService.Authorization;
using SanadService.Exceptions;
using SanadService.Jwt;
using Scalar.AspNetCore;
using System.Management;
using System.Net;
using System.Text;

#region init builder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

#endregion


#region Jwt Config

var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey)),
            RequireExpirationTime = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });



builder.Services.AddControllers(options =>
{
    options.Filters.Add<PermissionBasedAuthorizationFilters>();
});
#endregion


builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
               builder.Configuration.GetConnectionString("MyConnection")
               ));

builder.Services.AddHttpClient();
builder.Services.Configure<GeminiSettings>(builder.Configuration.GetSection("GeminiApi"));
builder.Services.AddScoped<IGenerativeAI>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<GeminiSettings>>().Value;
    return new Gemini(settings.ApiKey);
});

builder.Services.AddScoped<IQuizService, QuizService>();




builder.Services.Configure<GoogleAuthSettings>(
    builder.Configuration.GetSection("Authentication:Google"));
builder.Services.AddScoped<IExternalAuthProvider, GoogleAuthService>();
builder.Services.AddScoped<IExternalAuthProviderFactory, ExternalAuthProviderFactory>();


#region init app
var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.MapOpenApi();
    app.MapScalarApiReference();
    
//}


// Exception Handling Middleware
app.UseExceptionHandler(config =>
{
    config.Run(async context =>
    {
        var error = context.Features.Get<IExceptionHandlerFeature>();
        if (error != null)
        {
            var ex = error.Error;

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            switch (ex)
            {
                case UnauthorizedAccessException:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case KeyNotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case NotImplementedException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotImplemented;
                    break;
                case ArgumentNullException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

            }




            context.Response.ContentType = "application/json";

            var errorResponse = new ErrorModel
            {
                StatusCode = context.Response.StatusCode,
                ErrorMessage = ex.InnerException == null ? ex.Message : ex.InnerException.Message
            };

            await context.Response.WriteAsync("Error");
        }
    });
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
Console.WriteLine("\n\nAPI Docs: http://localhost:5125/scalar/v1");
app.Run();
#endregion