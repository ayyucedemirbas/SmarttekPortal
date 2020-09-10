using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("firmaAciklama")]
    public class FirmaAciklama : MyEntitiesBase
    {
        public Int64 firmaID { get; set; }
        public string Aciklama { get; set; }
        public string KayitAcan { get; set; }
        public DateTime KayitTarih { get; set; }
        public Int64 Yetkili { get; set; }
        public string Durum { get; set; }
    }
}
