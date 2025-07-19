using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Role
{
    public int IdRole { get; set; }

    public string? NomRole { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<RolesPermission> RolesPermissions { get; set; } = new List<RolesPermission>();

    public virtual ICollection<Utilisateur> Utilisateurs { get; set; } = new List<Utilisateur>();
}
