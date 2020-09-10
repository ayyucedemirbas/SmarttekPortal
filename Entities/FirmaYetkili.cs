using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("FirmaYetkili")]
    public class FirmaYetkili:MyEntitiesBase
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Unvan { get; set; }
        public Int64 firmaID { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
    }
}
