using System;
using System.Collections.Generic;

namespace EFC03.Lib.Models;

public partial class Projektmitarbeiter
{
    public int ProjektmitarbeiterId { get; set; }

    public int ProjektId { get; set; }

    public int MitarbeiterId { get; set; }

    public DateOnly? Beginn { get; set; }

    public DateOnly? Ende { get; set; }

    public double? Fakturierbarestunden { get; set; }

    public double? Nichtfakturierbarestunden { get; set; }

    public int? FunktionId { get; set; }

    public decimal? Stundensatz { get; set; }

    public virtual Funktion? Funktion { get; set; }

    public virtual Mitarbeiter Mitarbeiter { get; set; } = null!;

    public virtual Projekt Projekt { get; set; } = null!;
}
