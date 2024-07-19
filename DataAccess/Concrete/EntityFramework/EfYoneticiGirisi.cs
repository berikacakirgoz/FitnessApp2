using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfYoneticiGirisi : EfEntityRepositoryBase<YoneticiGirisi, FitnessAppContext>, IYoneticiGirisiDal
    {
        public YoneticiGirisi GetByKullaniciAdiSifre(string kullaniciAdi, string sifre)
        {
            using (FitnessAppContext context = new FitnessAppContext())
            {
                return context.Set<YoneticiGirisi>().SingleOrDefault(y => y.KullaniciAdi == kullaniciAdi && y.Sifre == sifre);
            }
        }
    }
}
