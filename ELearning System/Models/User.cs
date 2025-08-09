using System;
using System.Collections.Generic;

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

    public virtual AspNetUser Identity { get; set; } = null!;

    public virtual Instructor? Instructor { get; set; }

    public virtual Student? Student { get; set; }
}
