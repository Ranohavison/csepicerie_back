using System;
using System.Collections.Generic;

namespace back.Models;

public partial class DetailsVente
{
    public int Id { get; set; }

    public int? IdVente { get; set; }

    public int? IdProduit { get; set; }

    public int? Quantite { get; set; }

    public decimal? PrixUnitaire { get; set; }

    public decimal? Remise { get; set; }

    public virtual Produit? IdProduitNavigation { get; set; }

    public virtual Vente? IdVenteNavigation { get; set; }
}
