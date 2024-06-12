using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form1 : Form
    {
        public dynamic dataGrid;
        dukkan dukkan = new dukkan();

        public Form1()
        {
            InitializeComponent();
            dataGrid = dataGridView1;

            dukkan.filmleriYukle("C:\\Users\\Huaweı\\Desktop\\dükkandaki_filmler.txt", listBox1);//form başlatıldığında dosyadaki filmleri  listboxa yükler
        }

        //kirala butonu
        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text; //textboxtan verileri alıyoruz
            string soyad = textBox2.Text;
            int gun = Convert.ToInt32(textBox3.Text);

            DataGridViewRow row = new DataGridViewRow();

            kisi user = new kisi(ad, soyad);
            var selectedMovie = listBox1.SelectedItem; //mevcut filmler listboxundan seçilen filmi almaya yarar.

            if (selectedMovie == null)//eğer bir film seçilmediyse lütfen film seçin mesajı verir
            {
                MessageBox.Show("Lütfen bir film seçin!");
                return;
            }


            var arrayFormOfMovie = selectedMovie.ToString().Split(' ');
            string fiyat = arrayFormOfMovie[arrayFormOfMovie.Length - 1];
            dynamic movieName = "";
            for (int i = 0; i < arrayFormOfMovie.Length - 1; i++) //fiyat hariç filmin isimini aldık o yüzden -1 dedik.
            {
                movieName += arrayFormOfMovie[i] + " ";
            }

            if (dukkan.kiralanan_filmler.Any(kf => kf.ad.Trim() == movieName.Trim())) //kiralanan filmler listsinde kiralanmış film varmı diye kontrol ettik
            {                                                                        //any listenin herhangi bir elemanın koşulu sağlayıp sağlamadığını kontrol eder.
                MessageBox.Show("Bu film zaten kiralanmış!");
                return;
            }

            kiralanan_film kiralananFilm = new kiralanan_film(user, dukkan.baslangicKira)
            {
                //kiralananfilm nesnesi oluşturduk ve nesnenin özelliklerinide aşağıda tanımladık.
                ad = movieName.Trim(), //filmin adı
                gunlukKiraBedeli = Convert.ToInt32(fiyat)
            };


            row.CreateCells(dataGrid); //datagridview için yeni bir satır 

            int day = Convert.ToInt32(textBox3.Text);

            dukkan.filmEkle("alinan_filmler.txt", kiralananFilm);//kiralanan filmlerin bilgileri bir dosyaya eklenir
            dukkan.kiralanan_filmler.Add(kiralananFilm);//kiralanan filmler listsine bir kiralanan film nesnesi ekledik


            //datagridview hücrelerini doldurduk
            row.Cells[0].Value = movieName;
            row.Cells[1].Value = user.ad + " " + user.soyad;
            row.Cells[2].Value = day * Convert.ToInt32(fiyat);
            dataGrid.Rows.Add(row);//datagridviewe eklenir böylece kullanıcıya gösterilmiş olur
        } // kirala butonu sonu


        // temizleme butonu
        private void button2_Click(object sender, EventArgs e)
        {
            dataGrid.Rows.Clear();

        }

        //kiralıktan çıkarma butonu
        private void button3_Click(object sender, EventArgs e)
        {
            var selectedMovie = listBox1.SelectedItem;//listboxtan film seçilip seçilmediğine bakıyoruz.

            //eğer seçilmemisse bir uyarı verir.
            if (selectedMovie == null)
            {
                MessageBox.Show("Lütfen bir film seçin!");
                return;
            }

            var arrayFormOfMovie = selectedMovie.ToString().Split(' ');
            dynamic movieName = "";
            //filmin son parçası hariç diğerlerinin birleştiriyoruz sadece ismi kalıyor
            for (int i = 0; i < arrayFormOfMovie.Length - 1; i++)
            {
                movieName += arrayFormOfMovie[i] + " ";
            }
            movieName = movieName.Trim();//sağında ve solundaki boşlukları sildik


            var kiralananFilm = dukkan.kiralanan_filmler.FirstOrDefault(kf => kf.ad == movieName);//kiralanan filmler içindeki her bir film için moviename eşleşip eşleşmediğini kontrol eder


            if (kiralananFilm == null)
            {
                MessageBox.Show("Bu film zaten kiralık değil!");
                return;
            }

            dukkan.kiralanan_filmler.Remove(kiralananFilm);//kiralanan filmler listsinden seçilen film kaldırılır
            dukkan.filmCıkar("alinan_filmler.txt", kiralananFilm);//alinanfilmler.txt dosyasından da kaldırılır

            MessageBox.Show($"{movieName} adlı film kiralananlar listesinden çıkarıldı.");
        }
    }
}

