using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Container
{
    public class Donemler : ContainerBase
    {
        public int Id { get; set; }
        public string DonemAdi { get; set; }
        public DateTime BaslangicTarih { get; set; }
        public int BaslangicTarihGUN { get; set; }
        public string BaslangicTarihYIL { get; set; }
        public string BaslangicTarihAY { get; set; }
        public DateTime BitisTarih { get; set; }
        public int BitisTarihGUN { get; set; }
        public string BitisTarihYIL { get; set; }
        public string BitisTarihAY { get; set; }
        public int Durum { get; set; }
        public string DurumAciklama { get; set; }
    }
}
