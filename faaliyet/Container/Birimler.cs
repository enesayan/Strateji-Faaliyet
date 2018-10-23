using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Container
{
    public class Birimler : ContainerBase
    {
        public int Id { get; set; }
        public string BirimAdi { get; set; }
        public Boolean Durum { get; set; }
    }
}
