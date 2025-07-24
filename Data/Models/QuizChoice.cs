using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class QuizChoice
{
    [Key]
    [Column("quiz_choice_id")]
    public int QuizChoiceId { get; set; }

    [Column("choice")]
    [StringLength(500)]
    public string Choice { get; set; } = null!;

    [Column("question_id")]
    public int QuestionId { get; set; }

    [Column("right_answer")]
    public bool RightAnswer { get; set; }

    [ForeignKey("QuestionId")]
    [InverseProperty("QuizChoices")]
    public virtual Question Question { get; set; } = null!;
}
