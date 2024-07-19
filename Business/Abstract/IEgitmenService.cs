using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEgitmenService
    {
        List<Egitmen> GetAll();
        void Add(Egitmen entity);
        void Update(Egitmen entity);
        void Delete(Egitmen entity);
    }
}
