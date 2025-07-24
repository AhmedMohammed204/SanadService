using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class Quiz
{
    [Key]
    [Column("quiz_id")]
    public int QuizId { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("modified_date", TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [Column("create_by_user_id")]
    public int CreateByUserId { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Quizzes")]
    public virtual Category Category { get; set; } = null!;

    [ForeignKey("CreateByUserId")]
    [InverseProperty("Quizzes")]
    public virtual User CreateByUser { get; set; } = null!;

    [InverseProperty("Quiz")]
    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    [InverseProperty("Quiz")]
    public virtual ICollection<QuizCategory> QuizCategories { get; set; } = new List<QuizCategory>();
}
