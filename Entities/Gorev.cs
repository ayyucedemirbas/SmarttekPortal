using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Gorev
    {

        public string GorevNo { get; set; }
        public string GorevKonu { get; set; }

        public string GorevYetkili { get; set; }
        
        public string durum { get; set; }
      
        public string kalanGun { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        
        public DateTime BitisTarihi { get; set; }
    }
}
