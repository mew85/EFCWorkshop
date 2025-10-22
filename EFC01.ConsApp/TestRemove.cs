using EFC01.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC01.ConsApp
{
    public class TestRemove
    {
        public static void RemoveAbteilung()
        {
            using (var dbctx = new EFC01DBContext())
            {
                var abtToRemove = dbctx.AbteilungListe
                    .Where(x => x.Abteilungsbezeichnung.Contains("Buchhaltung"))
                    .FirstOrDefault();

                if (abtToRemove != null)
                {
                    try
                    {
                        dbctx.AbteilungListe.Remove(abtToRemove);
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
}
