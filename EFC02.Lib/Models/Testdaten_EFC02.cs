using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using EFC02.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCTest02.Lib.Models
{
    public class Testdaten_EFC02
    {

        public static void TestdatenGenerierung_Niederlassung1(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Niederlassung>().HasData(
                new Niederlassung { NiederlassungId = 1, Niederlassungsbezeichnung = "Berlin", Niederlassungsvorwahl = "(030) 65756" },
                new Niederlassung { NiederlassungId = 2, Niederlassungsbezeichnung = "Frankfurt", Niederlassungsvorwahl = "(060) 345012" },
                new Niederlassung { NiederlassungId = 3, Niederlassungsbezeichnung = "Hamburg", Niederlassungsvorwahl = "(040) 1234" },
                new Niederlassung { NiederlassungId = 4, Niederlassungsbezeichnung = "München", Niederlassungsvorwahl = "(089) 54398" });
        }

        public static void TestdatenGenerierung_Niederlassung2(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Niederlassung>().HasData(
                new Niederlassung { NiederlassungId = 1, Niederlassungsbezeichnung = "Berlin", Niederlassungsvorwahl = "(030) 65756", AngelegtAm = new DateTime(2025,10,11,11,45,00), AngelegtVon = Environment.UserName, IstAktiv = true, IstGeloescht = false },
                new Niederlassung { NiederlassungId = 2, Niederlassungsbezeichnung = "Frankfurt", Niederlassungsvorwahl = "(060) 345012", AngelegtAm = new DateTime(2025, 10, 11, 11, 45, 00), AngelegtVon = Environment.UserName, IstAktiv = true, IstGeloescht = false },
                new Niederlassung { NiederlassungId = 3, Niederlassungsbezeichnung = "Hamburg", Niederlassungsvorwahl = "(040) 1234", AngelegtAm = new DateTime(2025, 10, 11, 11, 45, 00), AngelegtVon = Environment.UserName, IstAktiv = true, IstGeloescht = false },
                new Niederlassung { NiederlassungId = 4, Niederlassungsbezeichnung = "München", Niederlassungsvorwahl = "(089) 54398", AngelegtAm = new DateTime(2025, 10, 11, 11, 45, 00), AngelegtVon = Environment.UserName, IstAktiv = true, IstGeloescht = false});
        }

        public static void TestdatenGenerierung_Funktion(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funktion>().HasData(
                new Funktion { FunktionId = 1, Funktionsbezeichnung = "Berater/in" },
                new Funktion { FunktionId = 2, Funktionsbezeichnung = "Bereichsleiter/in" },
                new Funktion { FunktionId = 3, Funktionsbezeichnung = "Entwickler/in" },
                new Funktion { FunktionId = 4, Funktionsbezeichnung = "Freie/r Mitarbeiter/in" },
                new Funktion { FunktionId = 5, Funktionsbezeichnung = "Geschäftsführer/in" },
                new Funktion { FunktionId = 6, Funktionsbezeichnung = "Mitarbeiter/in" },
                new Funktion { FunktionId = 7, Funktionsbezeichnung = "Projektleiter/in" });
        }

        public static void TestdatenGenerierung_Abteilung(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Abteilung>().HasData(
                new Abteilung { AbteilungId = 1, Abteilungsbezeichnung = "Geschäftsleitung/RW" },
                new Abteilung { AbteilungId = 2, Abteilungsbezeichnung = "Infrastruktur" },
                new Abteilung { AbteilungId = 3, Abteilungsbezeichnung = "Marketing" },
                new Abteilung { AbteilungId = 4, Abteilungsbezeichnung = "Produktion" },
                new Abteilung { AbteilungId = 5, Abteilungsbezeichnung = "Vertrieb" });
        }


        public static void TestdatenGenerierung_Mitarbeiter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mitarbeiter>().HasData(
                new Mitarbeiter { MitarbeiterId = 1, Prsnr = "1001", Nachname = "Paul", Vorname = "Gabriele", Geschlecht = eGeschlecht.w, DatumEintritt = new DateOnly(2006, 01, 01), Extern = false, Email = "gpaul@projektdb.de", Durchwahl = "20", AbteilungId = 1, FunktionId = 5, NiederlassungId = 3, Geburtsdatum = new DateOnly(1993, 08, 23) },
                new Mitarbeiter { MitarbeiterId = 2, Prsnr = "1002", Nachname = "Unterlauf", Vorname = "Karin", Geschlecht = eGeschlecht.w, DatumEintritt = new DateOnly(2012, 05, 15), Extern = false, Email = "kunterlauf@projektdb.de", Durchwahl = "22", AbteilungId = 1, FunktionId = 6, NiederlassungId = 3, Geburtsdatum = new DateOnly(1970, 02, 06) },
                new Mitarbeiter { MitarbeiterId = 3, Prsnr = "1003", Nachname = "Schiefner", Vorname = "Emi", Geschlecht = eGeschlecht.w, DatumEintritt = new DateOnly(2010, 10, 01), Extern = false, Email = "eschiefner@projektdb.de", Durchwahl = "21", AbteilungId = 1, FunktionId = 6, NiederlassungId = 3, Geburtsdatum = new DateOnly(1980, 05, 14) },
                new Mitarbeiter { MitarbeiterId = 4, Prsnr = "1004", Nachname = "Geist", Vorname = "Ottmar", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2010, 10, 15), Extern = false, Email = "ogeist@projektdb.de", Durchwahl = "4567", AbteilungId = 2, FunktionId = 6, NiederlassungId = 2, Geburtsdatum = new DateOnly(1979, 05, 13) },
                new Mitarbeiter { MitarbeiterId = 5, Prsnr = "1005", Nachname = "Wendisch", Vorname = "Horst", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2006, 01, 02), Extern = false, Email = "hwendisch@projektdb.de", Durchwahl = "123", AbteilungId = 2, FunktionId = 6, NiederlassungId = 1, Geburtsdatum = new DateOnly(1981, 05, 14) },
                new Mitarbeiter { MitarbeiterId = 6, Prsnr = "1006", Nachname = "Koritz", Vorname = "Gundula", Geschlecht = eGeschlecht.w, DatumEintritt = new DateOnly(2006, 01, 03), Extern = false, Email = "gkoritz@projektdb.de", Durchwahl = "13", AbteilungId = 2, FunktionId = 5, NiederlassungId = 3, Geburtsdatum = new DateOnly(1985, 06, 16) },
                new Mitarbeiter { MitarbeiterId = 7, Prsnr = "1007", Nachname = "Lorenz", Vorname = "Kathrin", Geschlecht = eGeschlecht.w, DatumEintritt = new DateOnly(2006, 01, 17), Extern = false, Email = "klorenz@projektdb.de", Durchwahl = "35", AbteilungId = 3, FunktionId = 2, NiederlassungId = 3, Geburtsdatum = new DateOnly(1998, 10, 26) },
                new Mitarbeiter { MitarbeiterId = 8, Prsnr = "1008", Nachname = "Mühle", Vorname = "Andreas", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2006, 01, 18), Extern = false, Email = "amuehle@projektdb.de", Durchwahl = "36", AbteilungId = 3, FunktionId = 6, NiederlassungId = 3, Geburtsdatum = new DateOnly(1971, 03, 08) },
                new Mitarbeiter { MitarbeiterId = 9, Prsnr = "1009", Nachname = "Arendt", Vorname = "Sibylle", Geschlecht = eGeschlecht.w, DatumEintritt = new DateOnly(2006, 01, 01), Extern = false, Email = "sarendt@projektdb.de", Durchwahl = "234", AbteilungId = 4, FunktionId = 2, NiederlassungId = 1, Geburtsdatum = new DateOnly(1986, 07, 18) },
                new Mitarbeiter { MitarbeiterId = 10, Prsnr = "1010", Nachname = "Heinrich", Vorname = "Otto", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2020, 01, 01), Extern = false, Email = "oheinrich@projektdb.de", Durchwahl = "30", AbteilungId = 4, FunktionId = 6, NiederlassungId = 4, Geburtsdatum = new DateOnly(1979, 05, 13) },
                new Mitarbeiter { MitarbeiterId = 11, Prsnr = "1011", Nachname = "Rostig", Vorname = "Heidi", Geschlecht = eGeschlecht.w, DatumEintritt = new DateOnly(2006, 01, 01), Extern = false, Email = "hrostig@projektdb.de", Durchwahl = "12", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1993, 08, 23) },
                new Mitarbeiter { MitarbeiterId = 12, Prsnr = "1012", Nachname = "Gasch", Vorname = "Fritz", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2006, 01, 04), Extern = false, Email = "fgasch@projektdb.de", Durchwahl = "", AbteilungId = 4, FunktionId = 4, Geburtsdatum = new DateOnly(1979, 03, 15) },
                new Mitarbeiter { MitarbeiterId = 13, Prsnr = "1013", Nachname = "Schulze", Vorname = "Mathias", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2015, 10, 01), Extern = true, Email = "mschulze@projektdb.de", Durchwahl = "232", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1969, 02, 06) },
                new Mitarbeiter { MitarbeiterId = 14, Prsnr = "1014", Nachname = "Oehme", Vorname = "Ben", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2015, 10, 01), Extern = false, Email = "boehme@projektdb.de", Durchwahl = "4566", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1996, 09, 24) },
                new Mitarbeiter { MitarbeiterId = 15, Prsnr = "1015", Nachname = "Vettin", Vorname = "Konstantin", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2018, 10, 01), Extern = false, Email = "kvettin@projektdb.de", Durchwahl = "4568", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1969, 02, 05) },
                new Mitarbeiter { MitarbeiterId = 16, Prsnr = "1016", Nachname = "Kayser", Vorname = "Adel", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2018, 01, 13), Extern = false, Email = "akayser@projektdb.de", Durchwahl = "20", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1968, 02, 05) },
                new Mitarbeiter { MitarbeiterId = 17, Prsnr = "1017", Nachname = "Gorochow", Vorname = "Alexander", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2006, 01, 14), Extern = false, Email = "agorochow@projektdb.de", Durchwahl = "4567", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(2002, 11, 28) },
                new Mitarbeiter { MitarbeiterId = 18, Prsnr = "1018", Nachname = "O'Reilly", Vorname = "John", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2006, 01, 15), Extern = false, Email = "joreilley@projektdb.de", Durchwahl = "40", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(2000, 10, 27) },
                new Mitarbeiter { MitarbeiterId = 19, Prsnr = "1019", Nachname = "Kasischke", Vorname = "Mandy", Geschlecht = eGeschlecht.w, DatumEintritt = new DateOnly(2016, 01, 16), Extern = false, Email = "mkasischke@projektdb.de", Durchwahl = "233", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(2002, 11, 28) },
                new Mitarbeiter { MitarbeiterId = 20, Prsnr = "1020", Nachname = "Ozün", Vorname = "Mehmet", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2011, 01, 19), Extern = false, Email = "mozuen@projektdb.de", Durchwahl = "4569", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1981, 05, 14) },
                new Mitarbeiter { MitarbeiterId = 21, Prsnr = "1021", Nachname = "Kaykin", Vorname = "Zylfiye", Geschlecht = eGeschlecht.w, DatumEintritt = new DateOnly(2006, 01, 20), Extern = false, Email = "sboerner@projektdb.de", Durchwahl = "50", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1989, 07, 20) },
                new Mitarbeiter { MitarbeiterId = 22, Prsnr = "1022", Nachname = "Führ", Vorname = "Paul", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2006, 01, 21), Extern = false, Email = "pfuehr@projektdb.de", Durchwahl = "4570", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1989, 07, 20) },
                new Mitarbeiter { MitarbeiterId = 23, Prsnr = "1023", Nachname = "Roßberg", Vorname = "Katja", Geschlecht = eGeschlecht.w, DatumEintritt = new DateOnly(2006, 01, 22), Extern = false, Email = "krossberg@projektdb.de", Durchwahl = "4571", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(2002, 11, 28) },
                new Mitarbeiter { MitarbeiterId = 24, Prsnr = "1024", Nachname = "Cernij", Vorname = "Juri", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2010, 10, 01), Extern = false, Email = "jcernij@projektdb.de", Durchwahl = "234", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1976, 04, 11) },
                new Mitarbeiter { MitarbeiterId = 25, Prsnr = "1025", Nachname = "Feluscini", Vorname = "Giovanni", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2022, 10, 01), Extern = false, Email = "gfeluscini@projektdb.de", Durchwahl = "4572", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(2004, 11, 29) },
                new Mitarbeiter { MitarbeiterId = 26, Prsnr = "1026", Nachname = "Olzychovski", Vorname = "Marek", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2009, 10, 01), Extern = false, Email = "molzychovski@projektdb.de", Durchwahl = "14", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1980, 12, 04) },
                new Mitarbeiter { MitarbeiterId = 27, Prsnr = "1027", Nachname = "Fleurol", Vorname = "Francois", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2010, 10, 01), Extern = false, Email = "ffleurol@projektdb.de", Durchwahl = "15", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1995, 09, 23) },
                new Mitarbeiter { MitarbeiterId = 28, Prsnr = "1028", Nachname = "Piskun", Vorname = "Konstantin", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2010, 10, 01), Extern = false, Email = "kpiskun@projektdb.de", Durchwahl = "16", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1966, 01, 04) },
                new Mitarbeiter { MitarbeiterId = 29, Prsnr = "1029", Nachname = "Haase", Vorname = "Heinz", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2006, 01, 01), Extern = true, Email = "heinz@haase.de", Durchwahl = "", AbteilungId = 5, FunktionId = 4, Geburtsdatum = new DateOnly(2001, 11, 27) },
                new Mitarbeiter { MitarbeiterId = 30, Prsnr = "1030", Nachname = "Thurow", Vorname = "Gerald", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2006, 01, 01), Extern = true, Email = "gthurow@projektdb.de", Durchwahl = "33", AbteilungId = 5, FunktionId = 4, Geburtsdatum = new DateOnly(1991, 08, 21) },
                new Mitarbeiter { MitarbeiterId = 31, Prsnr = "1031", Nachname = "Fischer", Vorname = "Sonja", Geschlecht = eGeschlecht.w, DatumEintritt = new DateOnly(2010, 10, 01), Extern = false, Email = "sfischer@projektdb.de", Durchwahl = "124", AbteilungId = 5, FunktionId = 6, Geburtsdatum = new DateOnly(1979, 05, 13) },
                new Mitarbeiter { MitarbeiterId = 32, Prsnr = "1032", Nachname = "Schwienke", Vorname = "Hildegard", Geschlecht = eGeschlecht.w, DatumEintritt = new DateOnly(2010, 10, 01), Extern = false, Email = "hschwienke@projektdb.de", Durchwahl = "10", AbteilungId = 5, FunktionId = 6, Geburtsdatum = new DateOnly(1974, 03, 09) },
                new Mitarbeiter { MitarbeiterId = 33, Prsnr = "1033", Nachname = "Oltenbürstel", Vorname = "Erich", Geschlecht = eGeschlecht.m, DatumEintritt = new DateOnly(2010, 10, 01), Extern = false, Email = "eoltenbuerstel@projektdb.de", Durchwahl = "34", AbteilungId = 5, FunktionId = 2, Geburtsdatum = new DateOnly(1964, 01, 02) }
            );
        }

        ////public static void TestdatenGenerierung_Mitarbeiter(ModelBuilder modelBuilder)
        //{
        //      modelBuilder.Entity<Mitarbeiter>().HasData(
        //        new Mitarbeiter { MitarbeiterId = 1, Prsnr = "1001", Nachname = "Paul", Vorname = "Gabriele", Geschlecht = "w", DatumEintritt = new DateOnly(2006, 01, 01), Extern = true, Email = "gpaul@projektdb.de", Durchwahl = "20", AbteilungId = 1, FunktionId = 5, NiederlassungId = 3, Geburtsdatum = new DateOnly(1993, 08, 23) },
        //        new Mitarbeiter { MitarbeiterId = 2, Prsnr = "1002", Nachname = "Unterlauf", Vorname = "Karin", Geschlecht = "w", DatumEintritt = new DateOnly(2012, 05, 15), Extern = true, Email = "kunterlauf@projektdb.de", Durchwahl = "22", AbteilungId = 1, FunktionId = 6, NiederlassungId = 3, Geburtsdatum = new DateOnly(1970, 02, 06) },
        //        new Mitarbeiter { MitarbeiterId = 3, Prsnr = "1003", Nachname = "Schiefner", Vorname = "Emi", Geschlecht = "w", DatumEintritt = new DateOnly(2010, 10, 01), Extern = true, Email = "eschiefner@projektdb.de", Durchwahl = "21", AbteilungId = 1, FunktionId = 6, NiederlassungId = 3, Geburtsdatum = new DateOnly(1980, 05, 14) },
        //        new Mitarbeiter { MitarbeiterId = 4, Prsnr = "1004", Nachname = "Geist", Vorname = "Ottmar", Geschlecht = "m", DatumEintritt = new DateOnly(2010, 10, 15), Extern = true, Email = "ogeist@projektdb.de", Durchwahl = "4567", AbteilungId = 2, FunktionId = 6, NiederlassungId = 2, Geburtsdatum = new DateOnly(1979, 05, 13) },
        //        new Mitarbeiter { MitarbeiterId = 5, Prsnr = "1005", Nachname = "Wendisch", Vorname = "Horst", Geschlecht = "m", DatumEintritt = new DateOnly(2006, 01, 02), Extern = true, Email = "hwendisch@projektdb.de", Durchwahl = "123", AbteilungId = 2, FunktionId = 6, NiederlassungId = 1, Geburtsdatum = new DateOnly(1981, 05, 14) },
        //        new Mitarbeiter { MitarbeiterId = 6, Prsnr = "1006", Nachname = "Koritz", Vorname = "Gundula", Geschlecht = "w", DatumEintritt = new DateOnly(2006, 01, 03), Extern = true, Email = "gkoritz@projektdb.de", Durchwahl = "13", AbteilungId = 2, FunktionId = 5, NiederlassungId = 3, Geburtsdatum = new DateOnly(1985, 06, 16) },
        //        new Mitarbeiter { MitarbeiterId = 7, Prsnr = "1007", Nachname = "Lorenz", Vorname = "Kathrin", Geschlecht = "w", DatumEintritt = new DateOnly(2006, 01, 17), Extern = true, Email = "klorenz@projektdb.de", Durchwahl = "35", AbteilungId = 3, FunktionId = 2, NiederlassungId = 3, Geburtsdatum = new DateOnly(1998, 10, 26) },
        //        new Mitarbeiter { MitarbeiterId = 8, Prsnr = "1008", Nachname = "Mühle", Vorname = "Andreas", Geschlecht = "m", DatumEintritt = new DateOnly(2006, 01, 18), Extern = true, Email = "amuehle@projektdb.de", Durchwahl = "36", AbteilungId = 3, FunktionId = 6, NiederlassungId = 3, Geburtsdatum = new DateOnly(1971, 03, 08) },
        //        new Mitarbeiter { MitarbeiterId = 9, Prsnr = "1009", Nachname = "Arendt", Vorname = "Sibylle", Geschlecht = "w", DatumEintritt = new DateOnly(2006, 01, 01), Extern = true, Email = "sarendt@projektdb.de", Durchwahl = "234", AbteilungId = 4, FunktionId = 2, NiederlassungId = 1, Geburtsdatum = new DateOnly(1986, 07, 18) },
        //        new Mitarbeiter { MitarbeiterId = 10, Prsnr = "1010", Nachname = "Heinrich", Vorname = "Otto", Geschlecht = "m", DatumEintritt = new DateOnly(2020, 01, 01), Extern = true, Email = "oheinrich@projektdb.de", Durchwahl = "30", AbteilungId = 4, FunktionId = 6, NiederlassungId = 4, Geburtsdatum = new DateOnly(1979, 05, 13) },
        //        new Mitarbeiter { MitarbeiterId = 11, Prsnr = "1011", Nachname = "Rostig", Vorname = "Heidi", Geschlecht = "w", DatumEintritt = new DateOnly(2006, 01, 01), Extern = false, Email = "hrostig@projektdb.de", Durchwahl = "12", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1993, 08, 23) },
        //        new Mitarbeiter { MitarbeiterId = 12, Prsnr = "1012", Nachname = "Gasch", Vorname = "Fritz", Geschlecht = "m", DatumEintritt = new DateOnly(2006, 01, 04), Extern = false, Email = "fgasch@projektdb.de", Durchwahl = "", AbteilungId = 4, FunktionId = 4, Geburtsdatum = new DateOnly(1979, 03, 15) },
        //        new Mitarbeiter { MitarbeiterId = 13, Prsnr = "1013", Nachname = "Schulze", Vorname = "Mathias", Geschlecht = "m", DatumEintritt = new DateOnly(2015, 10, 01), Extern = true, Email = "mschulze@projektdb.de", Durchwahl = "232", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1969, 02, 06) },
        //        new Mitarbeiter { MitarbeiterId = 14, Prsnr = "1014", Nachname = "Oehme", Vorname = "Ben", Geschlecht = "m", DatumEintritt = new DateOnly(2015, 10, 01), Extern = false, Email = "boehme@projektdb.de", Durchwahl = "4566", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1996, 09, 24) },
        //        new Mitarbeiter { MitarbeiterId = 15, Prsnr = "1015", Nachname = "Vettin", Vorname = "Konstantin", Geschlecht = "m", DatumEintritt = new DateOnly(2018, 10, 01), Extern = false, Email = "kvettin@projektdb.de", Durchwahl = "4568", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1969, 02, 05) },
        //        new Mitarbeiter { MitarbeiterId = 16, Prsnr = "1016", Nachname = "Kayser", Vorname = "Adel", Geschlecht = "m", DatumEintritt = new DateOnly(2018, 01, 13), Extern = false, Email = "akayser@projektdb.de", Durchwahl = "20", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1968, 02, 05) },
        //        new Mitarbeiter { MitarbeiterId = 17, Prsnr = "1017", Nachname = "Gorochow", Vorname = "Alexander", Geschlecht = "m", DatumEintritt = new DateOnly(2006, 01, 14), Extern = false, Email = "agorochow@projektdb.de", Durchwahl = "4567", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(2002, 11, 28) },
        //        new Mitarbeiter { MitarbeiterId = 18, Prsnr = "1018", Nachname = "O'Reilly", Vorname = "John", Geschlecht = "m", DatumEintritt = new DateOnly(2006, 01, 15), Extern = false, Email = "joreilley@projektdb.de", Durchwahl = "40", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(2000, 10, 27) },
        //        new Mitarbeiter { MitarbeiterId = 19, Prsnr = "1019", Nachname = "Kasischke", Vorname = "Mandy", Geschlecht = "w", DatumEintritt = new DateOnly(2016, 01, 16), Extern = false, Email = "mkasischke@projektdb.de", Durchwahl = "233", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(2002, 11, 28) },
        //        new Mitarbeiter { MitarbeiterId = 20, Prsnr = "1020", Nachname = "Ozün", Vorname = "Mehmet", Geschlecht = "m", DatumEintritt = new DateOnly(2011, 01, 19), Extern = false, Email = "mozuen@projektdb.de", Durchwahl = "4569", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1981, 05, 14) },
        //        new Mitarbeiter { MitarbeiterId = 21, Prsnr = "1021", Nachname = "Kaykin", Vorname = "Zylfiye", Geschlecht = "w", DatumEintritt = new DateOnly(2006, 01, 20), Extern = false, Email = "sboerner@projektdb.de", Durchwahl = "50", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1989, 07, 20) },
        //        new Mitarbeiter { MitarbeiterId = 22, Prsnr = "1022", Nachname = "Führ", Vorname = "Paul", Geschlecht = "m", DatumEintritt = new DateOnly(2006, 01, 21), Extern = false, Email = "pfuehr@projektdb.de", Durchwahl = "4570", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1989, 07, 20) },
        //        new Mitarbeiter { MitarbeiterId = 23, Prsnr = "1023", Nachname = "Roßberg", Vorname = "Katja", Geschlecht = "w", DatumEintritt = new DateOnly(2006, 01, 22), Extern = false, Email = "krossberg@projektdb.de", Durchwahl = "4571", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(2002, 11, 28) },
        //        new Mitarbeiter { MitarbeiterId = 24, Prsnr = "1024", Nachname = "Cernij", Vorname = "Juri", Geschlecht = "m", DatumEintritt = new DateOnly(2010, 10, 01), Extern = false, Email = "jcernij@projektdb.de", Durchwahl = "234", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1976, 04, 11) },
        //        new Mitarbeiter { MitarbeiterId = 25, Prsnr = "1025", Nachname = "Feluscini", Vorname = "Giovanni", Geschlecht = "m", DatumEintritt = new DateOnly(2022, 10, 01), Extern = false, Email = "gfeluscini@projektdb.de", Durchwahl = "4572", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(2004, 11, 29) },
        //        new Mitarbeiter { MitarbeiterId = 26, Prsnr = "1026", Nachname = "Olzychovski", Vorname = "Marek", Geschlecht = "m", DatumEintritt = new DateOnly(2009, 10, 01), Extern = false, Email = "molzychovski@projektdb.de", Durchwahl = "14", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1980, 12, 04) },
        //        new Mitarbeiter { MitarbeiterId = 27, Prsnr = "1027", Nachname = "Fleurol", Vorname = "Francois", Geschlecht = "m", DatumEintritt = new DateOnly(2010, 10, 01), Extern = false, Email = "ffleurol@projektdb.de", Durchwahl = "15", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1995, 09, 23) },
        //        new Mitarbeiter { MitarbeiterId = 28, Prsnr = "1028", Nachname = "Piskun", Vorname = "Konstantin", Geschlecht = "m", DatumEintritt = new DateOnly(2010, 10, 01), Extern = false, Email = "kpiskun@projektdb.de", Durchwahl = "16", AbteilungId = 4, FunktionId = 6, Geburtsdatum = new DateOnly(1966, 01, 04) },
        //        new Mitarbeiter { MitarbeiterId = 29, Prsnr = "1029", Nachname = "Haase", Vorname = "Heinz", Geschlecht = "m", DatumEintritt = new DateOnly(2006, 01, 01), Extern = true, Email = "heinz@haase.de", Durchwahl = "", AbteilungId = 5, FunktionId = 4, Geburtsdatum = new DateOnly(2001, 11, 27) },
        //        new Mitarbeiter { MitarbeiterId = 30, Prsnr = "1030", Nachname = "Thurow", Vorname = "Gerald", Geschlecht = "m", DatumEintritt = new DateOnly(2006, 01, 01), Extern = true, Email = "gthurow@projektdb.de", Durchwahl = "33", AbteilungId = 5, FunktionId = 4, Geburtsdatum = new DateOnly(1991, 08, 21) },
        //        new Mitarbeiter { MitarbeiterId = 31, Prsnr = "1031", Nachname = "Fischer", Vorname = "Sonja", Geschlecht = "w", DatumEintritt = new DateOnly(2010, 10, 01), Extern = false, Email = "sfischer@projektdb.de", Durchwahl = "124", AbteilungId = 5, FunktionId = 6, Geburtsdatum = new DateOnly(1979, 05, 13) },
        //        new Mitarbeiter { MitarbeiterId = 32, Prsnr = "1032", Nachname = "Schwienke", Vorname = "Hildegard", Geschlecht = "w", DatumEintritt = new DateOnly(2010, 10, 01), Extern = false, Email = "hschwienke@projektdb.de", Durchwahl = "10", AbteilungId = 5, FunktionId = 6, Geburtsdatum = new DateOnly(1974, 03, 09) },
        //        new Mitarbeiter { MitarbeiterId = 33, Prsnr = "1033", Nachname = "Oltenbürstel", Vorname = "Erich", Geschlecht = "m", DatumEintritt = new DateOnly(2010, 10, 01), Extern = false, Email = "eoltenbuerstel@projektdb.de", Durchwahl = "34", AbteilungId = 5, FunktionId = 2, Geburtsdatum = new DateOnly(1964, 01, 02) }
        //    );
        //}


    }
}
