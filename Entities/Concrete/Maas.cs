
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Maas : IEntity
    {
        public int Id { get; set; }
        public int EgitmenId { get; set; }
        public decimal Miktar { get; set; }
        public DateTime Tarih { get; set; }

    }
}
