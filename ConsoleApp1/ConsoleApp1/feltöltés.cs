using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    public class feltöltés
    {
        public static void mysqlFeltöltés(List<demographics> demographicsList, List<economics> economicsList)
        {
            string connString = "server=localhost;user=root;database=EU;port=3307;password=;";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    foreach (var demographics in demographicsList)
                    {
                        string country = demographics.Country.ToString();
                        int year = demographics.Year;
                        int population = demographics.Population;
                        cmd.CommandText = "INSERT IGNORE INTO countries(country_name) VALUES(@Country)";
                        cmd.Parameters.AddWithValue("Country",country);
                        cmd.ExecuteNonQuery();


                        cmd.Parameters.Clear();
                    }
                    foreach (var economic in economicsList)
                    {
                        string country = economic.Country.ToString();
                        cmd.CommandText = "INSERT IGNORE INTO countries(country_name) VALUES(@Country)";
                        cmd.Parameters.AddWithValue("Country", country);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    foreach(var demograph in demographicsList)
                    {
                        int year = demograph.Year;
                        int population = demograph.Population;
                        var countryId = countrySelect(demograph.Country,conn);
                        cmd.CommandText = "INSERT IGNORE INTO demographic_data(country_id,year,population) VALUES(@countryId,@year,@population)";
                        cmd.Parameters.AddWithValue("countryId", countryId);
                        cmd.Parameters.AddWithValue("year", year);
                        cmd.Parameters.AddWithValue("population", population);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }




                }
            }
        }
        public static int countrySelect(string countryName,MySqlConnection conn)
        {
            int id = -1;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection= conn;
                cmd.CommandText = "SELECT id FROM countries WHERE country_name = @country";
                cmd.Parameters.AddWithValue("country",countryName);
                var select = cmd.ExecuteScalar();
                id = int.Parse(select.ToString());
                cmd.Parameters.Clear();
            }
            
            return id;
        }
    }
}
