using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning_System.Models;

public partial class Instructor
{
    public int Id { get; set; }

    public float Rating { get; set; }

    public string? Experience { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Follow> Follows { get; set; } = new List<Follow>();

    [ForeignKey(nameof(Id))]
    public virtual User IdNavigation { get; set; } = null!;
}
