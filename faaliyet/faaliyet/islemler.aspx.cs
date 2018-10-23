using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Container;

namespace faaliyet
{
    public partial class islemler : PageBase
    {
        public string hesap_ismi;
        protected void Page_Load(object sender, EventArgs e)
        {
            Uyari_Division.Visible = false;

            if (Session["Yonetim"] != null)
            {
                yonetim_islemleri.Visible = true;
                Hosgeldiniz_label.Text = "Sistem Yöneticisi -> <a href='islemler.aspx'>İşlemler</a>";
                hesap_ismi = "Sistem Yöneticisi";


                if (Request.QueryString["Birim"] == "Ekle")
                {
                    Hosgeldiniz_label.Text = hesap_ismi + " -> <a href='islemler.aspx'>İşlemler</a> -> <a href='?Birim=Ekle'>Birim Ekle</a>";

                    islemler_list_div.Visible = false;
                    yonetim_islemleri.Visible = false;
                    //Fakulte_Listele_Division.Visible = false;
                    Birim_Kayit_Division.Visible = true;
                    Birim_Kaydet.Visible = true;
                }
                else if (Request.QueryString["Birim"] == "listele")
                {
                    Hosgeldiniz_label.Text = hesap_ismi + " -> <a href='islemler.aspx'>İşlemler</a> -> <a href='?Birim=listele'>Birim Listele</a>";
                    islemler_list_div.Visible = false;
                    islemler_div.Visible = true;
                    Birim_Listele_Division.Visible = true;
                    B_listele_Grid.DataSource = base.Get_birim_bl.BirimleriListele();
                    B_listele_Grid.DataBind();
                }
                else if (Request.QueryString["Birim"] == "Sorumlular")
                {
                    string Birim_Id = Request.QueryString["B_Id"];
                    Birimler mybirim = base.Get_birim_bl.Id_Ile_Birim_Getir(Birim_Id);
                    SORUMLU_LINK.HRef = "?Birim=Sorumlu_Ekle&B_Id=" + Birim_Id;

                    Hosgeldiniz_label.Text = hesap_ismi + " -> <a href='islemler.aspx'>İşlemler</a> -> <a href='?Birim=listele'>Birim Listele</a> -> <a href='?Birim=Sorumlular&B_Id=" + Birim_Id + "'>" + mybirim.BirimAdi + " Biriminin Sorumluları</a>";
                    islemler_list_div.Visible = false;
                    islemler_div.Visible = true;
                    BirimSorumluListele_Div.Visible = true;
                    Sorumlular_DataGrid.DataSource = base.Get_BirimSorumlusu_bl.BirimSorumlusuListele(Birim_Id);
                    Sorumlular_DataGrid.DataBind();
                }
                else if (Request.QueryString["Birim"] == "Sorumlu_Ekle")
                {
                    string Birim_Id = Request.QueryString["B_Id"];
                    Birimler mybirim = base.Get_birim_bl.Id_Ile_Birim_Getir(Birim_Id);
                    Hosgeldiniz_label.Text = hesap_ismi + " -> <a href='islemler.aspx'>İşlemler</a> -> <a href='?Birim=listele'>Birim Listele</a> -> <a href='?Birim=Sorumlular&B_Id=" + Birim_Id + "'>" + mybirim.BirimAdi + " Biriminin Sorumluları</a> -> <a href='?Birim=Sorumlu_Ekle&Id=" + Birim_Id + "'>Birim Sorumlusu Ekle</a>";

                    SorumluBirimId.Text = Birim_Id;

                    islemler_list_div.Visible = false;
                    yonetim_islemleri.Visible = false;
                    //Fakulte_Listele_Division.Visible = false;
                    BirimSorumluEkle_Div.Visible = true;
                    SorumluKaydet_Button.Visible = true;
                }

                if (Request.QueryString["Donem"] == "Ekle")
                {
                    Hosgeldiniz_label.Text = hesap_ismi + " -> <a href='islemler.aspx'>İşlemler</a> -> <a href='?Donem=Ekle'>Dönem Ekle</a>";

                    islemler_list_div.Visible = false;
                    yonetim_islemleri.Visible = false;
                    //Fakulte_Listele_Division.Visible = false;
                    DonemEkleme_Div.Visible = true;
                    DonemEkleButton.Visible = true;
                }
                else if (Request.QueryString["Donem"] == "listele")
                {
                    Hosgeldiniz_label.Text = hesap_ismi + " -> <a href='islemler.aspx'>İşlemler</a> -> <a href='?Donem=listele'>Dönem Listele</a>";
                    islemler_list_div.Visible = false;
                    islemler_div.Visible = true;
                    DonemListeleDiv.Visible = true;
                    DonemListeleGrid.DataSource = base.Get_Donem_bl.DonemleriListele();
                    DonemListeleGrid.DataBind();
                }

                if (Request.QueryString["Proses"] == "Ekle")
                {
                    Hosgeldiniz_label.Text = hesap_ismi + " -> <a href='islemler.aspx'>İşlemler</a> -> <a href='?Proses=Ekle'>Proses Ekle</a>";

                    islemler_list_div.Visible = false;
                    yonetim_islemleri.Visible = false;
                    //Fakulte_Listele_Division.Visible = false;
                    ProsesEkleDiv.Visible = true;
                    ProsesKaydetButton.Visible = true;
                }
                else if (Request.QueryString["Proses"] == "listele")
                {
                    Hosgeldiniz_label.Text = hesap_ismi + " -> <a href='islemler.aspx'>İşlemler</a> -> <a href='?Proses=listele'>Proses Listele</a>";
                    islemler_list_div.Visible = false;
                    islemler_div.Visible = true;
                    ProsesListeleDiv.Visible = true;
                    ProsesDG.DataSource = base.Get_Proses_bl.ProsesListele();
                    ProsesDG.DataBind();
                }
                if (Request.QueryString["ProsesDeger"] == "listele")
                {
                    string Proses_Id = Request.QueryString["P_Id"];
                    Deger_link.HRef = "?ProsesDeger=Ekle&P_Id=" + Proses_Id;
                    Hosgeldiniz_label.Text = hesap_ismi + " -> <a href='islemler.aspx'>İşlemler</a> -> <a href='?Proses=listele'>Proses Listele</a>-> <a href='?ProsesDeger=listele&P_Id=" + Proses_Id + "'>Proses Degerlerini Listele</a>";
                    islemler_list_div.Visible = false;
                    islemler_div.Visible = true;
                    ProsesDegerListeleDiv.Visible = true;
                    Response.Write(Proses_Id);
                    ProsesDegerDG.DataSource = base.Get_ProsesDeger_bl.ProsesDegeriListelewithProsesId(Proses_Id);
                    ProsesDegerDG.DataBind();
                }
                else if (Request.QueryString["ProsesDeger"] == "Ekle")
                {
                    string Proses_Id = Request.QueryString["P_Id"];
                    Hosgeldiniz_label.Text = hesap_ismi + " -> <a href='islemler.aspx'>İşlemler</a> -> <a href='?Proses=listele'>Proses Listele</a>-> <a href='?ProsesDeger=listele&P_Id=" + Proses_Id + "'>Proses Değer Listele </a> -> <a href='#'>Proses Değer Ekle </a>";
                    islemler_list_div.Visible = false;
                    yonetim_islemleri.Visible = false;
                    //Fakulte_Listele_Division.Visible = false;
                    ProsesDegerEkleDiv.Visible = true;
                    ProsesDegerKaydetButton.Visible = true;

                }
            }
            else Response.Redirect("default.aspx");



        }

        protected void Birim_Kaydet_Click(object sender, EventArgs e)
        {
            Birimler Birim = new Birimler();

            Birim.BirimAdi = birim_adi.Value;


            bool result = base.Get_birim_bl.Birim_Ekle(Birim);

            if (result)
            {
                Birim_Kayit_Division.Visible = false;
                Uyari_Division.Visible = true;
                Literal_Uyari.Text = "<h2>Kayıt Başarılı bir şekilde gerçekleştirilmiştir.</h2>";

                Response.Redirect("islemler.aspx?Birim=listele");
            }
        }
        protected void Birim_Guncelle_Button_Click(object sender, EventArgs e)
        {
            Birimler Birim = new Birimler();
            Birim.Id = int.Parse(G_B_Id.Text);
            Birim.BirimAdi = birim_adi.Value;



            bool result = base.Get_birim_bl.Birim_Guncelle(Birim);

            if (result)
            {
                Birim_Kayit_Division.Visible = false;
                islem_basarili.Visible = true;
                Birim_Listele_Division.Visible = true;
                B_listele_Grid.DataSource = base.Get_birim_bl.BirimleriListele();
                B_listele_Grid.DataBind();
            }
            else
            {
                islem_basarisiz.Visible = true;
            }
        }
        protected void B_listele_Grid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Birim_Duzenle")
            {
                Hosgeldiniz_label.Text = hesap_ismi + " -> <a href='islemler.aspx'>İşlemler</a> -> <a href='?Birim=listele'>Birim Listele</a> -> <a href='#'>Birim Güncelleme</a>";
                string id = ((Label)((DataGridItem)e.Item).FindControl("Label_f_Id")).Text;

                Birimler selected_birim = new Birimler();
                selected_birim = base.Get_birim_bl.Id_Ile_Birim_Getir(id);

                Birim_Listele_Division.Visible = false;
                Birim_Kayit_Division.Visible = true;
                Birim_Guncelle_Button.Visible = true;

                G_B_Id.Text = selected_birim.Id.ToString();
                birim_adi.Value = selected_birim.BirimAdi;
            }

            if (e.CommandName == "Birim_Sil")
            {
                string id = ((Label)((DataGridItem)e.Item).FindControl("Label_f_Id")).Text;

                bool result = base.Get_birim_bl.Birim_Sil(id);

                if (result)
                {
                    islem_basarili.Visible = true;
                    Birim_Listele_Division.Visible = true;
                    B_listele_Grid.DataSource = base.Get_birim_bl.BirimleriListele();
                    B_listele_Grid.DataBind();
                }
                else
                {
                    islem_basarisiz.Visible = true;
                }
            }

        }

        protected void Sorumlular_DataGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Sorumlu_Duzenle")
            {
                string id = ((Label)((DataGridItem)e.Item).FindControl("Label_s_Id")).Text;
                BirimSorumlulari mySorumlu = base.Get_BirimSorumlusu_bl.Id_Ile_BirimSorumlusu_Getir(id);
                Birimler myBirim = base.Get_birim_bl.Id_Ile_Birim_Getir(mySorumlu.BirimId.ToString());
                Hosgeldiniz_label.Text = hesap_ismi + " -> <a href='islemler.aspx'>İşlemler</a> -> <a href='?Birim=listele'>Birim Listele</a> -> <a href='?Birim=Sorumlular&B_Id=" + myBirim.Id + "'>" + myBirim.BirimAdi + " Biriminin Sorumluları</a> -> <a href='#'>Birim Sorumlusu Guncelleme</a>";

                BirimSorumluListele_Div.Visible = false;
                BirimSorumluEkle_Div.Visible = true;
                SorumluGuncelle_Button.Visible = true;

                SorumluBirimId.Text = mySorumlu.Id.ToString();
                SorumluAdi.Value = mySorumlu.AdiSoyadi;
                SorumluKullaniciAdi.Value = mySorumlu.KullaniciAdi;
                SorumluSifre.Value = mySorumlu.Sifre;
                SorumluSifre.Attributes["type"] = "password";
            }

            if (e.CommandName == "Sorumlu_Sil")
            {
                string id = ((Label)((DataGridItem)e.Item).FindControl("Label_s_Id")).Text;
                string Birim_Id = Request.QueryString["B_Id"];
                bool result = base.Get_BirimSorumlusu_bl.BirimSorumlusu_Sil(id);

                if (result)
                {
                    islem_basarili.Visible = true;
                    BirimSorumluListele_Div.Visible = true;
                    Sorumlular_DataGrid.DataSource = base.Get_BirimSorumlusu_bl.BirimSorumlusuListele(Birim_Id);
                    Sorumlular_DataGrid.DataBind();
                }
                else
                {
                    islem_basarisiz.Visible = true;
                }
            }
        }

        protected void SorumluKaydet_Button_Click(object sender, EventArgs e)
        {
            BirimSorumlulari BirimSorumlusu = new BirimSorumlulari();

            BirimSorumlusu.BirimId = int.Parse(SorumluBirimId.Text);
            BirimSorumlusu.AdiSoyadi = SorumluAdi.Value;
            BirimSorumlusu.KullaniciAdi = SorumluKullaniciAdi.Value;
            BirimSorumlusu.Sifre = SorumluSifre.Value;


            bool result = base.Get_BirimSorumlusu_bl.BirimSorumlusu_Ekle(BirimSorumlusu);

            if (result)
            {
                BirimSorumluEkle_Div.Visible = false;
                Uyari_Division.Visible = true;
                Literal_Uyari.Text = "<h2>Kayıt Başarılı bir şekilde gerçekleştirilmiştir.</h2>";

                Response.Redirect("islemler.aspx?Birim=Sorumlular&B_Id=" + BirimSorumlusu.BirimId);
            }
        }

        protected void SorumluGuncelle_Button_Click(object sender, EventArgs e)
        {
            BirimSorumlulari BirimSorumlusu = new BirimSorumlulari();
            string Birim_Id = Request.QueryString["B_Id"];
            BirimSorumlusu.Id = int.Parse(SorumluBirimId.Text);
            BirimSorumlusu.AdiSoyadi = SorumluAdi.Value;
            BirimSorumlusu.KullaniciAdi = SorumluKullaniciAdi.Value;
            BirimSorumlusu.Sifre = SorumluSifre.Value;


            bool result = base.Get_BirimSorumlusu_bl.BirimSorumlusu_Guncelle(BirimSorumlusu);

            if (result)
            {
                BirimSorumluEkle_Div.Visible = false;
                Uyari_Division.Visible = true;
                Literal_Uyari.Text = "<h2>Kayıt Başarılı bir şekilde gerçekleştirilmiştir.</h2>";

                Response.Redirect("islemler.aspx?Birim=Sorumlular&B_Id=" + Birim_Id);
            }
        }

        protected void DonemEkleButton_Click(object sender, EventArgs e)
        {
            Donemler Donem = new Donemler();

            Donem.DonemAdi = DonemAdi.Value;
            Donem.BaslangicTarih = Convert.ToDateTime(Baslama_Tarihi_tb.Text);
            Donem.BitisTarih = Convert.ToDateTime(Bitis_Tarihi_tb.Text);

            bool result = base.Get_Donem_bl.Donem_Ekle(Donem);

            if (result)
            {
                DonemEkleme_Div.Visible = false;
                Uyari_Division.Visible = true;
                Literal_Uyari.Text = "<h2>Kayıt Başarılı bir şekilde gerçekleştirilmiştir.</h2>";

                Response.Redirect("islemler.aspx?Donem=listele");
            }
        }

        protected void DonemGuncelleButton_Click(object sender, EventArgs e)
        {
            Donemler Donem = new Donemler();
            Donem.Id = int.Parse(Donem_Id.Text);
            Donem.DonemAdi = DonemAdi.Value;
            Donem.BaslangicTarih = Convert.ToDateTime(Baslama_Tarihi_tb.Text);
            Donem.BitisTarih = Convert.ToDateTime(Bitis_Tarihi_tb.Text);
            if (Veri_Girisi_Check.Items.FindByValue("2").Selected == true)
            {
                Donem.Durum = int.Parse(Veri_Girisi_Check.SelectedItem.Value);
            }
            else Donem.Durum = 0;


            bool result = base.Get_Donem_bl.Donem_Guncelle(Donem);

            if (result)
            {
                DonemEkleme_Div.Visible = false;
                Uyari_Division.Visible = true;
                Literal_Uyari.Text = "<h2>Güncelleme Başarılı bir şekilde gerçekleştirilmiştir.</h2>";

                Response.Redirect("islemler.aspx?Donem=listele");
            }
        }

        protected void DonemListeleGrid_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Donem_Sil")
            {
                string id = ((Label)((DataGridItem)e.Item).FindControl("Label_d_Id")).Text;
                bool result = base.Get_Donem_bl.Donem_Sil(id);

                if (result)
                {
                    islem_basarili.Visible = true;
                    DonemListeleDiv.Visible = true;
                    DonemListeleGrid.DataSource = base.Get_Donem_bl.DonemleriListele();
                    DonemListeleGrid.DataBind();
                }
                else
                {
                    islem_basarisiz.Visible = true;
                }
            }
            if (e.CommandName == "Donem_Duzenle")
            {
                Hosgeldiniz_label.Text = hesap_ismi + " -> <a href='islemler.aspx'>İşlemler</a> -> <a href='?Donem=listele'>Dönem Listele</a> -> <a href='#'>Donem Güncelleme</a>";
                string id = ((Label)((DataGridItem)e.Item).FindControl("Label_d_Id")).Text;

                Donemler selected_donem = new Donemler();
                selected_donem = base.Get_Donem_bl.Id_Ile_Donem_Getir(id);

                DonemListeleDiv.Visible = false;
                DonemEkleme_Div.Visible = true;
                DonemGuncelleButton.Visible = true;

                Giris_Izni_Ver_Div.Visible = true;

                if (selected_donem.Durum == 2)
                {
                    Veri_Girisi_Check.Items.FindByValue("2").Selected = true;
                }


                Donem_Id.Text = selected_donem.Id.ToString();
                DonemAdi.Value = selected_donem.DonemAdi;
                Baslama_Tarihi_tb.Text = selected_donem.BaslangicTarih.ToString("dd.MM.yyyy");
                Bitis_Tarihi_tb.Text = selected_donem.BitisTarih.ToString("dd.MM.yyyy");
                DonemAdi.Value = selected_donem.DonemAdi;
            }
        }

        protected void ProsesKaydetButton_Click(object sender, EventArgs e)
        {
            Prosesler my_proses = new Prosesler();
            my_proses.ProsesAdi = ProsesAdi.Value;
            my_proses.ProsesKodu = ProsesKodu.Value;
            my_proses.ProsesHizmetTanimi = ProsesHizmetTanimi.Value;
            my_proses.ProsesKaynaklari = ProsesKaynaklari.Value;
            my_proses.ProsesHedefi = int.Parse(ProsesHedefi.Value);

            bool result = base.Get_Proses_bl.Proses_Ekle(my_proses);

            if (result)
            {
                ProsesEkleDiv.Visible = false;
                Uyari_Division.Visible = true;
                Literal_Uyari.Text = "<h2>Kayıt Başarılı bir şekilde gerçekleştirilmiştir.</h2>";

                Response.Redirect("islemler.aspx?Proses=listele");
            }

        }

        protected void ProsesDG_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Proses_Sil")
            {
                string id = ((Label)((DataGridItem)e.Item).FindControl("Label_p_Id")).Text;
                bool result = base.Get_Proses_bl.Proses_Sil(id);

                if (result)
                {
                    islem_basarili.Visible = true;
                    ProsesListeleDiv.Visible = true;
                    ProsesDG.DataSource = base.Get_Proses_bl.ProsesListele();
                    ProsesDG.DataBind();
                }
                else
                {
                    islem_basarisiz.Visible = true;
                }
            }

            if (e.CommandName == "Proses_Duzenle")
            {
                Hosgeldiniz_label.Text = hesap_ismi + " -> <a href='islemler.aspx'>İşlemler</a> -> <a href='?Proses=listele'>Proses Listele</a> -> <a href='#'>Proses Güncelleme</a>";
                string id = ((Label)((DataGridItem)e.Item).FindControl("Label_p_Id")).Text;

                Prosesler selected_Proses = new Prosesler();
                selected_Proses = base.Get_Proses_bl.Id_Ile_Proses_Getir(id);

                ProsesListeleDiv.Visible = false;
                ProsesEkleDiv.Visible = true;
                ProsesGuncelleButton.Visible = true;

                ProsesId.Text = selected_Proses.Id.ToString();
                ProsesAdi.Value = selected_Proses.ProsesAdi;
                ProsesKodu.Value = selected_Proses.ProsesKodu;
                ProsesHizmetTanimi.Value = selected_Proses.ProsesHizmetTanimi;
                ProsesKaynaklari.Value = selected_Proses.ProsesKaynaklari;
                ProsesHedefi.Value = selected_Proses.ProsesHedefi.ToString();
            }
        }

        protected void ProsesGuncelleButton_Click(object sender, EventArgs e)
        {
            Prosesler prosesim = new Prosesler();

            prosesim.Id = int.Parse(ProsesId.Text);
            prosesim.ProsesAdi = ProsesAdi.Value;
            prosesim.ProsesKodu = ProsesKodu.Value;
            prosesim.ProsesHizmetTanimi = ProsesHizmetTanimi.Value;
            prosesim.ProsesKaynaklari = ProsesKaynaklari.Value;
            prosesim.ProsesHedefi = int.Parse(ProsesHedefi.Value);


            bool result = base.Get_Proses_bl.Proses_Guncelle(prosesim);

            if (result)
            {
                ProsesEkleDiv.Visible = false;
                Uyari_Division.Visible = true;
                Literal_Uyari.Text = "<h2>Kayıt Başarılı bir şekilde gerçekleştirilmiştir.</h2>";

                Response.Redirect("islemler.aspx?Proses=listele");
            }
        }

        // proses değer kaydı yapılıyor
        protected void ProsesDegerKaydetButton_Click(object sender, EventArgs e)
        {
            try
            {
                string Proses_Id = Request.QueryString["P_Id"];
                ProsesDegerleri pd = new ProsesDegerleri();
                Deger_link.HRef = "?ProsesDeger=Ekle&P_Id=" + Proses_Id;
                pd.ProsesId = int.Parse(Proses_Id);
                pd.Gorev = GorevData.Value;

                bool result = base.Get_ProsesDeger_bl.ProsesDegeri_Ekle(pd);
                if (result)
                {
                    ProsesDegerEkleDiv.Visible = false;
                    Uyari_Division.Visible = true;
                    Literal_Uyari.Text = "<h2>Kayıt Başarılı bir şekilde gerçekleştirilmiştir.</h2>";
                    Response.Redirect("islemler.aspx?ProsesDeger=listele&P_Id=" + Proses_Id);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

        }

        // proses değerleri listenmiş düzenle sil işlemleri
        protected void ProsesDegerlerDG_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "ProsesDeger_Duzenle")
            {
                string Proses_Id = Request.QueryString["P_Id"];
                Hosgeldiniz_label.Text = hesap_ismi + " -> <a href='islemler.aspx'>İşlemler</a> -> <a href='?Proses=listele'>Proses Listele</a> -> <a href='?ProsesDeger=listele&P_Id=" + Proses_Id + "'>Proses Deger Listele</a> -> <a href='#'>Proses Deger Güncelle</a>";
                string id = ((Label)((DataGridItem)e.Item).FindControl("Label_pd_Id")).Text;
                ProsesDegerleri pd = base.Get_ProsesDeger_bl.Id_Ile_ProsesDegeri_Getir(id);
                ProsesDegerListeleDiv.Visible = false;
                ProsesDegerEkleDiv.Visible = true;
                ProsesDegerGuncelleButton.Visible = true;
                ProsesDegerId.Text = pd.Id.ToString();
                GorevData.Value = pd.Gorev;
                // buradan güncelle butonuna gidiyor

            }

            if (e.CommandName == "ProsesDeger_Sil")
            {
                string id = ((Label)((DataGridItem)e.Item).FindControl("Label_pd_Id")).Text;
                string Proses_Id = Request.QueryString["P_Id"];
                bool result = base.Get_ProsesDeger_bl.ProsesDegeri_Sil(id);//GetPGet_BirimSorumlusu_bl.BirimSorumlusu_Sil(id);

                if (result)
                {
                    islem_basarili.Visible = true;
                    ProsesDegerListeleDiv.Visible = true;
                    // silme işleminden sonra ilgili proses ait değerlerin gelmesi için
                    ProsesDegerDG.DataSource = base.Get_ProsesDeger_bl.ProsesDegeriListelewithProsesId(Proses_Id);
                    ProsesDegerDG.DataBind();
                }
                else
                {
                    islem_basarisiz.Visible = true;
                }
            }


        }

        // proses değer güncellemek için buton
        protected void ProsesDegerGuncelleButton_Click(object sender, EventArgs e)
        {
            ProsesDegerleri pd = new ProsesDegerleri();
            string Proses_Id = Request.QueryString["P_Id"];
            pd.Id = int.Parse(ProsesDegerId.Text);
            pd.Gorev = GorevData.Value;
            pd.ProsesId = int.Parse(Proses_Id);

            bool result = base.Get_ProsesDeger_bl.ProsesDegeri_Guncelle(pd);
            if (result)
            {
                ProsesDegerEkleDiv.Visible = false;
                ProsesDegerListeleDiv.Visible = true;
                // güncellemeden sonra proses id ye göre değer getiriyor.
                ProsesDegerDG.DataSource = base.Get_ProsesDeger_bl.ProsesDegeriListelewithProsesId(Proses_Id);
                ProsesDegerDG.DataBind();
                islem_basarili.Visible = true;

            }

            else
            {
                islem_basarisiz.Visible = true;
            }


        }
    }
}