using System;
using System.Collections.Generic;

namespace ELearning_System.Models;

public partial class Payment
{
    public int Id { get; set; }

    public float Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
