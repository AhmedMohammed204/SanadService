using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class Category
{
    [Key]
    [Column("category_id")]
    public int CategoryId { get; set; }

    [Column("category")]
    [StringLength(100)]
    public string Category1 { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    [InverseProperty("Category")]
    public virtual ICollection<QuizCategory> QuizCategories { get; set; } = new List<QuizCategory>();

    [InverseProperty("Category")]
    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}
