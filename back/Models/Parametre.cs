using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Parametre
{
    public int IdParam { get; set; }

    public string? Cle { get; set; }

    public string? Valeur { get; set; }

    public string? Description { get; set; }
}
