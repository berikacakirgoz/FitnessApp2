using Business.Abstract;
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
    public partial class YoneticiGirisiYap : Form
    {
        private readonly IYoneticiService _yoneticiService;
        private readonly IPersonelService _personelService;
        private readonly IServiceProvider _serviceProvider;




        public YoneticiGirisiYap(IYoneticiService yoneticiService, IPersonelService personelService,
            IServiceProvider serviceProvider)
        {
            _yoneticiService = yoneticiService;
            _personelService = personelService;
            _serviceProvider = serviceProvider;


            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void YoneticiGirisi_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text;
            string sifre = textBox2.Text;

            if (rbYonetici.Checked)
            {
                if (_yoneticiService.YoneticiGirisiYap(kullaniciAdi, sifre))
                {
                    MessageBox.Show("Yönetici girişi başarılı.");
                    // Yönetici formuna yönlendir
                    var yoneticiForm = _serviceProvider.GetRequiredService<YoneticiPaneli>();
                    yoneticiForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre yanlış.");
                }
            }
            else if (rbPersonel.Checked)
            {
                if (_personelService.PersonelGirisiYap(kullaniciAdi, sifre))
                {
                    MessageBox.Show("Personel girişi başarılı.");
                    var personelPaneli = _serviceProvider.GetRequiredService<PersonelPaneli>();
                    personelPaneli.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre yanlış.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen giriş türünü seçin.");
            }
        }
    }
}
