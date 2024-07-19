using Business.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonelManager : IPersonelService
    {
        IPersonelGirisiDal _personelGirisi;
        public PersonelManager(IPersonelGirisiDal personelGirisi)
        {
            _personelGirisi = personelGirisi;
        }

        public bool PersonelGirisiYap(string kullaniciAdi, string sifre)
        {
            var personel = _personelGirisi.GetByKullaniciAdiSifre(kullaniciAdi, sifre);


            return personel != null; // Yönetici varsa true, yoksa false döner
        }
    }
}
