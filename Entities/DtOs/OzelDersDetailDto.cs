using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DtOs
{
    public class OzelDersDetailDto:IDto
    {
        public int OzelDersId { get; set; }
        public string OzelDersName { get; set; }
        public string EgitmenName { get; set; }
        public DateTime Tarih { get; set; }
    }
}
