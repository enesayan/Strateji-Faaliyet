using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Container
{
    public class ProsesIslemler: ContainerBase
    {
        public int Id { get; set; }
        public int ProsesId { get; set; }
        public int BirimId { get; set; }
        public int ProsesDegerId { get; set; }
        public int DonemId { get; set; }
        public string Veri { get; set; }
        public string KullaniciAdi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public string GuncellemeIP { get; set; }
        public string  OlusturmaIP{ get; set; }
    }
}
