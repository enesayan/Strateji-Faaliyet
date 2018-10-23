using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Container;

namespace BusinnessLayer
{
    public class DonemlerBL : BusinessBase
    {
        public List<Donemler> DonemleriListele()
        {
            return base.DonemIslemleri.DonemleriListele();
        }
        public bool Donem_Ekle(Donemler F)
        {
            return base.DonemIslemleri.Donem_Ekle(F);
        }
        public bool Donem_Sil(String B_id)
        {
            return base.DonemIslemleri.Donem_Sil(B_id);
        }
        public bool Donem_Guncelle(Donemler Birim)
        {
            return base.DonemIslemleri.Donem_Guncelle(Birim);
        }
        public Donemler Id_Ile_Donem_Getir(string donem_id)
        {
            return base.DonemIslemleri.Id_Ile_Donem_Getir(donem_id);
        }
        public Donemler AktifDonemGetir()
        {
            return base.DonemIslemleri.AktifDonemGetir();
        }
    }
}
