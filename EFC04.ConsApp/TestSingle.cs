using EFC04.Lib.Models.Single;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC04.ConsApp
{
    public class TestSingle
    {
        private static Kunde GetKunde()
        {
            Kunde k = new Kunde()
            {
                Nachname = "Paul",
                Vorname = "Gabriele",
                Geschlecht = "w",
                Kundeseit = new DateOnly(2021,6,12)
            };

            KundeDetails kd = new KundeDetails()
            {
                Kunde = k,
                Telefon = "+49 1234 888447",
                Email = "GPaul@testmail.com"
            };
            k.Kundedetails = kd;

            Adresse a = new Adresse()
            {
                KundeDetails = kd,
                Strasse = "Adressweg",
                Hausnummer = "55",
                Plz = "12345",
                Ort = "Musterort"
            };
            kd.Anschrift = a;

            return k;
        }

        public static void SetKunde()
        {
            using (var ctx = new EFC04_SingleDBContext())
            {
                Kunde k = new Kunde()
                {
                    Nachname = "Paul",
                    Vorname = "Gabriele",
                    Geschlecht = "w",
                    Kundeseit = new DateOnly(2021, 6, 12)
                };
                ctx.KundeListe.Add(k);
                ctx.SaveChanges();

                KundeDetails kd = new KundeDetails()
                {
                    Kunde = k,
                    KundeId = k.KundeId,
                    Telefon = "+49 1234 888447",
                    Email = "GPaul@testmail.com"
                };
                k.Kundedetails = kd;

                ctx.KundeDetailsListe.Add(kd);
                ctx.SaveChanges();

                Adresse a = new Adresse()
                {
                    KundeDetails = kd,
                    KundeDetailsId = kd.KundeDetailsId,
                    Strasse = "Adressweg",
                    Hausnummer = "55",
                    Plz = "12345",
                    Ort = "Musterort"
                };
                kd.Anschrift = a;

                ctx.AdresseListe.Add(a);
                ctx.SaveChanges();
            }
        }
    }
}
