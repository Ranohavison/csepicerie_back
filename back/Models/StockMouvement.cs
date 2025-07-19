using System;
using System.Collections.Generic;

namespace back.Models;

public partial class StockMouvement
{
    public int Id { get; set; }

    public int? IdProduit { get; set; }

    public string? TypeMouvement { get; set; }

    public int? Quantite { get; set; }

    public DateOnly? DateMouvement { get; set; }

    public string? Motif { get; set; }

    public virtual Produit? IdProduitNavigation { get; set; }
}
