using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Category
{
    public int IdCategorie { get; set; }

    public string? Nom { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Produit> Produits { get; set; } = new List<Produit>();
}
