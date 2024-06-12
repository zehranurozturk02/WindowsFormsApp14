using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp14
{
    internal class kiralanan_film : film
    {
        public kisi kiralayan { get; set; }//kiralayan kişinin bilgilerini tutar
        public film kiralananFilm { get; set; }//kiralanan filmi tutar
        public int kiraBedeli { get; set; }//kira bedeli
        public kiralanan_film(kisi ad, int kira) : base(ad.ad, kira)
        {//base film sınıfının kurucu metodunu çağırır
            this.kiralayan = ad;
            this.kiraBedeli = kira;
        }

        public double tutar(int gun)
        {
            return gun * kiraBedeli;
        }


    }
}
