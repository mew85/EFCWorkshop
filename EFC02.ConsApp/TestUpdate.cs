using EFC02.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC02.ConsApp
{
    public class TestUpdate
    {
        public static void ÄndereNiederlassung()
        {
            //Mitarbieter in Abt. Geschäftsleitung/RW: Mitarbeiterinnen, die nicht Paul heißen

            using (var dbctx = new EFC02DBContext())
            {
                //var maOhneNl = dbctx.MitarbeiterListe
                //    .Where(x => x.Niederlassung == null);

                var NlMs = dbctx.NiederlassungListe
                    .Where(x => x.Niederlassungsbezeichnung == "Münster").FirstOrDefault();

                //Update von MA
                //try
                //{
                //    foreach (var m in maOhneNl.ToList())
                //    {
                //        m.Niederlassung = NlMs;
                //    }

                //    dbctx.SaveChanges();
                //}
                //catch (Exception ex)
                //{
                //    Display(ex.Message);
                //}

                try
                {
                    NlMs.GeaendertVon = "ME";
                    NlMs.GeaendertAm = DateTime.Now;
                    NlMs.Niederlassungsvorwahl = "(0251) 1234";

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
