using System;
using System.Collections.Generic;

namespace EFC03.Lib.Models;

public partial class Niederlassung
{
    public int NiederlassungId { get; set; }

    public string Niederlassungsbezeichnung { get; set; } = null!;

    public string Niederlassungsvorwahl { get; set; } = null!;

    public virtual ICollection<Mitarbeiter> MitarbeiterListe { get; set; } = new List<Mitarbeiter>();
}
