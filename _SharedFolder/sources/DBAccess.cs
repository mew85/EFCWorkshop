using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADOTest.Lib.Models;
using Microsoft.Data.SqlClient;

namespace ADOTest.DBAccess
{
    public static class DBAccess
    {
        private static string sqlConnectionString = "Data Source=localhost;Initial Catalog=ADOTest;Integrated Security=true;TrustServerCertificate=Yes;Encrypt=False;";

        public static List<Abteilung> GetDBAbteilungsListe(string sqlStatement="select * from dbo.Abteilung;")
        {
            List<Abteilung> abtListe = new List<Abteilung>();
            using (SqlConnection con = new SqlConnection(sqlConnectionString))
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
                                Abteilung ab = new Abteilung()
                                {
                                    //Mapping mit den Properties der Klasse Abteilung
                                    AbteilungId = oReader.GetInt32(0),
                                    Abteilungsbezeichnung = oReader.GetString(1)
                                };
                                abtListe.Add(ab);
                            }
                        }
                    }
                }
            }
            return abtListe;
        }

        public static List<Mitarbeiter> GetDBMitarbeiterListe(string sqlStatement = "SELECT [mitarbeiterId], [nachname], [vorname], [geschlecht], [geburtsdatum], [funktionId], [abteilungId] FROM [dbo].[mitarbeiter];")
        {
            List<Mitarbeiter> mitListe = new List<Mitarbeiter>();
            using (SqlConnection con = new SqlConnection(sqlConnectionString))
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
                Geschlecht = (EGeschlecht)Enum.Parse(typeof(EGeschlecht), oReader.GetString(3)),
                Geburtsdatum = DateOnly.FromDateTime(oReader.GetDateTime(4)),                
                Funktion = fkt,
                Abteilung = abt
            };
            return mit;
        }
        

        public static dynamic GetValueFromTable(string table, string fieldname, string criterion)
        {
            dynamic wert="";
            string sqlStatement = "select " + fieldname + " from " + table + " where " + criterion;            
            using (SqlConnection con = new SqlConnection(sqlConnectionString))
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

            using (SqlConnection con = new SqlConnection(sqlConnectionString))
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
