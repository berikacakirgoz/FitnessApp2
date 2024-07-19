using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Paket : IEntity
    {
        public int Id { get; set; }
        public int Ay { get; set; }
        public int AylikFiyat { get; set; }
        public int ToplamPaketFiyati { get; set; }
        public string PaketAdi { get; set; }
        public string OzelDers { get; set; }
        public decimal OzelDersFiyati { get; set; }
    }
}
