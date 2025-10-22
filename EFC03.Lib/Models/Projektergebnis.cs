using System;
using System.Collections.Generic;

namespace EFC03.Lib.Models;

public partial class Projektergebnis
{
    public int ProjektergebnisId { get; set; }

    public int ProjektId { get; set; }

    public decimal? Nettopreis { get; set; }

    public double? Mehrwertsteuersatz { get; set; }

    public DateOnly? Rechnungstellung { get; set; }

    public DateOnly? Zahlungseingang { get; set; }

    public virtual Projekt Projekt { get; set; } = null!;
}
