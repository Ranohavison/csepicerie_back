using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Utilisateur
{
    public int IdUtilisateur { get; set; }

    public int? IdRole { get; set; }

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public string? Email { get; set; }

    public string? MotDePasse { get; set; }

    public string? Statut { get; set; }

    public DateOnly? DateCreation { get; set; }

    public virtual Role? IdRoleNavigation { get; set; }

    public virtual ICollection<Pointage> Pointages { get; set; } = new List<Pointage>();

    public virtual ICollection<Vente> Ventes { get; set; } = new List<Vente>();
}
