using System;
using System.Collections.Generic;

namespace EFC03.Lib.Models;

public partial class Projekt
{
    public int ProjektId { get; set; }

    public string Projektbezeichnung { get; set; } = null!;

    public bool? Fakturierbar { get; set; }

    public DateOnly? Projektstart { get; set; }

    public DateOnly? Projektende { get; set; }

    public int ProjekttypId { get; set; }

    public int ProjektstatusId { get; set; }

    public virtual Projektergebnis? Projektergebnis { get; set; }

    public virtual ICollection<Projektmitarbeiter> Projektmitarbeiters { get; set; } = new List<Projektmitarbeiter>();

    public virtual Projektstatus Projektstatus { get; set; } = null!;

    public virtual Projekttyp Projekttyp { get; set; } = null!;
}
