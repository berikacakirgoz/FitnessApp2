using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DtOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOzelDersDal : EfEntityRepositoryBase<OzelDers, FitnessAppContext>, IOzelDersDal
    {
        public List<OzelDersDetailDto> GetDetailsAll()
        {
            throw new NotImplementedException();
        }
    }
}
