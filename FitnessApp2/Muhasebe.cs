using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FitnessApp2
{
    public partial class Muhasebe : Form
    {
        private readonly IMusteriService _musteriService;
        private readonly IGiderService _giderService;
        private readonly IEgitmenService _egitmenService;
        private readonly IPaketService _paketService;
        private readonly IPersonellerService _personellerService;
        private readonly IYoneticiService _yoneticiService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IPersonelService personelService;




        public Muhasebe(IMusteriService musteriService, IGiderService giderService, IEgitmenService egitmenService)
        {
            _musteriService = musteriService;
            _giderService = giderService;
            _egitmenService = egitmenService;
            InitializeComponent();


        }
        private void LoadEgitmenler()
        {
            using (var context = new FitnessAppContext())
            {
                var result = from e in context.Egitmen
                             select new
                             {
                                 EgitmenId = e.Id,
                                 EgitmenMaas = e.Maas
                             };

                dataGridView5.DataSource = result.ToList();

            }
        }
        private void LoadPersoneller()
        {
            using (var context = new FitnessAppContext())
            {
                var result = from e in context.Personel
                             select new
                             {
                                 PersonelId = e.Id,
                                 PersonelMaas = e.Maas
                             };

                dataGridView4.DataSource = result.ToList();

            }
        }
        private void LoadPaketler(DateTime selectedDate)
        {
            using (var context = new FitnessAppContext())
            {
                var result = from m in context.Musteri
                             where m.KayitTarihi >= selectedDate
                             select new
                             {
                                 MusteriId = m.Id,
                                 Odeme = m.Odeme,
                                 KayitTarihi = m.KayitTarihi,
                                 PaketId = m.PaketlerId
                             };

                dataGridView1.DataSource = result.ToList();

            }
        }

        private void button1_Click(object sender, EventArgs e)//gelir listele
        {

            DateTime selectedDate = dateTimePicker3.Value.Date;
            LoadPaketler(selectedDate);
        }

        private void button3_Click(object sender, EventArgs e)//gelir topla
        {
            decimal toplamOdeme = 0;

            // DataGridView'deki her bir satırı döngü ile kontrol edin
            foreach (DataGridViewRow row in dataGridView1.Rows)
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

            label9.Text = toplamOdeme.ToString();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker3.Value.Date;

        }
        private void LoadGiderler(DateTime selectedDate)
        {
            using (var context = new FitnessAppContext())
            {
                var result = from g in context.Gider
                             where g.Tarih == selectedDate
                             select new
                             {
                                 GiderId = g.Id,
                                 GiderTuru = g.GiderTuru,
                                 Fiyat = g.Fiyat,
                                 Aciklama = g.Aciklama,
                                 Tarih = g.Tarih

                             };

                dataGridView3.DataSource = result.ToList();
            }
        }

        private void button6_Click(object sender, EventArgs e)//giderlistele
        {
            DateTime selectedDate = dateTimePicker2.Value.Date;
            LoadGiderler(selectedDate);
        }

        private void button5_Click(object sender, EventArgs e)//gider ekle butonu 
        {
            try
            {
                if (comboBox3.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen gider türünü seçiniz.");
                    return;
                }

                DateTime selectedDate = dateTimePicker1.Value;
                MessageBox.Show($"Seçilen Tarih: {selectedDate.ToShortDateString()}");

                Gider gider = new Gider
                {
                    GiderTuru = comboBox3.SelectedItem.ToString(),
                    Aciklama = textBox1.Text,
                    Fiyat = Convert.ToDecimal(textBox2.Text),
                    Tarih = selectedDate
                };

                _giderService.Add(gider);
                MessageBox.Show("Gider başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal toplamFiyat = 0;

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (!row.IsNewRow)
                {
                    toplamFiyat += Convert.ToDecimal(row.Cells["Fiyat"].Value);
                }
            }

            label1.Text = Convert.ToString(toplamFiyat);
        }

        private void button10_Click(object sender, EventArgs e)//egitmen maas listele
        {
            LoadEgitmenler();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (var context = new FitnessAppContext())
            {
                decimal toplamOdeme = context.Egitmen.Sum(m => m.Maas);
                label20.Text = Convert.ToString(toplamOdeme);
            }


        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoadPersoneller();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (var context = new FitnessAppContext())
            {
                decimal toplamOdeme = context.Personel.Sum(m => m.Maas);
                label18.Text = Convert.ToString(toplamOdeme);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void button8_Click_1(object sender, EventArgs e)
        {
            LoadPersoneller();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            LoadEgitmenler();
        }

        private void button7_Click_1(object sender, EventArgs e)//personeltopla
        {
            using (var context = new FitnessAppContext())
            {
                decimal toplamOdeme = context.Personel.Sum(m => m.Maas);
                label18.Text = Convert.ToString(toplamOdeme);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            using (var context = new FitnessAppContext())
            {
                decimal toplamOdeme = context.Egitmen.Sum(m => m.Maas);
                label20.Text = Convert.ToString(toplamOdeme);
            }
        }

        private void button11_Click(object sender, EventArgs e)//top gider
        {
            DateTime selectedDate = dateTimePicker4.Value.Date;
            LoadGiderler(selectedDate);
            decimal toplamGiderFiyat = 0;
            decimal toplamPersonelOdeme = 0;
            decimal toplamEgitmenOdeme = 0;

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (!row.IsNewRow)
                {
                    toplamGiderFiyat += Convert.ToDecimal(row.Cells["Fiyat"].Value);
                }
            }
            using (var context = new FitnessAppContext())
            {
                toplamPersonelOdeme = context.Personel.Sum(m => m.Maas);
            }
            using (var context = new FitnessAppContext())
            {
                toplamEgitmenOdeme = context.Egitmen.Sum(m => m.Maas);
            }
            label2.Text = Convert.ToString(toplamGiderFiyat);
            if (selectedDate.Day == 15)
            {
                label2.Text = Convert.ToString(toplamGiderFiyat + toplamPersonelOdeme + toplamEgitmenOdeme);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker4.Value.Date;
            LoadPaketler(selectedDate);
            decimal toplamOdeme = 0;

            // DataGridView'deki her bir satırı döngü ile kontrol edin
            foreach (DataGridViewRow row in dataGridView1.Rows)
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
            label4.Text = toplamOdeme.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            label5.Text = Convert.ToString(Convert.ToInt32(label4.Text) - Convert.ToInt32(label2.Text));
        }
        private void ShowGroupBoxAtPosition(GroupBox groupBox, int x, int y)
        {
            groupBox.Location = new Point(x, y);
            groupBox.Show();
        }
        private void button14_Click(object sender, EventArgs e)//home
        {
            groupBox2.Show();
            groupBox1.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            ShowGroupBoxAtPosition(groupBox2, 287, 33);
        }

        private void button17_Click(object sender, EventArgs e)//kar zarar
        {
            groupBox2.Hide();
            groupBox1.Show();
            groupBox3.Hide();
            groupBox4.Hide();
            ShowGroupBoxAtPosition(groupBox1, 287, 33);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            groupBox3.Show();
            groupBox4.Hide();
            groupBox2.Hide();
            groupBox1.Hide();
            ShowGroupBoxAtPosition(groupBox3, 287, 33);

        }

        private void button16_Click(object sender, EventArgs e)
        {
            groupBox4.Show();
            groupBox2.Hide();
            groupBox1.Hide();
            groupBox3.Hide();
            ShowGroupBoxAtPosition(groupBox4, 287, 33);

        }

        private void Muhasebe_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            groupBox2.Show();

            ShowGroupBoxAtPosition(groupBox2, 287, 33);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBox3.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen gider türünü seçiniz.");
                    return;
                }

                DateTime selectedDate = dateTimePicker1.Value;
                MessageBox.Show($"Seçilen Tarih: {selectedDate.ToShortDateString()}");

                Gider gider = new Gider
                {
                    GiderTuru = comboBox3.SelectedItem.ToString(),
                    Aciklama = textBox1.Text,
                    Fiyat = Convert.ToDecimal(textBox2.Text),
                    Tarih = selectedDate
                };

                _giderService.Add(gider);
                MessageBox.Show("Gider başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }
    }
}
