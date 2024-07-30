using System;
using System.Collections.Generic;

namespace PerformanceIndividualDataAccess.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Profile? Profile { get; set; }

    public virtual Role? Role { get; set; } = null!;
}
