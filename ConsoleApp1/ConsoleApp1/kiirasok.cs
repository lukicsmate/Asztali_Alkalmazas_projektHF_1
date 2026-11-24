using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    public class kiirasok
    {
        public static void inflacio()
        {
            string connString = "server=localhost;user=root;database=EU;port=3307;password=;";
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"
                    SELECT c.country_name, SUM(e.inflation) AS total_inflation
                    FROM economic_data e
                    JOIN countries c ON e.country_id = c.country_id
                    WHERE e.year >= YEAR(CURDATE()) - 15
                    GROUP BY c.country_name
                    ORDER BY c.country_name
                    ";
                    var res = cmd.ExecuteReader();
                    int index = 0;
                    while (res.Read())
                    {
                        string resString = res.GetString(index).ToString();
                        Console.WriteLine(resString);
                        index++;
                    }

                }
                conn.Close();
            }
        }
    }
}
