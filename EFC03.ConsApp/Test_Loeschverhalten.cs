using EFC03.Lib.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC03.ConsApp
{
    internal class Test_Loeschverhalten
    {
        public static void LoescheMzuN()
        {
            string proj = "Scharfenstein";
            using (var dbctx = new Efc03Context())
            {
                var projekt = dbctx.ProjektListe.Where(p => p.Projektbezeichnung.Equals(proj)).FirstOrDefault();
                var mitprojListe = dbctx.ProjektmitarbeiterListe.Where(pm => pm.ProjektId.Equals(projekt!.ProjektId));

                List<int> mitarbeiterIds = new List<int>();

                foreach (var item in mitprojListe)
                {
                    Display($"{item.MitarbeiterId}");
                    Display($"{dbctx.Entry(item).State}");
                    var entityEntry = dbctx.ProjektmitarbeiterListe.Remove(item);
                    Display($"{entityEntry.State}");
                    mitarbeiterIds.Add(item.MitarbeiterId);

                }
                //Was passiert, wenn dieses Projekt gelöscht wird?
                try
                {
                    //Vor dem Löschen:
                    var mListe = dbctx.MitarbeiterListe.Where(m => mitarbeiterIds.Contains(m.MitarbeiterId));
                    foreach (var m in mListe)
                    { Display($"{m.MitarbeiterId}: {m.Nachname}"); }
                    //dbctx.SaveChanges();
                    //Display($"{entityEntry.State}");

                }
                catch (Exception ex)
                {
                    Display(ex.Message);
                }

            }
        }

        public static void LoescheMitarbeiter(int maId = 9)
        {
            using (var dbctx = new Efc03Context())
            {
                var ma = dbctx.MitarbeiterListe.Where(m => m.MitarbeiterId == maId).FirstOrDefault();

                dbctx.Remove<Mitarbeiter>(ma);
                dbctx.SaveChanges();
            }
        }
    }
}
