using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp14
{
    internal class film
    {
        public string ad { get; set; }
        public double gunlukKiraBedeli { get; set; }

        public film(string ad, double gunlukKiraBedeli)
        {
            this.ad = ad;
            this.gunlukKiraBedeli = gunlukKiraBedeli;
        }

    }
}
