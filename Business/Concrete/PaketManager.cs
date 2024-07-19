using Business.Abstract;
using Core.Entities;
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
    public class PaketManager : IPaketService
    {
        IPaketDal _paketDal;
        public PaketManager(IPaketDal paketDal)
        {
            _paketDal = paketDal;
        }

        public void Add(Paket entity)
        {
            _paketDal.Ekle(entity);
        }

        public void Delete(Paket entity)
        {
            _paketDal.Sil(entity);
        }

        public List<Paket> GetAll()
        {
           return _paketDal.HepsiniGetir();
        }

        public void Update(Paket entity)
        {
            _paketDal.Guncelle(entity);
        }
    }
}
