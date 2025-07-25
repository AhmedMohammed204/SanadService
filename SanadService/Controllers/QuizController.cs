using Core_Layer.DTOs;
using Core_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SanadService.Authorization;
using System.Text.Json;
using static Core_Layer.DTOs.QuizDTOs;

namespace SanadService.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet("generate-ai")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<QuizDTOs.QuizQuestionDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<QuizDTOs.QuizQuestionDTO>>> GenerateQuiz([FromQuery] QuizDTOs.QuizInfoDTO quizInfoDTO)
        {
            var resultString = await _quizService.GenerateQuizByAsyncByAI(quizInfoDTO);
            if(resultString == null)
            {
                return BadRequest("Failed to generate quiz. Please try again.");
            }
            var result = JsonSerializer.Deserialize<List<QuizQuestionDTO>>(resultString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return Ok(result);
        }
    }
}
