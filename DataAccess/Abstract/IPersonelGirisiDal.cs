using Core.Entites;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPersonelGirisiDal:IEntityRepository<PersonelGirisi>
    {
        PersonelGirisi GetByKullaniciAdiSifre(string kullaniciAdi, string sifre);
    }
}
