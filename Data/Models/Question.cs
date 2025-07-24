using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class Question
{
    [Key]
    [Column("question_id")]
    public int QuestionId { get; set; }

    [Column("text")]
    public string Text { get; set; } = null!;

    [Column("quiz_id")]
    public int QuizId { get; set; }

    [Column("question_level_id")]
    public int QuestionLevelId { get; set; }

    [ForeignKey("QuestionLevelId")]
    [InverseProperty("Questions")]
    public virtual QuestionLevel QuestionLevel { get; set; } = null!;

    [ForeignKey("QuizId")]
    [InverseProperty("Questions")]
    public virtual Quiz Quiz { get; set; } = null!;

    [InverseProperty("Question")]
    public virtual ICollection<QuizChoice> QuizChoices { get; set; } = new List<QuizChoice>();
}
