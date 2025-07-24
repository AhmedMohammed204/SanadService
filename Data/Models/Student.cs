using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class Student
{
    [Key]
    [Column("student_id")]
    public int StudentId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<EnrolledStudentsCourse> EnrolledStudentsCourses { get; set; } = new List<EnrolledStudentsCourse>();

    [ForeignKey("UserId")]
    [InverseProperty("Students")]
    public virtual User User { get; set; } = null!;
}
