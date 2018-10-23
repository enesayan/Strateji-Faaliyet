using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;

namespace BusinnessLayer
{
    public abstract class BusinessBase
    {
        /* yonetici islemleri için data etkileşimi*/
        LoginData _logindata = null;
        protected LoginData LoginIslemleri
        {
            get
            {
                if (_logindata == null)
                    _logindata = new LoginData();
                return _logindata;
            }
        }
        /* birim islemleri için data etkileşimi*/
        BirimlerData _birimdata = null;
        protected BirimlerData BolumIslemleri
        {
            get
            {
                if (_birimdata == null)
                    _birimdata = new BirimlerData();
                return _birimdata;
            }
        }

        /* Birim Sorumlusu islemleri için data etkileşimi*/
        BirimSorumlulariData _sorumluData = null;
        protected BirimSorumlulariData BirimSorumluIslemleri
        {
            get
            {
                if (_sorumluData == null)
                    _sorumluData = new BirimSorumlulariData();
                return _sorumluData;
            }
        }


        /* Donem islemleri için data etkileşimi*/
        DonemlerData _donemData = null;
        protected DonemlerData DonemIslemleri
        {
            get
            {
                if (_donemData == null)
                    _donemData = new DonemlerData();
                return _donemData;
            }
        }

        /* proses islemleri için data etkileşimi*/
        ProsesData _prosesdata = null;
        protected ProsesData ProsesIslemleri
        {
            get
            {
                if (_prosesdata == null)
                    _prosesdata = new ProsesData();
                return _prosesdata;
            }
        }
        /* proses DEGERLERİ islemleri için data etkileşimi*/
        ProsesDegerleriData _prosesdegerdata = null;
        protected ProsesDegerleriData ProsesDegerIslemleri
        {
            get
            {
                if (_prosesdegerdata == null)
                    _prosesdegerdata = new ProsesDegerleriData();
                return _prosesdegerdata;
            }
        }

        /* prosesIslemleri için data etkileşimi*/
        ProsesIslemlerData _prosesislemlerdata = null;
        protected ProsesIslemlerData ProsesIslemler
        {
            get
            {
                if (_prosesislemlerdata == null)
                    _prosesislemlerdata = new ProsesIslemlerData();
                return _prosesislemlerdata;
            }
        }


    }
}
