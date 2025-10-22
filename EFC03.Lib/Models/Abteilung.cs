using System;
using System.Collections.Generic;

namespace EFC03.Lib.Models;

public partial class Abteilung
{
    public int AbteilungId { get; set; }

    public string? Abteilungsbezeichnung { get; set; }

    public virtual ICollection<Mitarbeiter> MitarbeiterListe { get; set; } = new List<Mitarbeiter>();
}
