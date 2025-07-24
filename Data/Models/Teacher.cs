using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class Teacher
{
    [Key]
    [Column("teacher_id")]
    public int TeacherId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [InverseProperty("Teacher")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    [ForeignKey("UserId")]
    [InverseProperty("Teachers")]
    public virtual User User { get; set; } = null!;
}
