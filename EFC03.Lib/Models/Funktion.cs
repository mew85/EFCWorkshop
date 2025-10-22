using System;
using System.Collections.Generic;

namespace EFC03.Lib.Models;

public partial class Funktion
{
    public int FunktionId { get; set; }

    public string Funktionsbezeichnung { get; set; } = null!;

    public virtual ICollection<Mitarbeiter> MitarbeiterListe { get; set; } = new List<Mitarbeiter>();

    public virtual ICollection<Projektmitarbeiter> ProjektmitarbeiterListe { get; set; } = new List<Projektmitarbeiter>();
}
