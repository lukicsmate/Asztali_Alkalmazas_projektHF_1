using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class economics
    {
        public int Year { get; set; }
        public string Country { get; set; }
        public double Gdp_growth {  get; set; }
        public double Inflation { get; set; }
        public economics(int year,string country, double gdp_growth, double inflation) 
        {
            this.Year = year;
            this.Country = country;
            this.Gdp_growth = gdp_growth;
            this.Inflation = inflation;
        }
    }
}
