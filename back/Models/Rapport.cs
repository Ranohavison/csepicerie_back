using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Rapport
{
    public int IdRapport { get; set; }

    public string? Type { get; set; }

    public string? Periode { get; set; }

    public DateOnly? DateGeneration { get; set; }

    public string? FichierPdf { get; set; }
}
