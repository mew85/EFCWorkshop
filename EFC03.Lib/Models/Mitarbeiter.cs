using System;
using System.Collections.Generic;

namespace EFC03.Lib.Models;

public partial class Mitarbeiter
{
    public int MitarbeiterId { get; set; }

    public string? Prsnr { get; set; }

    public string Nachname { get; set; } = null!;

    public string? Vorname { get; set; }

    public string Geschlecht { get; set; } = null!;

    public DateOnly? DatumEintritt { get; set; }

    public DateOnly? DatumAustritt { get; set; }

    public bool? Extern { get; set; }

    public string? Email { get; set; }

    public string? Durchwahl { get; set; }

    public int? AbteilungId { get; set; }

    public int? FunktionId { get; set; }

    public int? NiederlassungId { get; set; }

    public DateOnly? Geburtsdatum { get; set; }

    public virtual Abteilung? Abteilung { get; set; }

    public virtual Funktion? Funktion { get; set; }

    public virtual Niederlassung? Niederlassung { get; set; }

    public virtual ICollection<Projektmitarbeiter> ProjektmitarbeiterListe { get; set; } = new List<Projektmitarbeiter>();
}
