using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class Session
{
    [Key]
    [Column("session_id")]
    public int SessionId { get; set; }

    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("backup_path")]
    [Unicode(false)]
    public string? BackupPath { get; set; }

    [Column("description")]
    [StringLength(500)]
    public string? Description { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [ForeignKey("CourseId")]
    [InverseProperty("Sessions")]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("Sessions")]
    public virtual SessionStatus Status { get; set; } = null!;
}
