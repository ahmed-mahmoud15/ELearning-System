﻿using System;
using System.Collections.Generic;

namespace ELearning_System.Models;

public partial class Certificate
{
    public int Id { get; set; }

    public int EnrollmentId { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;
}
