using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Client
{
    public int IdClient { get; set; }

    public string? Nom { get; set; }

    public string? Telephone { get; set; }

    public string? Email { get; set; }

    public decimal? Credit { get; set; }

    public DateOnly? DateInscription { get; set; }

    public virtual ICollection<Vente> Ventes { get; set; } = new List<Vente>();
}
