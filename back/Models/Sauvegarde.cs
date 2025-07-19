using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Sauvegarde
{
    public int IdSauvegarde { get; set; }

    public string? Type { get; set; }

    public string? CheminFichier { get; set; }

    public DateOnly? DateSauvegarde { get; set; }

    public string? Declencheur { get; set; }
}
