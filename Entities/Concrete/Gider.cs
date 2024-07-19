using Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Gider: IEntity
    {
        public int Id { get; set; }
        public string GiderTuru { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime Tarih { get; set; }
    }
}
