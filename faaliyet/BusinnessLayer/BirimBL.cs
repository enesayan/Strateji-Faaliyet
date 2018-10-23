using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Container;

namespace BusinnessLayer
{
    public class BirimBL : BusinessBase
    {
        public List<Birimler> BirimleriListele()
        {
            return base.BolumIslemleri.BirimleriListele();
        }
        public bool Birim_Ekle(Birimler F)
        {
            return base.BolumIslemleri.Birim_Ekle(F);
        }
        public bool Birim_Sil(String B_id)
        {
            return base.BolumIslemleri.Birim_Sil(B_id);
        }
        public bool Birim_Guncelle(Birimler Birim)
        {
            return base.BolumIslemleri.Birim_Guncelle(Birim);
        }
        public Birimler Id_Ile_Birim_Getir(string bid)
        {
            return base.BolumIslemleri.Id_Ile_Birim_Getir(bid);
        }
    }
}
