using System;
using System.Collections.Generic;

namespace ELearning_System.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public float Price { get; set; }

    public string? Description { get; set; }

    public int Level { get; set; }

    public float Rating { get; set; }

    public DateTime CreationDate { get; set; }

    public int InstructorId { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Instructor Instructor { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
}
