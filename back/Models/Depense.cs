using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Depense
{
    public int IdDepense { get; set; }

    public string? Libelle { get; set; }

    public decimal? Montant { get; set; }

    public DateOnly? DateDepense { get; set; }

    public string? Categorie { get; set; }

    public string? Justificatif { get; set; }
}
