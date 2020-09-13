using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Izin")]
    public class Izinler : MyEntitiesBase
    {
        [StringLength(50)]
        public string AdiSoyadi { get; set; }

        [StringLength(50)]
        public string TelefonNumarasi { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        [StringLength(50)]
        public string Nedeni { get; set; }

        [StringLength(15)]
        public string baslangicTarihi { get; set; }

        [StringLength(15)]
        public string bitisTarihi { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

    }
}
