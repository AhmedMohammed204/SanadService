using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class EnrolledStudentsCourse
{
    [Key]
    [Column("encrolled_student_course_id")]
    public int EncrolledStudentCourseId { get; set; }

    [Column("student_id")]
    public int StudentId { get; set; }

    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("joining_date", TypeName = "datetime")]
    public DateTime? JoiningDate { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("EnrolledStudentsCourses")]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("EnrolledStudentsCourses")]
    public virtual Student Student { get; set; } = null!;
}
