using Core.Entites;
using Entities.Concrete;
using Entities.DtOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOzelDersDal:IEntityRepository<OzelDers>
    {
        List<OzelDersDetailDto> GetDetailsAll();
    }
}
