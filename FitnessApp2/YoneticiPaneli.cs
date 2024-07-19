using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessApp2
{
    public partial class YoneticiPaneli : Form
    {
        private readonly IYoneticiService _yoneticiService;
        private readonly IMusteriService _musteriService;

        private readonly IServiceProvider _serviceProvider;
        private readonly IEgitmenService _egitmenService;

        private readonly IPersonellerService _personelService;
        private readonly IPaketService _paketService;
        private readonly IPersonelService _girispersonelService;
        private readonly IGiderService _giderService;
        bool siderbarExpand;
        public YoneticiPaneli(IEgitmenService egitmenService, IPersonellerService personelService,
            IPaketService paketService, IYoneticiService yoneticiService, IServiceProvider serviceProvider, IPersonelService girispersonelService, IGiderService giderService, IMusteriService musteriService)
        {
            _giderService = giderService; // IGiderService bağımlılığını ata
            _musteriService = musteriService; // IMusteriService bağımlılığını ata

            _egitmenService = egitmenService;


            _paketService = paketService;


            _personelService = personelService;


            _girispersonelService = girispersonelService;
            _yoneticiService = yoneticiService;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            LoadEgitmenler();
            LoadPaketler();
            LoadPersoneller();
            groupBox3.Hide();
            dataGridView2.Hide();
            groupBox2.Hide();
            groupBox1.Hide();
            dataGridView1.Hide();
            dataGridView3.Hide();


        }
        private void LoadEgitmenler()
        {
            dataGridView2.DataSource = _egitmenService.GetAll();
        }
        private void LoadPaketler()
        {
            dataGridView3.DataSource = _paketService.GetAll();
        }
        private void LoadPersoneller()
        {
            dataGridView1.DataSource = _personelService.GetAll();
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void CalculateTotalPaketFiyati()
        {
            if (int.TryParse(textBox15.Text, out int aylikFiyat) && int.TryParse(comboBox1.SelectedItem.ToString(), out int aySayisi))
            {
                int toplamFiyat = aylikFiyat * aySayisi;
                label18.Text = toplamFiyat.ToString();
            }
        }



        private void button7_Click(object sender, EventArgs e)
        {
            var serviceProvider = _serviceProvider; // Service provider instance
            var musteriService = serviceProvider.GetService<IMusteriService>();
            var giderService = serviceProvider.GetService<IGiderService>();
            var egitmenService = serviceProvider.GetService<IEgitmenService>();

            var muhasebe = new Muhasebe(musteriService, giderService, egitmenService);
            muhasebe.Show();

        }

        private void button1_Click(object sender, EventArgs e) //egitmen ekleme
        {
            Egitmen egitmen = new Egitmen();
            egitmen.Ad = textBox1.Text;
            egitmen.Soyad = textBox2.Text;
            egitmen.Eposta = textBox3.Text;
            egitmen.TelefonNumarasi = textBox4.Text;
            egitmen.Uzmanlik = textBox5.Text;
            egitmen.Maas = Convert.ToDecimal(textBox7.Text);
            egitmen.Tarih = dateTimePicker1.Value;

            _egitmenService.Add(egitmen);
            LoadEgitmenler();
        }

        private void button2_Click(object sender, EventArgs e) //egitmen sil
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var egitmen = (Egitmen)dataGridView2.SelectedRows[0].DataBoundItem;
                _egitmenService.Delete(egitmen);
                LoadEgitmenler();
            }
        }

        private void button3_Click(object sender, EventArgs e) //egitmen guncelle
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var egitmen = (Egitmen)dataGridView2.SelectedRows[0].DataBoundItem;

                egitmen.Ad = textBox1.Text;
                egitmen.Soyad = textBox2.Text;
                egitmen.TelefonNumarasi = textBox3.Text;
                egitmen.Eposta = textBox4.Text;
                egitmen.Uzmanlik = textBox5.Text;
                egitmen.Maas = Convert.ToDecimal(textBox7.Text);
                egitmen.Tarih = dateTimePicker1.Value;
                _egitmenService.Update(egitmen);
                LoadEgitmenler();
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)//egitmen icin
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var egitmen = (Egitmen)dataGridView2.SelectedRows[0].DataBoundItem;

                textBox1.Text = egitmen.Ad;
                textBox2.Text = egitmen.Soyad;
                textBox3.Text = egitmen.TelefonNumarasi;
                textBox4.Text = egitmen.Eposta;
                textBox5.Text = egitmen.Uzmanlik;
                textBox7.Text = Convert.ToString(egitmen.Maas);
            }
        }

        private void button4_Click(object sender, EventArgs e)//paket ekle buton
        {
            Paket paket = new Paket();

            // Eğer comboBox2'de seçim yapılmamışsa ve textBox9 boş değilse, default değerler atayalım
            if (comboBox2.SelectedItem == null && !string.IsNullOrEmpty(textBox9.Text))
            {
                paket.OzelDers = "ozeldersalinmadi";
                paket.OzelDersFiyati = 0;
            }
            else
            {
                // Eğer comboBox2'de seçim yapılmışsa, o zaman değeri atayalım
                if (comboBox2.SelectedItem != null)
                {
                    paket.OzelDers = comboBox2.SelectedItem.ToString();
                }

                // textBox9'un boş olmadığından emin olalım ve değeri atayalım
                if (!string.IsNullOrEmpty(textBox9.Text))
                {
                    paket.OzelDersFiyati = Convert.ToDecimal(textBox9.Text);
                }
            }

            paket.Ay = int.Parse(comboBox1.SelectedItem.ToString());
            paket.AylikFiyat = int.Parse(textBox15.Text);
            paket.ToplamPaketFiyati = int.Parse(label18.Text);
            paket.PaketAdi = textBox6.Text;

            _paketService.Add(paket);
            LoadPaketler();
        }

        private void button12_Click(object sender, EventArgs e)//personel ekleme butonu
        {
            var personel = new Personel
            {
                Ad = textBox10.Text,
                Soyad = textBox11.Text,
                Telefon = textBox12.Text,
                Eposta = textBox13.Text,
                Gorev = textBox14.Text,
                Maas = Convert.ToDecimal(textBox8.Text)
            };

            _personelService.Add(personel);
            LoadPersoneller();
        }

        private void button11_Click(object sender, EventArgs e)//personel sil
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var personel = (Personel)dataGridView1.SelectedRows[0].DataBoundItem;
                _personelService.Delete(personel);
                LoadPersoneller();
            }
        }

        private void button10_Click(object sender, EventArgs e)//personel guncelle
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var personel = (Personel)dataGridView1.SelectedRows[0].DataBoundItem;

                personel.Ad = textBox10.Text;
                personel.Soyad = textBox11.Text;
                personel.Telefon = textBox12.Text;
                personel.Eposta = textBox13.Text;
                personel.Gorev = textBox14.Text;
                personel.Maas = Convert.ToDecimal(textBox8.Text);

                _personelService.Update(personel);
                LoadPersoneller();
            }
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)//paketler ııcb
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                var paketId = (int)dataGridView3.SelectedRows[0].Cells["Id"].Value;
                var paket = _paketService.GetAll().Find(p => p.Id == paketId);

                comboBox1.SelectedItem = paket.Ay.ToString();
                textBox15.Text = paket.AylikFiyat.ToString();
                label18.Text = paket.ToplamPaketFiyati.ToString();
                textBox6.Text = paket.PaketAdi;
                comboBox2.SelectedItem = paket.OzelDers;
                textBox9.Text = paket.OzelDersFiyati.ToString();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var personel = (Personel)dataGridView1.SelectedRows[0].DataBoundItem;

                textBox10.Text = personel.Ad;
                textBox11.Text = personel.Soyad;
                textBox12.Text = personel.Telefon;
                textBox13.Text = personel.Eposta;
                textBox14.Text = personel.Gorev;
            }
        }

        private void button6_Click(object sender, EventArgs e)//paket guncelleme 
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                var paketId = (int)dataGridView3.SelectedRows[0].Cells["Id"].Value;
                var paket = _paketService.GetAll().Find(p => p.Id == paketId);

                paket.Ay = int.Parse(comboBox1.SelectedItem.ToString());
                paket.AylikFiyat = int.Parse(textBox15.Text);
                paket.ToplamPaketFiyati = int.Parse(label18.Text);
                paket.PaketAdi = textBox6.Text;
                paket.OzelDers = comboBox2.SelectedItem.ToString();
                paket.OzelDersFiyati = Convert.ToDecimal(textBox9.Text);

                _paketService.Update(paket);
                LoadPaketler();
            }
        }

        private void button5_Click(object sender, EventArgs e) //paket sil 
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                var paketId = (int)dataGridView3.SelectedRows[0].Cells["Id"].Value;
                var paket = _paketService.GetAll().Find(p => p.Id == paketId);

                _paketService.Delete(paket);
                LoadPaketler();
            }
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotalPaketFiyati();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPaketFiyati();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var yoneticiGirisiYap = new YoneticiGirisiYap(_yoneticiService, _girispersonelService, _serviceProvider);
            yoneticiGirisiYap.Show();
            this.Close();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (siderbarExpand)
            {
                sidebar.Width -= 30;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    siderbarExpand = false;
                    timer1.Stop();
                }

            }
            else
            {
                sidebar.Width += 30;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    siderbarExpand = true;
                    timer1.Stop();
                }
            }
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void LoadMusteriler(DateTime selectedDate)
        {
            using (var context = new FitnessAppContext())
            {
                var result = from m in context.Musteri
                             where m.KayitTarihi.Day == selectedDate.Day
                             select new
                             {
                                 MusteriId = m.Id,
                                 Odeme = m.Odeme,
                                 KayitTarihi = m.KayitTarihi,
                                 PaketId = m.PaketlerId
                             };

                dataGridView4.DataSource = result.ToList();

            }
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker2.Value;
            LoadMusteriler(selectedDate);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            decimal toplamOdeme = 0;

            // DataGridView'deki her bir satırı döngü ile kontrol edin
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                // Satırın veri alanlarından ödeme miktarını alın
                if (row.Cells["Odeme"] != null && row.Cells["Odeme"].Value != null)
                {
                    decimal odemeMiktari;
                    if (decimal.TryParse(row.Cells["Odeme"].Value.ToString(), out odemeMiktari))
                    {
                        // Ödeme miktarını toplam değişkenine ekleyin
                        toplamOdeme += odemeMiktari;
                    }
                }
            }

            label23.Text = toplamOdeme.ToString();
        }
        private void ShowGroupBoxAtPosition(GroupBox groupBox, int x, int y)
        {
            groupBox.Location = new Point(x, y);
            groupBox.Show();
        }
        private void button13_Click(object sender, EventArgs e)
        {

            dataGridView4.Hide();
            pictureBox1.Hide();
            button16.Hide();
            dateTimePicker2.Hide();
            label22.Hide();
            groupBox3.Hide();
            dataGridView2.Hide();
            groupBox2.Hide();
            dataGridView3.Hide();
            groupBox1.Hide();
            label23.Hide();

            groupBox3.Show();
            dataGridView2.Show();
            ShowGroupBoxAtPosition(groupBox3, 259, 33);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            label23.Hide();
            dataGridView4.Hide();
            pictureBox1.Hide();
            button16.Hide();
            dateTimePicker2.Hide();
            label22.Hide();
            groupBox3.Hide();
            dataGridView2.Hide();
            groupBox3.Hide();
            groupBox2.Hide();
            dataGridView3.Hide();

            groupBox1.Show();
            dataGridView1.Show();
            ShowGroupBoxAtPosition(groupBox1, 259, 33);

        }

        private void button15_Click(object sender, EventArgs e)
        {
            label23.Hide();
            dataGridView4.Hide();
            pictureBox1.Hide();
            button16.Hide();
            dateTimePicker2.Hide();
            label22.Hide();
            groupBox3.Hide();
            dataGridView2.Hide();
            groupBox2.Show();
            dataGridView3.Show();
            ShowGroupBoxAtPosition(groupBox2, 259, 33);
        }


        private void button9_Click(object sender, EventArgs e)
        {


            groupBox3.Hide();
            dataGridView2.Hide();
            groupBox2.Hide();
            dataGridView3.Hide();
            dataGridView1.Hide();
            groupBox1.Hide();

            label23.Show();
            pictureBox1.Show();
            button16.Show();
            label22.Show();
            dataGridView4.Show();
            dateTimePicker2.Show();
        }

        private void YoneticiPaneli_Load(object sender, EventArgs e)
        {
            groupBox2.Show();
        }
    }
}
