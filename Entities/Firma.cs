using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Firma")]

    public class Firma:MyEntitiesBase
    {
        public string FirmaAdi { get; set; }
        public string KayitAcan { get; set; }
        public DateTime KayitTarih { get; set; }
        public string FirmaTelefon { get; set; }
        public string FirmaWebSite { get; set; }
        public string FirmaAdres { get; set; }
        public string FirmaSehir { get; set; }
        public string FirmaMail { get; set; }
    }
}
