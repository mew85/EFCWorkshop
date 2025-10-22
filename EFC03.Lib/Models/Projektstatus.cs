using System;
using System.Collections.Generic;

namespace EFC03.Lib.Models;

public partial class Projektstatus
{
    public int ProjektstatusId { get; set; }

    public string Projektstatus1 { get; set; } = null!;

    public virtual ICollection<Projekt> ProjektListe { get; set; } = new List<Projekt>();
}
