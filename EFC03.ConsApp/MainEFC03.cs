global using static Utilities.Lib.ConsoleUtility;

namespace EFC03.ConsApp
{
    internal class MainEFC03
    {
        static void Main(string[] args)
        {
            #region Projektion, Datentransferobjekte (DTO) und Datenbankobjekte
            //TestDatenbankobjekte.GetMitarbeiterListeAnonym();

            //TestDatenbankobjekte.GetMitarbeiterListeRecord();

            //TestDatenbankobjekte.GetAbteilungEMailListe();

            //TestDatenbankobjekte.NutzungIntegrierterFunktionen();

            //TestDatenbankobjekte.GetMitTabellenwertfunktion();

            //TestDatenbankobjekte.GetMitStoredProcedure();

            //TestDatenbankobjekte.UpdateProjekt();

            //Test_Loeschverhalten.LoescheMzuN();

            Test_Loeschverhalten.LoescheMitarbeiter();
            #endregion
        }
    }
}
