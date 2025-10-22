using ADOTEST.Lib.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOTest.DBAccess
{
    public class DBAccess
    {
        private static string _sqlConnectionString = "data source=SQL-SRV1;initial catalog=ADOTest;integrated security=True;persist security info=True; TrustServerCertificate=True; Encrypt=False";

        public static List<Abteilung> GetDbAbteilungsliste(string sqlStatement = "select * from dbo.abteilung")
        {
            List<Abteilung> abteilungsListe = new List<Abteilung>();

            using (var con = new SqlConnection(_sqlConnectionString))
            {
                try
                {
                    con.Open();
                    using (var cmd = new SqlCommand(sqlStatement, con)) 
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    Abteilung abt = new Abteilung(); //Mapping

                                    abt.AbteilungId = reader.GetInt32(0);
                                    abt.Abteilungsbezeichnung = reader.GetString(1);
                                    abteilungsListe.Add(abt);
                                }
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw;
                }
            }

            return abteilungsListe;
        }

        public static List<Mitarbeiter> GetDBMitarbeiterListe(string sqlStatement = "SELECT [mitarbeiterId], [nachname], [vorname], [geschlecht], [geburtsdatum], [funktionId], [abteilungId] FROM [dbo].[mitarbeiter];")
        {
            List<Mitarbeiter> mitListe = new List<Mitarbeiter>();
            using (SqlConnection con = new SqlConnection(_sqlConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(sqlStatement, con))
                {
                    using (SqlDataReader oReader = cmd.ExecuteReader())
                    {
                        if (oReader.HasRows)
                        {
                            while (oReader.Read())
                            {
                                Mitarbeiter mit = GetMitarbeiter(oReader);
                                mitListe.Add(mit);
                            }
                        }
                    }
                }
            }
            return mitListe;
        }
        /// <summary>
        /// Hilfsfunktion: Mapping der Mitarbeitertabelle und der Mitarbeiterklasse
        /// </summary>
        /// <param name="oReader"></param>
        /// <returns></returns>
        private static Mitarbeiter GetMitarbeiter(SqlDataReader oReader)
        {
            Funktion fkt = new Funktion();
            fkt.FunktionId = oReader.GetInt32(5);
            fkt.Funktionsbezeichnung = GetValueFromTable("Funktion", "Funktionsbezeichnung", "FunktionId=" + fkt.FunktionId.ToString());
            Abteilung abt = new Abteilung();
            abt.AbteilungId = oReader.GetInt32(6);
            abt.Abteilungsbezeichnung = GetValueFromTable("Abteilung", "Abteilungsbezeichnung", "AbteilungId=" + abt.AbteilungId.ToString());


            Mitarbeiter mit = new Mitarbeiter()
            {
                MitarbeiterId = oReader.GetInt32(0),
                Nachname = oReader.GetString(1),
                Vorname = oReader.GetString(2),
                Geschlecht = oReader.GetString(3),
                Geburtsdatum = DateOnly.FromDateTime(oReader.GetDateTime(4)),
                Funktion = fkt,
                Abteilung = abt
            };
            return mit;
        }

        public static dynamic GetValueFromTable(string table, string fieldname, string criterion)
        {
            dynamic wert = "";
            string sqlStatement = "select " + fieldname + " from " + table + " where " + criterion;
            using (SqlConnection con = new SqlConnection(_sqlConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sqlStatement, con))
                {
                    using (SqlDataReader oReader = cmd.ExecuteReader())
                    {
                        if (fieldname != null)
                        {
                            if (oReader.HasRows)
                            {
                                while (oReader.Read())
                                {
                                    if (fieldname.ToLower().Contains("id"))
                                        wert = oReader.GetInt32(0);
                                    else
                                        wert = oReader.GetString(0);
                                }
                            }
                        }
                    }
                }
                return wert;
            }
        }

        public static string ExecuteNonQuery(string sqlStatement)
        {
            int nRows = 0;
            string msg = string.Empty;

            using (SqlConnection con = new SqlConnection(_sqlConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sqlStatement, con))
                {
                    try
                    {
                        nRows = cmd.ExecuteNonQuery();
                        msg = string.Format($"Es sind {nRows} Datensätze betroffen");
                    }
                    catch (Exception ex)
                    {
                        msg += "\n" + ex.Message.ToString();
                    }
                }
            }
            return msg;
        }
    }
}
