global using static Utilities.Lib.ConsoleUtility;
using EFC01.Lib.Models;

namespace EFC01.ConsApp
{
    internal class MainEFC01
    {
        static void Main(string[] args)
        {
            //Abfrage mit Fehler
            //TestAbfragen.GetMitarbeiterListeStdBehaviour("Produktion");

            //Funktionierende Abfrage
            TestAbfragen.GetMitarbeiterListeEager("Produktion");

            //neue Abteilung hinzufügen
            //TestAbfragen.GetAbteilungsListeStd();
            //Abteilung a = new Abteilung() { Abteilungsbezeichnung = "Buchhaltung" };
            //TestAdd.AddAbteilung(a);
            //TestAbfragen.GetAbteilungsListeStd();

            //Mitarbeiter in andere Abteilung versetzen
            //TestAbfragen.GetMitarbeiterListeEager("Geschäftsleitung/RW");
            //TestUpdate.ÜberführeMitarbeiter();
            //TestAbfragen.GetMitarbeiterListeEager("Geschäftsleitung/RW");

            //Abteilung löschen
            //TestAbfragen.GetAbteilungsListeStd();
            //TestRemove.RemoveAbteilung();
            //TestAbfragen.GetAbteilungsListeStd();
        }

    }
}
