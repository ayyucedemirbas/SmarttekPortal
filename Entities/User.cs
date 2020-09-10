using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Users")]
    public class User : MyEntitiesBase
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
    }
}
