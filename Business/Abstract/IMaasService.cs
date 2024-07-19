using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMaasService
    {
        void AddMaas(Maas maas);
        void UpdateMaas(Maas maas);
        void DeleteMaas(Maas maas);
        List<Maas> GetAllMaas();
    }
}
