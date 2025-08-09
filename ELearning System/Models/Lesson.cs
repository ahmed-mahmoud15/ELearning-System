using System;
using System.Collections.Generic;

namespace ELearning_System.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public string Title { get; set; } = null!;

    public int SequenceNumber { get; set; }

    public int Type { get; set; }

    public string FilePath { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}
