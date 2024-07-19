using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class YoneticiManager : IYoneticiService
    {
        private readonly IYoneticiGirisiDal _yoneticiGirisiDal;

        public YoneticiManager(IYoneticiGirisiDal yoneticiGirisiDal)
        {
            _yoneticiGirisiDal = yoneticiGirisiDal;
        }

        public bool YoneticiGirisiYap(string kullaniciAdi, string sifre)
        {
            var yonetici = _yoneticiGirisiDal.GetByKullaniciAdiSifre(kullaniciAdi, sifre);
           

            return yonetici != null; // Yönetici varsa true, yoksa false döner
        }
    }
}
    

