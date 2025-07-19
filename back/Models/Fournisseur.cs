using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Fournisseur
{
    public int IdFournisseur { get; set; }

    public string? Nom { get; set; }

    public string? Adresse { get; set; }

    public string? Telephone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Achat> Achats { get; set; } = new List<Achat>();
}
