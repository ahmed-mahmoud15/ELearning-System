using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ELearning_System.Models;

public partial class User
{
    public int Id { get; set; }

    public string IdentityId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string? PhotoPath { get; set; }

    public string? Bio { get; set; }

    [ForeignKey(nameof(IdentityId))]
    public virtual IdentityUser Identity { get; set; } = null!;
}
