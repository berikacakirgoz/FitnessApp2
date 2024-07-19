using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MusteriManager : IMusteriService
    {
        IMusteriDal _musteriDal;

      
        public MusteriManager(IMusteriDal musteriDal)
        {
            _musteriDal = musteriDal;
        }

        public void Add(Musteri entity)
        {
            _musteriDal.Ekle(entity);
        }

        public void Delete(Musteri entity)
        {
           _musteriDal.Sil(entity);
        }

        public List<Musteri> GetAll()
        {
            return _musteriDal.HepsiniGetir();
        }

        public void Update(Musteri entity)
        {
           _musteriDal.Guncelle(entity);
        }
    }
}
