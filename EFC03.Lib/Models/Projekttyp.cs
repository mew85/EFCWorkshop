using System;
using System.Collections.Generic;

namespace EFC03.Lib.Models;

public partial class Projekttyp
{
    public int ProjekttypId { get; set; }

    public string Projekttyp1 { get; set; } = null!;

    public virtual ICollection<Projekt> ProjektListe { get; set; } = new List<Projekt>();
}
