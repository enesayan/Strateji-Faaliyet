using Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinnessLayer
{
    public class LoginBL : BusinessBase
    {
        public bool Yonetim_Login(string email, string pass)
        {
            return base.LoginIslemleri.YonetimLogin(email, pass);
        }
        public bool Bolum_Login(string email, string pass)
        {
            return base.LoginIslemleri.BirimLogin(email, pass);
        }

        public BirimSorumlulari BirimSorumlusu_Login(string email, string pass)
        {
            return base.LoginIslemleri.BirimSorumlusuGiris(email, pass);
        }

    }
}
