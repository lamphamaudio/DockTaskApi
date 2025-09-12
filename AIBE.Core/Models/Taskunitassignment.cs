using System;
using System.Collections.Generic;

namespace AIBE.Core.Models;

public partial class Taskunitassignment
{
    public int TaskUnitAssignmentId { get; set; }

    public int TaskId { get; set; }

    public int UnitId { get; set; }

    public virtual Task Task { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
