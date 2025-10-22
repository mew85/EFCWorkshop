global using static Utilities.Lib.ConsoleUtility;
using ADOTest.DBAccess;
using ADOTEST.Lib.Models;

namespace ADOTest.ConsApp
{
    internal class MainADOTest
    {
        static void Main(string[] args)
        {
            Display("Abeiltungsliste:");
            List<Abteilung> abtListe = DBAccess.DBAccess.GetDbAbteilungsliste();

            foreach(Abteilung abtItem in abtListe)
            {
                Display($"{abtItem.AbteilungId} : {abtItem.Abteilungsbezeichnung}");
            }

            Display();
            List<Mitarbeiter> maListe = DBAccess.DBAccess.GetDBMitarbeiterListe();
            foreach (Mitarbeiter ma in maListe)
            {
                Display($"{ma.MitarbeiterId}: {ma.Vorname} {ma.Nachname}, Abteilung: {ma.Abteilung.Abteilungsbezeichnung}, Funktion: {ma.Funktion.Funktionsbezeichnung}");
            }

            Input();
        }
    }
}
