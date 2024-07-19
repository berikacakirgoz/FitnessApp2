using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMusteriService
    {
        List<Musteri> GetAll();
        void Add(Musteri entity);
        void Update(Musteri entity);
        void Delete(Musteri entity);

    }
}
//using Business.Abstract;

 
