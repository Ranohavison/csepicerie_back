using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Achat
{
    public int IdAchat { get; set; }

    public int? IdFournisseur { get; set; }

    public DateOnly? DateAchat { get; set; }

    public decimal? Total { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<DetailsAchat> DetailsAchats { get; set; } = new List<DetailsAchat>();

    public virtual Fournisseur? IdFournisseurNavigation { get; set; }
}
