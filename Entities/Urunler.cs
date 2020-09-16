using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

    [Table("Urun")]
   public class Urunler : MyEntitiesBase
    {
        [StringLength(50)]
        public string FirmaAdi { get; set; }

        [StringLength(500)]
        public string FirmaAdres { get; set; }

        [StringLength(100)]
        public string VergiDairesi { get; set; }

        [StringLength(100)]
        public string VergiNumarasi { get; set; }

        [StringLength(20)]
        public string Tarih { get; set; }

        [StringLength(20)]
        public string Saat { get; set; }

        [StringLength(20)]
        public string Kur { get; set; }



    }
}
