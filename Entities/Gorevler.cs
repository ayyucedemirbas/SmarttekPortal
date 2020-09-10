using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{

    [Table("Gorevler")]
    public class Gorevler : MyEntitiesBase
    {

        [StringLength(150)]
        public string gorev_yetkili { get; set; }

        [StringLength(150)]
        public string gorev_konu { get; set; }
        [StringLength(150)]
        public string baslangic_tarihi { get; set; }
        [StringLength(150)]
        public string bitis_tarihi { get; set; }
        [StringLength(150)]
        public string kalan_gun { get; set; }
        [StringLength(150)]
        public string durum { get; set; }
        
    }
}
