using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class User
{
    [Key]
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("person_id")]
    public int PersonId { get; set; }

    [Column("username")]
    [StringLength(50)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [Column("password_hash")]
    [StringLength(500)]
    public string PasswordHash { get; set; } = null!;

    [Column("join_date", TypeName = "datetime")]
    public DateTime? JoinDate { get; set; }

    [Column("permissions")]
    public int Permissions { get; set; }

    [Column("bio")]
    [StringLength(500)]
    public string? Bio { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("Users")]
    public virtual Person Person { get; set; } = null!;

    [InverseProperty("CreateByUser")]
    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();

    [InverseProperty("User")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [InverseProperty("User")]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
