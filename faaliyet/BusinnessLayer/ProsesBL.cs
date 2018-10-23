using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Container;

namespace BusinnessLayer
{
    public class ProsesBL : BusinessBase
    {
        public List<Prosesler> ProsesListele()
        {
            return base.ProsesIslemleri.ProsesListele();
        }
        public bool Proses_Ekle(Prosesler P)
        {
            return base.ProsesIslemleri.Proses_Ekle(P);
        }
        public bool Proses_Sil(string P)
        {
            return base.ProsesIslemleri.Proses_Sil(P);
        }
        public bool Proses_Guncelle(Prosesler P)
        {
            return base.ProsesIslemleri.Proses_Guncelle(P);
        }
        public Prosesler Id_Ile_Proses_Getir(string proses_id)
        {
            return base.ProsesIslemleri.Id_Ile_Proses_Getir(proses_id);
        }
    }
}
