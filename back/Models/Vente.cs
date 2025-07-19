using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Vente
{
    public int IdVente { get; set; }

    public int? IdClient { get; set; }

    public int? IdUtilisateur { get; set; }

    public DateOnly? DateVente { get; set; }

    public decimal? Total { get; set; }

    public string? Paiement { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<DetailsVente> DetailsVentes { get; set; } = new List<DetailsVente>();

    public virtual Client? IdClientNavigation { get; set; }

    public virtual Utilisateur? IdUtilisateurNavigation { get; set; }
}
