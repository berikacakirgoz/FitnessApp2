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
    public class GiderManager : IGiderService
    {
        IGiderDal _giderDal;

        public GiderManager(IGiderDal giderDal)
        {
            _giderDal = giderDal;
        }

        public void Add(Gider gider)
        {
            _giderDal.Ekle(gider);
        }

        public void Delete(Gider gider)
        {
           _giderDal.Sil(gider);
        }

        public List<Gider> GetAll()
        {
            return _giderDal.HepsiniGetir();
        }

        public void Update(Gider gider)
        {
          _giderDal.Guncelle(gider);
        }
    }
}
