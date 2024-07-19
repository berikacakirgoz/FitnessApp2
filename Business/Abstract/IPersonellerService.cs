using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonellerService
    {
        List<Personel> GetAll();
        void Add(Personel entity);
        void Update(Personel entity);
        void Delete(Personel entity);
    }
}
