using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Permission
{
    public int IdPermission { get; set; }

    public string? NomModule { get; set; }

    public string? Action { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<RolesPermission> RolesPermissions { get; set; } = new List<RolesPermission>();
}
