using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Container;

namespace BusinnessLayer
{
    public class BirimSorumlulari_BL : BusinessBase
    {
        public List<BirimSorumlulari> BirimSorumlusuListele(string B_Id)
        {
            return base.BirimSorumluIslemleri.BirimSorumlusuListele(B_Id);
        }
        public bool BirimSorumlusu_Ekle(BirimSorumlulari F)
        {
            return base.BirimSorumluIslemleri.BirimSorumlusu_Ekle(F);
        }
        public bool BirimSorumlusu_Sil(String B_id)
        {
            return base.BirimSorumluIslemleri.BirimSorumlusu_Sil(B_id);
        }
        public bool BirimSorumlusu_Guncelle(BirimSorumlulari BirimSorumlusu)
        {
            return base.BirimSorumluIslemleri.BirimSorumlusu_Guncelle(BirimSorumlusu);
        }
        public BirimSorumlulari Id_Ile_BirimSorumlusu_Getir(string bid)
        {
            return base.BirimSorumluIslemleri.Id_Ile_BirimSorumlusu_Getir(bid);
        }
    }
}
