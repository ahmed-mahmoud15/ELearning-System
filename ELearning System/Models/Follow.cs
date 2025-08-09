using System;
using System.Collections.Generic;

namespace ELearning_System.Models;

public partial class Follow
{
    public int StudentId { get; set; }

    public int InstructorId { get; set; }

    public DateTime FollowDate { get; set; }

    public virtual Instructor Instructor { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
