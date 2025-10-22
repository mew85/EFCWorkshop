using EFC01.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC01.ConsApp
{
    public class TestUpdate
    {
        public static void ÜberführeMitarbeiter()
        {
            //Mitarbieter in Abt. Geschäftsleitung/RW: Mitarbeiterinnen, die nicht Paul heißen

            using (var dbctx = new EFC01DBContext())
            {
                var maListeRw = dbctx.MitarbeiterListe
                    .Where(x => x.Abteilung.Abteilungsbezeichnung.Contains("Gesch") && x.Nachname != "Paul");

                var abtRW = dbctx.AbteilungListe
                    .Where(x => x.Abteilungsbezeichnung == "Rechnugswesen").FirstOrDefault();

                try
                {
                    foreach (var m in maListeRw.ToList())
                    {
                        m.Abteilung = abtRW;
                    }

                    dbctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Display(ex.Message);
                }
            }
        }
    }
}
