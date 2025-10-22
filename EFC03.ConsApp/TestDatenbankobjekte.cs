using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC03.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace EFC03.ConsApp
{
    internal class TestDatenbankobjekte
    {
        /// <summary>
        /// Projektion durch Auswahl bestimmter Daten
        /// </summary>
        /// <param name="abt"></param>
        public static void GetMitarbeiterListeAnonym(string abt = "Produktion")
        {
            using (var dbctx = new Efc03Context())
            {
                var maListe = dbctx.MitarbeiterListe
                    .Include(m => m.Abteilung)
                    .Where(m => m.Abteilung.Abteilungsbezeichnung.Contains(abt))
                    .Select(x => x.Nachname + ", " + x.Vorname + " - Abteilung: " + x.Abteilung.Abteilungsbezeichnung);

                //zeigt die Query im Ausgabefenster an, die erzeugt wird
                //Display(maListe.ToQueryString());

                foreach (var ma in maListe.ToList())
                {
                    //Da Abteilung mitgeladen wird, werden die Daten korekt ausgegeben
                    Display($"{ma}");

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void GetMitarbeiterListeRecord()
        {
            using (var dbctx = new Efc03Context())
            {
                var maListe = dbctx.MitarbeiterListe
                    .Include(o => o.Abteilung)
                    .Include(o => o.Funktion)
                    .Include(o => o.Niederlassung)
                    .OrderBy(o => o.Abteilung.Abteilungsbezeichnung)
                    .ThenBy(o => o.Nachname)
                    .Select(o => new MitarbeiterAuswahl()
                    {
                        MitarbieterId = o.MitarbeiterId,
                        Name = o.Nachname + ", " + o.Vorname,
                        Anrede = Efc03Context.Anrede(o.Geschlecht),
                        Alter = Efc03Context.Alter(o.Geburtsdatum),
                        Telefon = o.Niederlassung!.Niederlassungsvorwahl + " " + o.Durchwahl,
                        Funktion = o.Funktion!.Funktionsbezeichnung,
                        Abteilung = o.Abteilung!.Abteilungsbezeichnung,
                        Niederlassung = o.Niederlassung.Niederlassungsbezeichnung
                    });

                //zeigt die Query im Ausgabefenster an, die erzeugt wird
                //Display(maListe.ToQueryString());

                foreach (var ma in maListe.ToList())
                {
                    //Da Abteilung mitgeladen wird, werden die Daten korekt ausgegeben
                    Display($"{ma}");

                }
            }
        }

        public static void GetAbteilungEMailListe()
        {
            using (var dbctx = new Efc03Context())
            {
                var abtEMailListe = dbctx.vAbteilungEMailListe;

                foreach (var abt in abtEMailListe)
                {
                    Display(abt.Abteilung + ": " + abt.EMailListe);
                }
            }
        }

        public static void NutzungIntegrierterFunktionen()
        {
            using (var dbctx = new Efc03Context())
            {
                var mitListe = dbctx.MitarbeiterListe
                    .OrderBy(m => m.Nachname)
                    .Where(m => EF.Functions.Like(m.Nachname, "P%"))
                    .Select(m => new
                    {
                        MitarbeiterId = m.MitarbeiterId,
                        Name = m.Nachname + ", " + m.Vorname,
                        Anrede = GetAnrede(m.Geschlecht),
                        Dienstjahre = EF.Functions.DateDiffYear(m.DatumEintritt, new DateOnly(2025, 10, 21))
                    });

                foreach (var m in mitListe)
                {
                    Display($"Person: {m.Anrede} {m.Name}, Dienstjahre: {m.Dienstjahre}");
                }
            }
        }

        private static string GetAnrede(string geschlecht)
        {
            string anrede = "nix Anrede";

            switch (geschlecht)
            {
                case "w":
                    anrede = "Frau";
                    break;
                case "m":
                    anrede = "Herr";
                    break;
            }

            return anrede;
        }

        public static void GetMitStoredProcedure(int abtId = 2)
        {
            using (var dbctx = new Efc03Context())
            {
                var abtListe = dbctx.uspAbteilungEMailListe.FromSql($"exec dbo.uspAbteilungEMailListe {abtId}");

                foreach (var a in abtListe)
                {
                    Display($"Abteilung: {a.Abteilung} // EMails: {a.EMailListe})");
                }
            }
        }

        public static void GetMitTabellenwertfunktion(int prjId = 23)
        {
            using (var dbctx = new Efc03Context())
            {
                var peListe = dbctx.udfProjektentwicklung.FromSql($"select * from dbo.udfProjektentwicklung ({prjId})");

                foreach (var pe in peListe)
                {
                    Display($"Projektentwicklung: {pe.Projekt} ({pe.Beginn}-{pe.Ende} // MA: {pe.Mitarbeiter} ({pe.MitarbeiterBeginn}-{pe.MitarbeiterEnde}))");
                }
            }
        }

        public static void UpdateProjekt()
        {
            using (var dbctx = new Efc03Context())
            {
                var projekt = dbctx.ProjektListe.Where(p => p.ProjektId == 44).FirstOrDefault();

                if(projekt != null)
                {
                    Display($"Status vor Update: {dbctx.Entry(projekt).State}");
                    projekt.Projektende = new DateOnly(2025, 10, 31);
                    Display($"Status nach Update: {dbctx.Entry(projekt).State}");

                    dbctx.ChangeTracker.DetectChanges();
                    Display("Tracking:");
                    Display(dbctx.ChangeTracker.DebugView.LongView);

                    dbctx.SaveChanges();
                    Display($"Status nach Save: {dbctx.Entry(projekt).State}");
                }
            }
        }

        public static void LöscheMzuN()
        {
            //Löschen eines Projektes (Frage: was passiert mit Projekt-MA)

            string projName = "Beetz";
            using (var dbctx = new Efc03Context())
            {
                var projekt = dbctx.ProjektListe.Where(p => p.Projektbezeichnung.Equals(projName)).FirstOrDefault();
                var mitProjektListe = dbctx.ProjektmitarbeiterListe.Where(pm => pm.ProjektId.Equals(projekt.ProjektId)).Include(f => f.Funktion);

                Display("Projektmitarbeiter:");
                foreach (var pm in mitProjektListe)
                {
                    Display($"{pm.Mitarbeiter.Vorname} {pm.Mitarbeiter.Nachname} ({pm.Funktion.Funktionsbezeichnung})");
                }

                //was passiert nun, wenn das Projekt gelöscht wird
                dbctx.Remove<Projekt>(projekt);
                dbctx.SaveChanges();
            }
        }
    }
}
