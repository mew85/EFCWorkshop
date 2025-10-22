using System;
using System.Collections.Generic;

namespace EFC03.Lib.Models;

public partial class VMitarbeiterListeMitFunktionen
{
    public int MitarbeiterId { get; set; }

    public string? Name { get; set; }

    public string? Anrede { get; set; }

    public int? Alter { get; set; }

    public string? Telefon { get; set; }

    public string? Funktion { get; set; }

    public string? Abteilung { get; set; }

    public string? Niederlassung { get; set; }
}
