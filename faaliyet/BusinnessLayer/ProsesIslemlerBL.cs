using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Container;


namespace BusinnessLayer
{
   public class ProsesIslemlerBL : BusinessBase
    {
       
        // proses girdi verilerini veri tabanına ekler
        public bool ProsesVeri_Ekle(ProsesIslemler pi)
        {
            return base.ProsesIslemler.ProsesVeri_Ekle(pi);
        }
       

    }
}
