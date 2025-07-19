using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Produit
{
    public int IdProduit { get; set; }

    public int? IdCategorie { get; set; }

    public string? CodeBarre { get; set; }

    public string? Nom { get; set; }

    public decimal? PrixAchat { get; set; }

    public decimal? PrixVente { get; set; }

    public int? Quantite { get; set; }

    public string? Unite { get; set; }

    public int? SeuilMin { get; set; }

    public DateOnly? DateAjout { get; set; }

    public virtual ICollection<DetailsAchat> DetailsAchats { get; set; } = new List<DetailsAchat>();

    public virtual ICollection<DetailsVente> DetailsVentes { get; set; } = new List<DetailsVente>();

    public virtual Category? IdCategorieNavigation { get; set; }

    public virtual ICollection<StockMouvement> StockMouvements { get; set; } = new List<StockMouvement>();
}
