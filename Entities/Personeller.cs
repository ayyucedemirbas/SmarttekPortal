using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Personel")]
    public class Personeller : MyEntitiesBase
    {
        [StringLength(50)]
        public string Adi { get; set; }

        [StringLength(50)]
        public string Soyadi{ get; set; }
        [StringLength(50)]
        public string FirmaMail { get; set; }
        [StringLength(50)]
        public string SahisMail { get; set; }
        [StringLength(20)]
        public string TelefonNumarasi { get; set; }
        [StringLength(50)]
        public string Unvan { get; set; }

    }
}
