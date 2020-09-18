using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Stok")]
    public class Stoklar : MyEntitiesBase
    {

        [StringLength(100)]
        public string urunAdi { get; set; }

        [StringLength(10)]
        public string satilanMiktar { get; set; }
        
    }
}
