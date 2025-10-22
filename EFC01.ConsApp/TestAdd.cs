using EFC01.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC01.ConsApp
{
    public class TestAdd
    {
        public static void AddAbteilung(Abteilung newAbt)
        {
            using (var dbctx = new EFC01DBContext())
            {
                try
                {
                    //neue Abteilung dem DbSet-Liste nobjekt hinzufügen
                    dbctx.AbteilungListe.Add(newAbt);
                    dbctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
