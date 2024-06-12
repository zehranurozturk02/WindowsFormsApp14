using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    internal class dukkan
    {
        public List<film> filmler = new List<film>();
        public List<kiralanan_film> kiralanan_filmler = new List<kiralanan_film>();

        public const int baslangicKira = 3;

        public void filmleriYukle(string path, ListBox lb)//FİLMLERİ LİST BOXA YÜKLEDİM Kİ SEÇEBİLELİM.
        {
            StreamReader sr = new StreamReader(path);
            string eklenecek = sr.ReadLine();//ilk satırı okuduk
            while (eklenecek != null)// Dosyanın sonuna kadar oku
            {
                lb.Items.Add(eklenecek);//list boxa ekledik
                eklenecek = sr.ReadLine();//bir sonraki satırı okuduk ki while devam etsin
            }
        }

        public void filmEkle(string path, kiralanan_film film)//KİRALANAN FİLMİ DOSYAYA EKLER
        {
            StreamWriter streamWriter = new StreamWriter(path, true);
            streamWriter.WriteLine(film.kiralayan.ad + " " + film.kiralayan.soyad + " " + film.ad + " " + film.gunlukKiraBedeli);
            streamWriter.Close();
        }
        public void filmCıkar(string path, kiralanan_film film)
        {
            var lines = File.ReadAllLines(path).ToList();// Dosyadaki tüm satırları okuduk ve bunları bir listeye çevirdim.
            string filmStr = $"{film.kiralayan.ad} {film.kiralayan.soyad} {film.ad} {film.gunlukKiraBedeli}";
            lines.RemoveAll(line => line.Trim() == filmStr.Trim());//(lambda) Eşleşen satırları kaldırdık bu bir lambda ifadesidir.herbir satırı kontrol eder.
            File.WriteAllLines(path, lines);   //güncellenmiş veriyi tekrar dosyaya yazar                                       //eğer satır filmstr ile eşleşiyorsa bu satır listeden kaldırılır.
        }

    }
         
  
}

    

