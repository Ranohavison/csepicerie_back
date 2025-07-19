using System;
using System.Collections.Generic;

namespace back.Models;

public partial class Pointage
{
    public int IdPointage { get; set; }

    public int? IdUtilisateur { get; set; }

    public DateOnly? Date { get; set; }

    public TimeOnly? HeureArrivee { get; set; }

    public TimeOnly? HeureDepart { get; set; }

    public virtual Utilisateur? IdUtilisateurNavigation { get; set; }
}
