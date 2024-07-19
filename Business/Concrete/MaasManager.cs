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
    public class MaasManager : IMaasService
    {
        IMaasDal _maasDal;

        public MaasManager(IMaasDal maasDal)
        {
            _maasDal = maasDal;
        }

        public void AddMaas(Maas maas)
        {
            _maasDal.Ekle(maas);
        }

        public void DeleteMaas(Maas maas)
        {
            _maasDal.Sil(maas);
        }

        public List<Maas> GetAllMaas()
        {
            return _maasDal.HepsiniGetir();
        }

        public void UpdateMaas(Maas maas)
        {
            _maasDal.Guncelle(maas);
        }
    }
}
