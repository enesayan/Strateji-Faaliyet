using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinnessLayer;
using Container;

namespace faaliyet
{
    public abstract class PageBase : System.Web.UI.Page
    {
        /* Login islemlerini yapar*/
        LoginBL _login_bl = null;
        public LoginBL Get_login_bl
        {
            get
            {
                if (_login_bl == null)
                    _login_bl = new LoginBL();
                return _login_bl;
            }
        }
        /* Birim islemlerini yapar*/
        BirimBL _birim_bl = null;
        public BirimBL Get_birim_bl
        {
            get
            {
                if (_birim_bl == null)
                    _birim_bl = new BirimBL();
                return _birim_bl;
            }
        }

        /* Birim Sorumlusu islemlerini yapar*/
        BirimSorumlulari_BL _sorumlu_bl = null;
        public BirimSorumlulari_BL Get_BirimSorumlusu_bl
        {
            get
            {
                if (_sorumlu_bl == null)
                    _sorumlu_bl = new BirimSorumlulari_BL();
                return _sorumlu_bl;
            }
        }

        /* Donem islemlerini yapar*/
        DonemlerBL _donem_bl = null;
        public DonemlerBL Get_Donem_bl
        {
            get
            {
                if (_donem_bl == null)
                    _donem_bl = new DonemlerBL();
                return _donem_bl;
            }
        }
        /* Proses islemlerini yapar*/
        ProsesBL _proses_bl = null;
        public ProsesBL Get_Proses_bl
        {
            get
            {
                if (_proses_bl == null)
                    _proses_bl = new ProsesBL();
                return _proses_bl;
            }
        }

        /* Proses deger islemlerini yapar*/
        ProsesDegerleriBL _prosesdeger_bl = null;
        public ProsesDegerleriBL Get_ProsesDeger_bl
        {
            get
            {
                if (_prosesdeger_bl == null)
                    _prosesdeger_bl = new ProsesDegerleriBL();
                return _prosesdeger_bl;
            }
        }


        /* Proses veri girme islemlerini yapar*/
        ProsesIslemlerBL _prosesislemler_bl = null;
        public ProsesIslemlerBL Get_ProsesIslem_bl
        {
            get
            {
                if (_prosesislemler_bl == null)
                    _prosesislemler_bl = new ProsesIslemlerBL();
                return _prosesislemler_bl;
            }

            
        }



    }
}