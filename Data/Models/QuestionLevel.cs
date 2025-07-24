using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class QuestionLevel
{
    [Key]
    [Column("question_level_id")]
    public int QuestionLevelId { get; set; }

    [Column("question_level")]
    [StringLength(50)]
    public string QuestionLevel1 { get; set; } = null!;

    [InverseProperty("QuestionLevel")]
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
