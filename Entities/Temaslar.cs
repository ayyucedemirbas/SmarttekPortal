using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("temas_bilgi")]
    public class Temaslar : MyEntitiesBase
    {
        [StringLength(150)]
        public string siparis_numara { get; set; }

        [StringLength(500)]
        public string acma_nedeni { get; set; }
        [StringLength(500)]
        public string temas_olusturan { get; set; }
        [StringLength(500)]
        public string firma_adi { get; set; }
        [StringLength(500)]
        public string temas_numara { get; set; }
        [StringLength(500)]
        public string yetkili_kisi { get; set; }
        [StringLength(500)]
        public string firma_telefon { get; set; }
        [StringLength(500)]
        public string adres { get; set; }
        [StringLength(500)]
        public string vergi_dairesi { get; set; }
        [StringLength(500)]
        public string vergi_no { get; set; }
        [StringLength(500)]
        public string simdiki_durum { get; set; }
        [StringLength(500)]
        public string temas_tarih { get; set; }
        [StringLength(500)]
        public string temas_asama { get; set; }
        [StringLength(500)]
        public string tarih_guncelle { get; set; }

    }
}
