using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Container
{
    public class ProsesDegerleri : ContainerBase
    {
        public int Id { get; set; }
        public int ProsesId { get; set; }
        public string Gorev { get; set; }
        public Boolean Durum { get; set; }
    }
}
