using System;
using System.Collections.Generic;

namespace back.Models;

public partial class DetailsAchat
{
    public int Id { get; set; }

    public int? IdProduit { get; set; }

    public int? IdAchat { get; set; }

    public int? Quantity { get; set; }

    public decimal? PrixUnitaire { get; set; }

    public virtual Achat? IdAchatNavigation { get; set; }

    public virtual Produit? IdProduitNavigation { get; set; }
}
