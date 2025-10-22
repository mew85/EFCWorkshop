using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC03.Lib.Models
{
    public record MitarbeiterAuswahl
    {
        [Key]
        public int MitarbieterId { get; set; }
        public string Name { get; set; }
        public string Anrede { get; set; }
        public int? Alter { get; set; }
        public string Telefon { get; set; }
        public string Funktion { get; set; }
        public string Abteilung { get; set; }
        public string Niederlassung { get; set; }
    }

    // weitere Möglichkeit einen record anzulegen
    // wenger Empfehlenswert, da kein Key-Attribute hinterlegt werden kann, was zwigend notwendig ist
    public record  MitarbeiterAuswahl2 (int MitarbeiterId, string Name, string Anrede, int? Alter, string Telefon, string Abteilung, string Funktion, string Niederlassung);

    public record AbteilungEmails
    {
        [Key]
        public int AbteilungId { get; set; }
        public string Abteilung { get; set; }
        public string EMailListe { get; set; }
    }
    
    public record Projektentwicklung
    {
        [Key]
        public int Id { get; set; }
        public string Projekt { get; set; }
        public DateOnly Beginn { get; set; }
        public DateOnly Ende { get; set; }  
        public string Mitarbeiter { get; set; }
        public DateOnly MitarbeiterBeginn { get; set; }
        public DateOnly MitarbeiterEnde { get; set; }
    }
}
