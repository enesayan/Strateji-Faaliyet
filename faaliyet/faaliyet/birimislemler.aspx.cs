using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Container;

namespace faaliyet
{
    public partial class birimislemler : PageBase
    {
        public string hesap_ismi;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["BirimId"] != null)
            {
                
                Uyari_Division.Visible = true;
                yonetim_islemleri.Visible = true;
                Hosgeldiniz_label.Text = "Birim Yöneticisi "+ Session["AdiSoyadi"]+" -> <a href='birimislemler.aspx'>İşlemler</a>";
                hesap_ismi = "Birim Yöneticisi " + Session["AdiSoyadi"];

                if (Request.QueryString["ProsesVeri"] == "Ekle")
                {
                    Hosgeldiniz_label.Text = hesap_ismi + " -> <a href='birimislemler.aspx'>İşlemler</a> -> <a href='#'>Proses Veri Ekle</a>";
                    islemler_list_div.Visible = false;
                    yonetim_islemleri.Visible = false;
                    ProsesVeriEkleDiv.Visible = true;

                    if (!Page.IsPostBack)
                    {
                        ProsesDropDownListDoldur();
                    }
                }

            }
            else
            {
                Response.Redirect("login.aspx");
            }



        }


        // Dropdown listi prosesler ile doldur. ve Dönemler getirildi.
        public void ProsesDropDownListDoldur()
        {
            List<Donemler> donemler = base.Get_Donem_bl.DonemleriListele();
            foreach (Donemler d in donemler.Where(x => x.Durum == 2 || DateTime.Now < x.BitisTarih && DateTime.Now > x.BaslangicTarih))
            {
                DropDownDonemler.Items.Add(d.DonemAdi);
            }
            DropDownDonemler.Items.Insert(0, new ListItem("Veri Eklemek İstediğiniz Dönemi Seçiniz", "NA"));

            if (donemler.Where(x => x.Durum == 2 || DateTime.Now < x.BitisTarih && DateTime.Now > x.BaslangicTarih).ToList().Count > 0)
            {
                DropDownListProses.Visible = true;
                List<Prosesler> p = base.Get_Proses_bl.ProsesListele();
                foreach (Prosesler pro in p)
                {
                    DropDownListProses.Items.Add(pro.ProsesAdi);
                }
                DropDownListProses.Items.Insert(0, new ListItem("Veri Eklemek İstediğiniz Prosesi Seçiniz", "NA"));
            }
            else
            {
                DropDownListProses.Visible = false;
            }
        }

        // Prosese ait deger verisinin kaydedilmesi
        protected void ProsesVeriKaydetButton_Click(object sender, EventArgs e)
        {
            int ProsesId = (int)Session["ProsesId"];
            int DonemId = (int)Session["DonemId"];
           
           
            int BirimId = (int)(Session["BirimId"]);
            string KullaniciAdi = Session["KullaniciAdi"].ToString(); // Session dan al
            string OlusturmaIp = "192.168.1.1";
            //Proses'e ait veri girilecek değerler getirildi
            List<ProsesDegerleri> pdegerId = base.Get_ProsesDeger_bl.ProsesDegeriListelewithProsesId(ProsesId.ToString());

            ProsesIslemler prosesislem = new ProsesIslemler();
            prosesislem.ProsesId = ProsesId;
            prosesislem.BirimId = BirimId;
            prosesislem.DonemId = DonemId;
            prosesislem.KullaniciAdi = KullaniciAdi;
            prosesislem.OlusturmaTarihi = DateTime.Now;
            prosesislem.OlusturmaIP = OlusturmaIp;
          
           

            string[] veriler = Hidden.Value.Split(';');
            bool result = false;
           
 

            if (pdegerId.Count > 0)
            {
                for (int i = 0; i < pdegerId.Count; i++)
                {

                    prosesislem.Veri = veriler[i].ToString();
                    prosesislem.ProsesDegerId = pdegerId[i].Id;
                    result = base.Get_ProsesIslem_bl.ProsesVeri_Ekle(prosesislem);
                }
            }
            if (result)
            {
                islem_basarili.Visible = true;
            }
            else
            {
                islem_basarisiz.Visible = true;
            }
        }

        protected void ProsesVeriGuncelleButton_Click(object sender, EventArgs e)
        {



        }

        // Proses seçimi yapılınca tetiklenecek prosese gore veri girişi yapılacak alanları getirecek
        protected void DropDownListProses_SelectedIndexChanged(object sender, EventArgs e)
        {

            int ProsesId = 0;
            int DonemId = 0;
            ProsesVeriKaydetButton.Visible = true;
            string ProsesAdi = DropDownListProses.SelectedItem.Value.ToString();
            string DonemAdi = DropDownDonemler.SelectedItem.Value.ToString();
            List<Prosesler> p = base.Get_Proses_bl.ProsesListele();
            List<Donemler> d = base.Get_Donem_bl.DonemleriListele();


            // seçilen dönem ıd bulunuyor
            foreach (Donemler donem in d)
            {
                if (donem.DonemAdi == DonemAdi)
                {
                    DonemId = donem.Id;
                    break;
                }
            }

            // seçilen proses id bulunuyor
            foreach (Prosesler pro in p)
            {
                if (pro.ProsesAdi == ProsesAdi)
                {
                    ProsesId = pro.Id;
                    break;
                }
            }

            Session["ProsesId"] = ProsesId;
            Session["DonemId"] = DonemId;

            //Proses'e ait veri girilecek değerler getirildi
            List<ProsesDegerleri> pd = base.Get_ProsesDeger_bl.ProsesDegeriListelewithProsesId(ProsesId.ToString());

            if (pd.Count > 0)
            {

                for (int i = 0; i < pd.Count; i++)
                {
                    Label lbl = new Label();
                    lbl.Text = pd[i].Gorev.ToString();
                    //string id = pd[i].Id.ToString();
                    PanelProsesVeriler.Controls.Add(lbl);
                    this.CreateTexbox("txtDynamic" + i);
                }


            }





        }

        private void CreateTexbox(string id)
        {
            TextBox txt = new TextBox();
            txt.CssClass = "form-control";
            txt.ID = id;
            PanelProsesVeriler.Controls.Add(txt);
        }






    }
}