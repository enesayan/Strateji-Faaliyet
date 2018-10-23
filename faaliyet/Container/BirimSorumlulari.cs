using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Container
{
    public class BirimSorumlulari : ContainerBase
    {
        public int Id { get; set; }
        public int BirimId { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string AdiSoyadi { get; set; }
        public Boolean Durum { get; set; }
    }
}
