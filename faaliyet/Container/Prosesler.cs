using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Container
{
    public class Prosesler : ContainerBase
    {
        public int Id { get; set; }
        public string ProsesAdi { get; set; }
        public string ProsesKodu { get; set; }
        public string ProsesHizmetTanimi { get; set; }
        public string ProsesKaynaklari { get; set; }
        public int ProsesHedefi { get; set; }
        public Boolean Durum { get; set; }
    }
}
