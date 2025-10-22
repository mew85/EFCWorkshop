using EFC01.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC01.ConsApp
{
    public class TestAbfragen
    {
        /// <summary>
        /// Abfrage mit Standardverhalten. Verbundene Objekte werden nicht mitgeladen.
        /// </summary>
        /// <param name="abt">Abteilungsbezeichnung</param>
        public static void GetMitarbeiterListeStdBehaviour(string abt = "Produktion")
        {
            using (var dbctx = new EFC01DBContext())
            {
                var maListe = dbctx.MitarbeiterListe
                    .Where(m => m.Abteilung.Abteilungsbezeichnung.Contains(abt));

                Display(maListe.ToQueryString());

                foreach (var ma in maListe.ToList())
                {
                    //Produkziert Fehler, weil Abteilung nicht geladen wird
                    Display($"Abteilung: {ma.Abteilung.Abteilungsbezeichnung} - {ma.Nachname}, {ma.Vorname}");
                }
            }
        }

        /// <summary>
        /// Abfrage mit Eager-Loading. Verbundene Objekte werden mitgeladen.
        /// </summary>
        /// <param name="abt">Abteilungsbezeichnung</param>
        public static void GetMitarbeiterListeEager(string abt = "Produktion")
        {
            using (var dbctx = new EFC01DBContext())
            {
                var maListe = dbctx.MitarbeiterListe
                    .Include(m => m.Abteilung)
                    .Where(m => m.Abteilung.Abteilungsbezeichnung.Contains(abt));

                Display(maListe.ToQueryString());

                foreach (var ma in maListe.ToList())
                {
                    //Da Abteilung mitgeladen wird, werden die Daten korekt ausgegeben
                    Display($"Abteilung: {ma.Abteilung.Abteilungsbezeichnung} - {ma.Nachname}, {ma.Vorname}");
                }
            }
        }

        public static void GetAbteilungsListeStd()
        {
            using (var dbctx = new EFC01DBContext())
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
    }
}
