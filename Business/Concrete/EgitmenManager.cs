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
    public class EgitmenManager : IEgitmenService
    {
        IEgitmenDal _egitmenDal;

        public EgitmenManager(IEgitmenDal egitmenDal)
        {
            _egitmenDal = egitmenDal;
        }

        public void Add(Egitmen entity)
        {
            _egitmenDal.Ekle(entity);
        }

        public void Delete(Egitmen entity)
        {
            _egitmenDal.Sil(entity);
        }

        public List<Egitmen> GetAll()
        {
            return _egitmenDal.HepsiniGetir();

        }

        public void Update(Egitmen entity)
        {
            _egitmenDal.Guncelle(entity);
        }
    }
}
