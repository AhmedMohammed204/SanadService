using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Table("SessionStatus")]
public partial class SessionStatus
{
    [Key]
    [Column("sessino_status_id")]
    public int SessinoStatusId { get; set; }

    [Column("status")]
    [StringLength(50)]
    public string Status { get; set; } = null!;

    [InverseProperty("Status")]
    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
