using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Temas
    {
        public string SiparisNumara { get; set; }
        public string AcmaNedeni { get; set; }
        
        public string TemasOlusturan { get; set; }
        public string FirmaAdi { get; set; }
        public string TemasNumara { get; set; }
        public string YetkiliKisi { get; set; }
        public string FirmaTelefon { get; set; }
        public string Adres { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNo { get; set; }
        public string SimdikiDurum { get; set; }
        public DateTime TemasTarih { get; set; }
        public string TemasAsama { get; set; }
        public DateTime TarihGuncelle { get; set; }

    }
}
