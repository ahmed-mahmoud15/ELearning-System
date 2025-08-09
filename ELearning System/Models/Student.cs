using System;
using System.Collections.Generic;

namespace ELearning_System.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? GitHubAccount { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Follow> Follows { get; set; } = new List<Follow>();

    public virtual User IdNavigation { get; set; } = null!;

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
}
