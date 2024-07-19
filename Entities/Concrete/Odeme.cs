
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Odeme : IEntity
    {
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public decimal Miktar { get; set; }
        public DateTime Tarih { get; set; }
    }
}
