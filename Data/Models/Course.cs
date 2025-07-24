using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class Course
{
    [Key]
    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("teacher_id")]
    public int TeacherId { get; set; }

    [Column("name")]
    [StringLength(200)]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("creation_date", TypeName = "datetime")]
    public DateTime? CreationDate { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Courses")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Course")]
    public virtual ICollection<EnrolledStudentsCourse> EnrolledStudentsCourses { get; set; } = new List<EnrolledStudentsCourse>();

    [InverseProperty("Course")]
    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    [ForeignKey("TeacherId")]
    [InverseProperty("Courses")]
    public virtual Teacher Teacher { get; set; } = null!;
}
