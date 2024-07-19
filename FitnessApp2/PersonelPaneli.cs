using Business.Abstract;
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
    public partial class PersonelPaneli : Form
    {
        private readonly IMusteriService _musteriService;
        private readonly IPaketService _paketService;
        private readonly IEgitmenService _egitmenService;
        private readonly IYoneticiService _yoneticiService;
        private readonly IPersonelService _girispersonelService;
        private readonly IServiceProvider _serviceProvider;


        private int selectedPaketId;
        private int selectedEgitmenId;
        private int selectedPaketFiyati;
        private int selectedOzelDersFiyati;

        public PersonelPaneli(IMusteriService musteriService, IPaketService paketService, IEgitmenService egitmenService)
        {
            _musteriService = musteriService;
            _paketService = paketService;
            _egitmenService = egitmenService;
            InitializeComponent();
            LoadMusteriler();
            LoadPaketler();
            LoadEgitmenler();

            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView3.CellClick += dataGridView3_CellClick;
            textBox2.TextChanged += new EventHandler(textBox2_TextChanged);


        }
        private void LoadMusteriler()
        {
            dataGridView2.DataSource = _musteriService.GetAll();
        }
        private void LoadEgitmenler()
        {
            dataGridView3.DataSource = _egitmenService.GetAll();
            var egitmenler = _egitmenService.GetAll();
            comboBox1.DataSource = egitmenler;
            comboBox1.DisplayMember = "Ad"; // Görüntülenecek alan (Eğitmen adı)
            comboBox1.ValueMember = "Id"; // Değer olarak kullanılacak alan (Eğitmen ID)
        }
        private void LoadPaketler()
        {
            dataGridView1.DataSource = _paketService.GetAll();
            var paketler = _paketService.GetAll();
            comboBox2.DataSource = paketler;
            comboBox2.DisplayMember = "PaketAdi"; // Görüntülenecek alan (Eğitmen adı)
            comboBox2.ValueMember = "Id"; // Değer olarak kullanılacak alan (Eğitmen ID)
        }


        private void button1_Click(object sender, EventArgs e) //musteri ekleme 
        {
            Paket selectedPaket = comboBox2.SelectedItem as Paket;
            int deneme = selectedPaket != null ? selectedPaket.ToplamPaketFiyati : 0;
            var musteri = new Musteri
            {
                Ad = textBox1.Text,
                Soyad = textBox3.Text,
                Eposta = textBox4.Text,
                TelefonNumarasi = textBox5.Text,
                PaketlerId = (int)comboBox2.SelectedValue,
                EgitmenId = (int)comboBox1.SelectedValue,
                Odeme = deneme,
                KayitTarihi = dateTimePicker1.Value

            };

            _musteriService.Add(musteri);
            LoadMusteriler();
        }

        private void button4_Click(object sender, EventArgs e)//paket secimi butonu
        {
            LoadPaketler();
        }

        private void button5_Click(object sender, EventArgs e) //egitmen secimi butonu 
        {
            LoadEgitmenler();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)//egitmen
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
                selectedEgitmenId = Convert.ToInt32(row.Cells["Id"].Value);

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//paket
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedPaketId = Convert.ToInt32(row.Cells["Id"].Value);
                selectedPaketFiyati = Convert.ToInt32(row.Cells["ToplamPaketFiyati"].Value);
                selectedOzelDersFiyati = Convert.ToInt32(row.Cells["OzelDersFiyati"].Value);


                label10.Text = (selectedPaketFiyati + selectedOzelDersFiyati).ToString();

            }

        }

        private void button2_Click(object sender, EventArgs e)//musterisilme
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var musteri = (Musteri)dataGridView2.SelectedRows[0].DataBoundItem;
                _musteriService.Delete(musteri);
                LoadMusteriler();
            }


        }

        private void button3_Click(object sender, EventArgs e)//musteri guncelleme
        {

            if (dataGridView2.SelectedRows.Count > 0)
            {
                var musteri = (Musteri)dataGridView2.SelectedRows[0].DataBoundItem;

                musteri.Ad = textBox1.Text;
                musteri.Soyad = textBox3.Text;
                musteri.TelefonNumarasi = textBox4.Text;
                musteri.Eposta = textBox5.Text;
                musteri.PaketlerId = (int)comboBox2.SelectedValue;
                musteri.EgitmenId = (int)comboBox1.SelectedValue;

                musteri.Odeme = Convert.ToInt32(label10.Text);
                musteri.KayitTarihi = dateTimePicker1.Value;
                _musteriService.Update(musteri);
                LoadMusteriler();
            }

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count > 0)
            {
                var musteri = (Musteri)dataGridView2.SelectedRows[0].DataBoundItem;

                textBox1.Text = musteri.Ad;
                textBox3.Text = musteri.Soyad;
                textBox4.Text = musteri.Eposta;
                textBox5.Text = musteri.TelefonNumarasi;

                comboBox1.SelectedValue = musteri.EgitmenId;
                comboBox2.SelectedValue = musteri.PaketlerId;
                dateTimePicker1.Value = musteri.KayitTarihi;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count > 0)
            {
                var paket = (Paket)dataGridView2.SelectedRows[0].DataBoundItem;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var yoneticiGirisiYap = new YoneticiGirisiYap(_yoneticiService, _girispersonelService, _serviceProvider);
            yoneticiGirisiYap.Show();
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string filterText = textBox2.Text.ToLower();

            var filteredList = _musteriService.GetAll()
                .Where(m => m.Ad.ToLower().Contains(filterText) ||
                            m.Soyad.ToLower().Contains(filterText) ||
                            m.Eposta.ToLower().Contains(filterText) ||
                            m.TelefonNumarasi.ToLower().Contains(filterText))
                .ToList();

            dataGridView2.DataSource = filteredList;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            Paket selectedPaket = comboBox2.SelectedItem as Paket;
            if (selectedPaket != null)
            {
                label10.Text = selectedPaket.ToplamPaketFiyati.ToString();
            }
            else
            {
                label10.Text = "0";
            }

        }
    }
}

