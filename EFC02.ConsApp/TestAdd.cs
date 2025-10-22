using EFC02.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC02.ConsApp
{
    public class TestAdd
    {
        public static void AddNiederlassung()
        {
            TestAbfragen.GetNiederlassungsListeStd();

            using (var dbctx = new EFC02DBContext())
            {
                try
                {
                    Niederlassung newNl = new Niederlassung() { Niederlassungsbezeichnung = "Münster", Niederlassungsvorwahl = "0251"};

                    //neue Abteilung dem DbSet-Liste nobjekt hinzufügen
                    dbctx.NiederlassungListe.Add(newNl);
                    dbctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            Display("Neu:");
            TestAbfragen.GetNiederlassungsListeStd();
        }
    }
}
