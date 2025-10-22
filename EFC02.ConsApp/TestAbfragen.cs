using EFC02.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC02.ConsApp
{
    public class TestAbfragen
    {
        /// <summary>
        /// Abfrage mit Standardverhalten. Verbundene Objekte werden nicht mitgeladen.
        /// </summary>
        /// <param name="abt">Abteilungsbezeichnung</param>
        public static void GetMitarbeiterListeStdBehaviour(string abt = "Produktion")
        {
            using (var dbctx = new EFC02DBContext())
            {
                var maListe = dbctx.MitarbeiterListe
                    .Where(m => m.Abteilung.Abteilungsbezeichnung.Contains(abt));

                //zeigt die Query im Ausgabefenster an, die erzeugt wird
                //Display(maListe.ToQueryString());

                foreach (var ma in maListe.ToList())
                {
                    //Produkziert Fehler, weil Abteilung nicht geladen wird
                    Display($"Niederlassung: {ma.Niederlassung.Niederlassungsbezeichnung} // Abteilung: {ma.Abteilung.Abteilungsbezeichnung} - {ma.Nachname}, {ma.Vorname}");
                    if (!ma.NiederlassungId.HasValue)
                    {
                        Display("... Niederlassung?");
                    }
                }
            }
        }

        /// <summary>
        /// Abfrage mit Eager-Loading. Verbundene Objekte werden mitgeladen.
        /// </summary>
        /// <param name="abt">Abteilungsbezeichnung</param>
        public static void GetMitarbeiterListeEager(string abt = "Produktion")
        {
            using (var dbctx = new EFC02DBContext())
            {
                var maListe = dbctx.MitarbeiterListe
                    .Include(m => m.Abteilung)
                    .Where(m => m.Abteilung.Abteilungsbezeichnung.Contains(abt));

                //zeigt die Query im Ausgabefenster an, die erzeugt wird
                //Display(maListe.ToQueryString());

                foreach (var ma in maListe.ToList())
                {
                    //Da Abteilung mitgeladen wird, werden die Daten korekt ausgegeben
                    Display($"Niederlassung: {ma.NiederlassungId} // Abteilung: {ma.Abteilung.Abteilungsbezeichnung} - {ma.Nachname}, {ma.Vorname}");
                    if (ma.NiederlassungId == null)
                    {
                        Display("... Niederlassung?");
                    }
                }
            }
        }

        public static void GetAbteilungsListeStd()
        {
            using (var dbctx = new EFC02DBContext())
            {
                var abtListe = dbctx.AbteilungListe;
                    

                //Display(abtListe.ToQueryString());

                foreach (var abt in abtListe.ToList())
                {
                    //Da Abteilung mitgeladen wird, werden die Daten korekt ausgegeben
                    Display($"Abteilung: {abt.AbteilungId} / {abt.Abteilungsbezeichnung}");
                }
            }
        }

        public static void GetNiederlassungsListeStd()
        {
            using (var dbctx = new EFC02DBContext())
            {
                var abtListe = dbctx.NiederlassungListe;


                //Display(abtListe.ToQueryString());

                foreach (var abt in abtListe.ToList())
                {
                    //Da Abteilung mitgeladen wird, werden die Daten korekt ausgegeben
                    Display($"Niederlassung: {abt.NiederlassungId} / {abt.Niederlassungsbezeichnung}");
                }
            }
        }
    }
}
