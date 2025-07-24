using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

[Keyless]
[Table("chosen_choices")]
public partial class ChosenChoice
{
    [Column("choicen_choice_id")]
    public int? ChoicenChoiceId { get; set; }
}
