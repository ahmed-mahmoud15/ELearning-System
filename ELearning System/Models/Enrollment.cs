using System;
using System.Collections.Generic;

namespace ELearning_System.Models;

public partial class Enrollment
{
    public int Id { get; set; }

    public int PaymentId { get; set; }

    public int CourseId { get; set; }

    public int StudentId { get; set; }

    public DateTime Date { get; set; }

    public float Progress { get; set; }

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    public virtual Course Course { get; set; } = null!;

    public virtual Payment Payment { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
