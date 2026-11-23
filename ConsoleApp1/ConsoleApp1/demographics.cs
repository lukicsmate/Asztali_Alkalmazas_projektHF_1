using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class demographics
    {
        public int Year { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
        public demographics(int year,string country,int population)
        {
            this.Population = population;
            this.Year = year;
            this.Country = country;
        }
    }
}
