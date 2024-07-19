using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPaketService
    {
        List<Paket> GetAll();
        void Add(Paket entity);
        void Update(Paket entity);
        void Delete(Paket entity);
    }
}
