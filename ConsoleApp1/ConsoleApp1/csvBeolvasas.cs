using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    public class csvBeolvasas
    {
        public static List<demographics> demographicsCSV()
        {
            var demographicsList = new List<demographics>();
            using (StreamReader sr = new StreamReader("eu_demographics_data.csv"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var sor = sr.ReadLine();
                    var split = sor.Split(',');
                    int year = int.Parse(split[0].ToString());
                    string country = split[1].ToString();
                    int population = int.Parse(split[2].ToString());
                    demographics demographics = new demographics(year,country,population);
                    demographicsList.Add(demographics);
                }
            }
            return demographicsList;
        }
        public static List<economics> economicsCSV()
        {
            var economicsList = new List<economics>();
            using (StreamReader sr = new StreamReader("eu_economics_data.csv"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var sor = sr.ReadLine();
                    var split = sor.Split(',');
                    int year = int.Parse(split[0].ToString());
                    string country = split[1].ToString();
                    double GDP = double.Parse(split[2].ToString(),CultureInfo.InvariantCulture);
                    double inflation = double.Parse(split[3].ToString(),CultureInfo.InvariantCulture);
                    economics economics= new economics(year, country, GDP,inflation);
                    economicsList.Add(economics);
                }
            }
            return economicsList;
        }
    }
}
