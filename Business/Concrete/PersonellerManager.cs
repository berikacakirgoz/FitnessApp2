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
    public class PersonellerManager : IPersonellerService
    {
        IPersonelDal _personelDal;

        public PersonellerManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }

        public void Add(Personel entity)
        {
            _personelDal.Ekle(entity);
        }

        public void Delete(Personel entity)
        {
           _personelDal.Sil(entity);
        }

        public List<Personel> GetAll()
        {
            return _personelDal.HepsiniGetir();
        }

        public void Update(Personel entity)
        {
            _personelDal.Guncelle(entity);
        }
    }
}
