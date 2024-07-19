using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OzelDers:IEntity
    {
        public int Id { get; set; }
        public int EgitmenId { get; set; }
        public int MusteriId { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
    }
}
