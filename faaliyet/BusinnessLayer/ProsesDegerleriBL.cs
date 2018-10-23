using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Container;

namespace BusinnessLayer
{
    public class ProsesDegerleriBL : BusinessBase
    {
        public List<ProsesDegerleri> ProsesDegeriListele()
        {
            return base.ProsesDegerIslemleri.ProsesDegeriListele();
        }

        // proses id'ye göre değerleri getiriyor.
        public List<ProsesDegerleri> ProsesDegeriListelewithProsesId(string pId)
        {
            return base.ProsesDegerIslemleri.ProsesDegeriListelewithProsesId(pId);
        }

        public bool ProsesDegeri_Ekle(ProsesDegerleri F)
        {
            return base.ProsesDegerIslemleri.ProsesDegeri_Ekle(F);
        }
        public bool ProsesDegeri_Sil(String B_id)
        {
            return base.ProsesDegerIslemleri.ProsesDegeri_Sil(B_id);
        }
        public bool ProsesDegeri_Guncelle(ProsesDegerleri deger)
        {
            return base.ProsesDegerIslemleri.ProsesDegeri_Guncelle(deger);
        }
        public ProsesDegerleri Id_Ile_ProsesDegeri_Getir(string bid)
        {
            return base.ProsesDegerIslemleri.Id_Ile_ProsesDegeri_Getir(bid);
        }
    }
}
