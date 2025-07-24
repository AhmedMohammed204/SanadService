using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ChosenChoice> ChosenChoices { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<EnrolledStudentsCourse> EnrolledStudentsCourses { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestionLevel> QuestionLevels { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<QuizCategory> QuizCategories { get; set; }

    public virtual DbSet<QuizChoice> QuizChoices { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<SessionStatus> SessionStatuses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AI");

        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.CourseId).ValueGeneratedNever();
            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Category).WithMany(p => p.Courses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_Categories");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Courses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_Teachers");
        });

        modelBuilder.Entity<EnrolledStudentsCourse>(entity =>
        {
            entity.Property(e => e.JoiningDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Course).WithMany(p => p.EnrolledStudentsCourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnrolledStudentsCourses_Courses");

            entity.HasOne(d => d.Student).WithMany(p => p.EnrolledStudentsCourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnrolledStudentsCourses_Students");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.Property(e => e.QuestionId).ValueGeneratedNever();

            entity.HasOne(d => d.QuestionLevel).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Questions_QuestionLevels");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Questions_Quizzes");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Category).WithMany(p => p.Quizzes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Quizzes_Categories");

            entity.HasOne(d => d.CreateByUser).WithMany(p => p.Quizzes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Quizzes_Users");
        });

        modelBuilder.Entity<QuizCategory>(entity =>
        {
            entity.HasOne(d => d.Category).WithMany(p => p.QuizCategories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QuizCategories_Categories");

            entity.HasOne(d => d.Quiz).WithMany(p => p.QuizCategories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QuizCategories_Quizzes");
        });

        modelBuilder.Entity<QuizChoice>(entity =>
        {
            entity.HasOne(d => d.Question).WithMany(p => p.QuizChoices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QuizChoices_Questions");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasOne(d => d.Course).WithMany(p => p.Sessions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sessions_Courses");

            entity.HasOne(d => d.Status).WithMany(p => p.Sessions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sessions_SessionStatus");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Students_Users");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.Teachers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Teachers_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.JoinDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Person).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_People");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
