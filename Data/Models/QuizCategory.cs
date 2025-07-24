using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class QuizCategory
{
    [Key]
    [Column("quiz_category_id")]
    public int QuizCategoryId { get; set; }

    [Column("quiz_id")]
    public int QuizId { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("QuizCategories")]
    public virtual Category Category { get; set; } = null!;

    [ForeignKey("QuizId")]
    [InverseProperty("QuizCategories")]
    public virtual Quiz Quiz { get; set; } = null!;
}
