<%@ Page Title="" Language="C#" MasterPageFile="~/FaaliyetMasterPage.Master" AutoEventWireup="true" CodeBehind="islemler.aspx.cs" Inherits="faaliyet.islemler" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="KKU" runat="server">

    <script type="text/javascript">
        function sedeceSayi(evt) {
            evt = (evt) ? evt : window.event
            var charCode = (evt.which) ? evt.which : evt.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false
            }
            return true
        }
    </script>

    <!-- *****************************************************************************************************************
	 BLUE WRAP
	 ***************************************************************************************************************** -->
    <div id="blue">
        <div class="container">
            <div class="row">
                <h3>
                    <asp:Label ID="Hosgeldiniz_label" runat="server" Text="İşlemler"></asp:Label></h3>
            </div>
            <!-- /row -->
        </div>
        <!-- /container -->
    </div>
    <!-- /blue -->

    <!-- *****************************************************************************************************************
	 İşlemler 
	 ***************************************************************************************************************** -->

    <form id="form1" runat="server">
        <div class="container mtb" id="islemler_list_div" runat="server">
            <div class="row centered">


                <div id="yonetim_islemleri" runat="server">

                    <div class="col-lg-2 col-md-2 col-sm-2">
                        <div class="he-wrap tpl6">
                            <img src="assets/img/process_img/birim_ekle.jpg" alt="">
                            <div class="he-view">
                                <div class="bg a0" data-animate="fadeIn">
                                    <h3 class="a1" data-animate="fadeInDown">Birim Ekle</h3>
                                    <a href="?Birim=Ekle" class="dmbutton a2" data-animate="fadeInUp"><i class="fa fa-external-link-square fa-2x"></i></a>
                                </div>
                                <!-- he bg -->
                            </div>
                            <!-- he view -->
                        </div>
                        <!-- he wrap -->
                        <h5 class="ctitle"><a href="?Birim=listele">Birimleri Listele</a></h5>
                        <p><a href="?Birim=Ekle">Birim Ekleme</a></p>
                        <div class="hline"></div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-2">
                        <div class="he-wrap tpl6">
                            <img src="assets/img/process_img/donem.png" alt="">
                            <div class="he-view">
                                <div class="bg a0" data-animate="fadeIn">
                                    <h3 class="a1" data-animate="fadeInDown">Dönem Ekle</h3>
                                    <a href="islemler.aspx?Donem=Ekle" class="dmbutton a2" data-animate="fadeInUp"><i class="fa fa-external-link-square fa-2x"></i></a>
                                </div>
                                <!-- he bg -->
                            </div>
                            <!-- he view -->
                        </div>
                        <!-- he wrap -->
                        <h5 class="ctitle"><a href="islemler.aspx?Donem=listele">Dönem Listele</a></h5>
                        <p><a href="islemler.aspx?Donem=Ekle">Dönem Ekleme</a></p>
                        <div class="hline"></div>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-2">
                        <div class="he-wrap tpl6">
                            <img src="assets/img/process_img/proses.png" alt="">
                            <div class="he-view">
                                <div class="bg a0" data-animate="fadeIn">
                                    <h3 class="a1" data-animate="fadeInDown">Proses Ekle</h3>
                                    <a href="islemler.aspx?Proses=Ekle" class="dmbutton a2" data-animate="fadeInUp"><i class="fa fa-external-link-square fa-2x"></i></a>
                                </div>
                                <!-- he bg -->
                            </div>
                            <!-- he view -->
                        </div>
                        <!-- he wrap -->
                        <h5 class="ctitle"><a href="islemler.aspx?Proses=listele">Proses Listele</a></h5>
                        <p><a href="islemler.aspx?Proses=Ekle">Proses Ekleme</a></p>
                        <div class="hline"></div>
                    </div>


                    <! --/col-lg-3 -->
            
                </div>

            </div>
            <! --/row -->
        </div>
        <! --/container -->

	 <div class="container" id="islemler_div" runat="server">
         <div class="row">
             <!-- uyarı kısmı -->
             <div class="section section-notifications" id="notifications">

                 <div class="alert alert-success" id="islem_basarili" runat="server" visible="false">
                     <div class="container-fluid">
                         <div class="alert-icon">
                             <i class="material-icons">check</i>
                         </div>
                         <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                             <span aria-hidden="true"><i class="material-icons">clear</i></span>
                         </button>
                         <b>İşlem Başarılı bir şekilde gerçekleşti</b>
                     </div>
                 </div>

                 <div class="alert alert-danger" id="islem_basarisiz" runat="server" visible="false">
                     <div class="container-fluid">
                         <div class="alert-icon">
                             <i class="material-icons">error_outline</i>
                         </div>
                         <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                             <span aria-hidden="true"><i class="material-icons">clear</i></span>
                         </button>
                         <b>İşlem gerçekleştirilemedi</b> Sistem yöneticisi ile irtibat kurunuz...
                     </div>
                 </div>
             </div>
             <!-- /uyarı kısmı-->
             <!-- Uyarı Bölümü -->
             <div id="Uyari_Division" runat="server">
                 <div class="col-lg-8 centered">
                     <asp:Literal ID="Literal_Uyari" runat="server"></asp:Literal>
                     <br>
                     <div class="hline"></div>
                 </div>
             </div>
             <!-- /Uyarı Bölümü -->

             <!-- Birim Ekleme Bölümü -->
             <div id="Birim_Kayit_Division" runat="server" visible="false">
                 <div class="col-lg-8">
                     <h4>Birim Ekleme</h4>
                     <div class="hline"></div>
                     <p>Birimleri Bu Bölümden Ekleyebilirsiniz</p>
                     <form role="form">
                         <asp:Label ID="G_B_Id" runat="server" Visible="false"></asp:Label>
                         <div class="form-group">
                             <label for="InputAdi">Birim Adı</label>
                             <input type="text" class="form-control" id="birim_adi" runat="server">
                         </div>
                         <asp:Button ID="Birim_Kaydet" class="btn btn-theme" Visible="false" runat="server" Text="Kaydet" OnClick="Birim_Kaydet_Click" />
                         <asp:Button ID="Birim_Guncelle_Button" Visible="false" class="btn btn-theme" runat="server" Text="Güncelle" OnClick="Birim_Guncelle_Button_Click" />

                     </form>
                 </div>
                 <! --/col-lg-8 -->
             </div>
             <!-- /Birim Ekleme Bölümü -->
             <!-- Birim Listeleme Bölümü -->

             <div id="Birim_Listele_Division" runat="server" visible="false">
                 <div class="col-lg-12">
                     <h4>Birim Listeleme - <a href="?Birim=Ekle">Birim Ekle</a><span style="float: right;">Durum</span></h4>
                     <div class="hline"></div>

                     <asp:DataGrid ID="B_listele_Grid" AutoGenerateColumns="false" runat="server" Width="100%" CellPadding="0" CellSpacing="0" BorderWidth="0px" BorderColor="white" OnItemCommand="B_listele_Grid_ItemCommand">
                         <Columns>
                             <asp:TemplateColumn ItemStyle-CssClass="col-lg-12">
                                 <ItemTemplate>
                                     <asp:Label ID="My_Content" runat="server">
                                         <p>
                                             <asp:Label ID="Label_f_Id" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                             <asp:LinkButton ID="Link_f_bak" runat="server" CommandName="Birim_bak" Width="65%"><i class="fa fa-angle-right"></i>
                                                 <asp:Label runat="server" ID="label_f_adi"><%# Eval("BirimAdi") %></asp:Label></asp:LinkButton>
                                             <asp:LinkButton ID="Link_f_sil" runat="server" CommandName="Birim_Sil" OnClientClick="return confirm('Silmek İstediğinizden Emin misiniz?');"><i class="glyphicon glyphicon-remove-circle"> </i> Birimi Sil </asp:LinkButton>
                                             <asp:LinkButton ID="Link_f_duzenle" runat="server" CommandName="Birim_Duzenle" OnClientClick="return confirm('Düzenlemek İstediğinizden Emin misiniz?');"><i class="glyphicon glyphicon-pencil"> </i> Birimi Düzenle </asp:LinkButton>
                                             <a href="?Birim=Sorumlular&B_Id=<%# Eval("Id") %>"><i class="glyphicon glyphicon-user">Sorumlular </i></a>
                                             <span class="badge badge-theme pull-right"><%# Eval("Durum") %></span>
                                         </p>
                                     </asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateColumn>
                         </Columns>

                     </asp:DataGrid>


                     <div class="spacing"></div>
                 </div>
                 <! --/col-lg-8 -->
             </div>
             <!-- /Birim Listeleme Bölümü -->

             <!-- Birim Sorumlularını Listeleme Bölümü -->
             <div id="BirimSorumluListele_Div" runat="server" visible="false">
                 <div class="col-lg-12">
                     <h4>Birim Sorumlularını Listele - <a runat="server" id="SORUMLU_LINK">Birim Sorumlusu Ekle</a><span style="float: right;">Durum</span></h4>
                     <div class="hline"></div>

                     <asp:DataGrid ID="Sorumlular_DataGrid" AutoGenerateColumns="false" runat="server" Width="100%" CellPadding="0" CellSpacing="0" BorderWidth="0px" BorderColor="white" OnItemCommand="Sorumlular_DataGrid_ItemCommand">
                         <Columns>
                             <asp:TemplateColumn ItemStyle-CssClass="col-lg-12">
                                 <ItemTemplate>
                                     <asp:Label ID="My_Content" runat="server">
                                         <p>
                                             <asp:Label ID="Label_s_Id" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                             <asp:LinkButton ID="Link_s_bak" runat="server" CommandName="Sorumlu_bak" Width="65%"><i class="fa fa-angle-right"></i>
                                                 <asp:Label runat="server" ID="label_f_adi"><%# Eval("AdiSoyadi") %></asp:Label></asp:LinkButton>
                                             <asp:LinkButton ID="Link_s_sil" runat="server" CommandName="Sorumlu_Sil" OnClientClick="return confirm('Silmek İstediğinizden Emin misiniz?');"><i class="glyphicon glyphicon-remove-circle"> </i> Sil </asp:LinkButton>
                                             <asp:LinkButton ID="Link_s_duzenle" runat="server" CommandName="Sorumlu_Duzenle" OnClientClick="return confirm('Düzenlemek İstediğinizden Emin misiniz?');"><i class="glyphicon glyphicon-pencil"> </i>  Düzenle </asp:LinkButton>

                                         </p>
                                     </asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateColumn>
                         </Columns>

                     </asp:DataGrid>


                     <div class="spacing"></div>
                 </div>
                 <! --/col-lg-8 -->
             </div>
             <!-- /Birim Sorumlularını Listeleme Bölümü -->
             <!-- Birim Sorumlusu Ekleme Bölümü -->
             <div id="BirimSorumluEkle_Div" runat="server" visible="false">
                 <div class="col-lg-8">
                     <h4>Birim Sorumlusu Ekleme</h4>
                     <div class="hline"></div>
                     <p>Birim Sorumlularını Bu Bölümden Ekleyebilirsiniz</p>
                     <form role="form">
                         <asp:Label ID="SorumluBirimId" runat="server" Visible="false"></asp:Label>
                         <div class="form-group">
                             <label for="InputAdi">Birim Sorumlusu Adı Soyadı</label>
                             <input type="text" class="form-control" id="SorumluAdi" runat="server">
                         </div>
                         <div class="form-group">
                             <label for="InputAdi">Kullanıcı Adı</label>
                             <input type="text" class="form-control" id="SorumluKullaniciAdi" runat="server">
                         </div>
                         <div class="form-group">
                             <label for="InputAdi">Şifre</label>
                             <input type="text" class="form-control" id="SorumluSifre" runat="server">
                         </div>
                         <asp:Button ID="SorumluKaydet_Button" class="btn btn-theme" Visible="false" runat="server" Text="Kaydet" OnClick="SorumluKaydet_Button_Click" />
                         <asp:Button ID="SorumluGuncelle_Button" Visible="false" class="btn btn-theme" runat="server" Text="Güncelle" OnClick="SorumluGuncelle_Button_Click" />

                     </form>
                 </div>
                 <! --/col-lg-8 -->
             </div>
             <!-- /Birim Sorumlusu Ekleme Bölümü -->


             <!-- Donem Ekleme Bölümü -->
             <div id="DonemEkleme_Div" runat="server" visible="false">
                 <div class="col-lg-8">
                     <h4>Birim Ekleme</h4>
                     <div class="hline"></div>
                     <p>Dönemleri Bu Bölümden Ekleyebilirsiniz</p>
                     <form role="form">
                         <asp:Label ID="Donem_Id" runat="server" Visible="false"></asp:Label>
                         <div class="form-group">
                             <label for="InputAdi">Dönem Adı</label>
                             <input type="text" class="form-control" id="DonemAdi" runat="server">
                         </div>
                         <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
                         <div class="form-group">
                             <label for="InputAdi">Donem Başlama Tarihi</label>
                             <asp:TextBox ID="Baslama_Tarihi_tb" class="form-control" runat="server"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Baslama_Tarihi_tb" PopupButtonID="Baslama_Tarihi_tb"></asp:CalendarExtender>

                         </div>
                         <div class="form-group">
                             <label for="InputAdi">Donem Bitiş Tarihi</label>

                             <asp:TextBox ID="Bitis_Tarihi_tb" class="form-control" runat="server"></asp:TextBox>
                             <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="Bitis_Tarihi_tb" PopupButtonID="Bitis_Tarihi_tb"></asp:CalendarExtender>

                         </div>
                         <div class="form-group" id="Giris_Izni_Ver_Div" runat="server" visible="false">
                             <label for="InputAdi">Giriş İzni Verilsin Mi? (Gerektiği durumda veri giriş için bitiş tarihi geçildiyse bu kısımdan güncelleme yapılabilir!!!)</label>
                             <asp:CheckBoxList ID="Veri_Girisi_Check" runat="server" class="form-group">
                                 <asp:ListItem Value="2">Evet</asp:ListItem>
                             </asp:CheckBoxList>
                         </div>
                         <asp:Button ID="DonemEkleButton" class="btn btn-theme" Visible="false" runat="server" Text="Kaydet" OnClick="DonemEkleButton_Click" />
                         <asp:Button ID="DonemGuncelleButton" Visible="false" class="btn btn-theme" runat="server" Text="Güncelle" OnClick="DonemGuncelleButton_Click" />

                     </form>
                 </div>
                 <! --/col-lg-8 -->
             </div>
             <!-- /Donem Ekleme Bölümü -->

             <!-- Dönem Listeleme Bölümü -->

             <div id="DonemListeleDiv" runat="server" visible="false">
                 <div class="col-lg-12">
                     <h4>Dönem Listeleme - <a href="?Donem=Ekle">Dönem Ekle</a><span style="float: right;">Durum</span></h4>
                     <div class="hline"></div>

                     <asp:DataGrid ID="DonemListeleGrid" AutoGenerateColumns="false" runat="server" Width="100%" CellPadding="0" CellSpacing="0" BorderWidth="0px" BorderColor="white" OnItemCommand="DonemListeleGrid_ItemCommand">
                         <Columns>

                             <asp:TemplateColumn ItemStyle-CssClass="col-lg-12">
                                 <ItemTemplate>
                                     <asp:Label ID="My_Content" runat="server">
                                         <p>
                                             <asp:Label ID="Label_d_Id" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                             <asp:LinkButton ID="Link_d_bak" runat="server" CommandName="Donem_bak" Width="40%"><i class="fa fa-angle-right"></i>
                                                 <asp:Label runat="server" ID="label_f_adi"><%# Eval("DonemAdi") %></asp:Label></asp:LinkButton>
                                             <asp:LinkButton ID="Link_d_baslama" runat="server" CommandName="Donem_bak" Width="15%"><i class="fa fa-angle-right"></i>
                                                 <asp:Label runat="server" ID="label1"><%# Eval("BaslangicTarihGUN") %>/<%# Eval("BaslangicTarihAY") %>/<%# Eval("BaslangicTarihYIL") %></asp:Label></asp:LinkButton>
                                             <asp:LinkButton ID="Link_d_bitis" runat="server" CommandName="Donem_bak" Width="15%"><i class="fa fa-angle-right"></i>
                                                 <asp:Label runat="server" ID="label3"><%# Eval("BitisTarihGUN") %>/<%# Eval("BitisTarihAY") %>/<%# Eval("BitisTarihYIL") %></asp:Label></asp:LinkButton>
                                             <asp:LinkButton ID="Link_d_sil" runat="server" CommandName="Donem_Sil" OnClientClick="return confirm('Silmek İstediğinizden Emin misiniz?');"><i class="glyphicon glyphicon-remove-circle"> </i>  Sil </asp:LinkButton>
                                             <asp:LinkButton ID="Link_d_duzenle" runat="server" CommandName="Donem_Duzenle" OnClientClick="return confirm('Düzenlemek İstediğinizden Emin misiniz?');"><i class="glyphicon glyphicon-pencil"> </i> Birimi Düzenle </asp:LinkButton>
                                             <span class="badge badge-theme pull-right"><%# Eval("DurumAciklama") %></span>
                                         </p>
                                     </asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateColumn>
                         </Columns>

                     </asp:DataGrid>


                     <div class="spacing"></div>
                 </div>
                 <! --/col-lg-8 -->
             </div>
             <!-- /Dönem Listeleme Bölümü -->


             <!-- Proses Ekleme Bölümü -->
             <div id="ProsesEkleDiv" runat="server" visible="false">
                 <div class="col-lg-8">
                     <h4>Proses Ekleme</h4>
                     <div class="hline"></div>
                     <p>Prosesleri Bu Bölümden Ekleyebilirsiniz</p>
                     <form role="form">
                         <asp:Label ID="ProsesId" runat="server" Visible="false"></asp:Label>
                         <div class="form-group">
                             <label for="InputAdi">Proses Adı</label>
                             <input type="text" class="form-control" id="ProsesAdi" runat="server">
                         </div>
                         <div class="form-group">
                             <label for="InputAdi">Proses Kodu</label>
                             <input type="text" class="form-control" id="ProsesKodu" runat="server">
                         </div>
                         <div class="form-group">
                             <label for="InputAdi">Proses Hizmet Tanımı</label>
                             <input type="text" class="form-control" id="ProsesHizmetTanimi" runat="server">
                         </div>
                         <div class="form-group">
                             <label for="InputAdi">Proses Kaynakları</label>
                             <input type="text" class="form-control" id="ProsesKaynaklari" runat="server">
                         </div>
                         <div class="form-group">
                             <label for="InputAdi">Proses Hedefi</label>
                             <input type="text" class="form-control" id="ProsesHedefi" onkeypress="return sedeceSayi(event)" runat="server">
                         </div>
                         <asp:Button ID="ProsesKaydetButton" class="btn btn-theme" Visible="false" runat="server" Text="Kaydet" OnClick="ProsesKaydetButton_Click" />
                         <asp:Button ID="ProsesGuncelleButton" Visible="false" class="btn btn-theme" runat="server" Text="Güncelle" OnClick="ProsesGuncelleButton_Click" />

                     </form>
                 </div>
                 <! --/col-lg-8 -->
             </div>
             <!-- /Proses Ekleme Bölümü -->

             <!-- Proses Listeleme Bölümü -->

             <div id="ProsesListeleDiv" runat="server" visible="false">
                 <div class="col-lg-12">
                     <h4>Proses Listeleme - <a href="?Proses=Ekle">Proses Ekle</a><span style="float: right;">Durum</span></h4>
                     <div class="hline"></div>

                     <asp:DataGrid ID="ProsesDG" AutoGenerateColumns="false" runat="server" Width="100%" CellPadding="0" CellSpacing="0" BorderWidth="0px" BorderColor="white" OnItemCommand="ProsesDG_ItemCommand">
                         <Columns>

                             <asp:TemplateColumn ItemStyle-CssClass="col-lg-12">
                                 <ItemTemplate>
                                     <asp:Label ID="My_Content" runat="server">
                                         <p>
                                             <asp:Label ID="Label_p_Id" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                             <asp:LinkButton ID="Link_p_bak" runat="server" CommandName="Proses_bak" Width="40%"><i class="fa fa-angle-right"></i>
                                                 <asp:Label runat="server" ID="label_f_adi"><%# Eval("ProsesAdi") %></asp:Label></asp:LinkButton>
                                             <asp:LinkButton ID="Link_p_sil" runat="server" CommandName="Proses_Sil" OnClientClick="return confirm('Silmek İstediğinizden Emin misiniz?');"><i class="glyphicon glyphicon-remove-circle"> </i>  Sil </asp:LinkButton>
                                             <asp:LinkButton ID="Link_p_duzenle" runat="server" CommandName="Proses_Duzenle" OnClientClick="return confirm('Düzenlemek İstediğinizden Emin misiniz?');"><i class="glyphicon glyphicon-pencil"> </i>  Düzenle  </asp:LinkButton>
                                             <a href="?ProsesDeger=listele&P_Id=<%# Eval("Id") %>"><i class="glyphicon glyphicon-book">Değerler </i></a>
                                             <span class="badge badge-theme pull-right"><%# Eval("Durum") %></span>
                                         </p>
                                     </asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateColumn>
                         </Columns>

                     </asp:DataGrid>

                     <div class="spacing"></div>
                 </div>
                 <! --/col-lg-8 -->
             </div>
             <!-- /Proses Listeleme Bölümü -->


             <!-- ProsesDegerleri Listeleme Bölümü -->

             <div id="ProsesDegerListeleDiv" runat="server" visible="false">
                 <div class="col-lg-12">
                     <h4>Proses Değeri Listeleme - <a href="" runat="server" id="Deger_link">Proses Degeri Ekle</a><span style="float: right;">Durum</span></h4>
                     <div class="hline"></div>

                     <asp:DataGrid ID="ProsesDegerDG" AutoGenerateColumns="false" runat="server" Width="100%" CellPadding="0" CellSpacing="0" BorderWidth="0px" BorderColor="white" OnItemCommand="ProsesDegerlerDG_ItemCommand">
                         <Columns>

                             <asp:TemplateColumn ItemStyle-CssClass="col-lg-12">
                                 <ItemTemplate>
                                     <asp:Label ID="My_Content" runat="server">
                                         <p>
                                             <asp:Label ID="Label_pd_Id" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                             <asp:LinkButton ID="Link_pd_bak" runat="server" CommandName="Proses_bak" Width="40%"><i class="fa fa-angle-right"></i>
                                                 <asp:Label runat="server" ID="label_f_adi"><%# Eval("Gorev") %></asp:Label></asp:LinkButton>
                                             <asp:LinkButton ID="Link_pd_sil" runat="server" CommandName="ProsesDeger_Sil" OnClientClick="return confirm('Silmek İstediğinizden Emin misiniz?');"><i class="glyphicon glyphicon-remove-circle"> </i>  Sil </asp:LinkButton>
                                             <asp:LinkButton ID="Link_pd_duzenle" runat="server" CommandName="ProsesDeger_Duzenle" OnClientClick="return confirm('Düzenlemek İstediğinizden Emin misiniz?');"><i class="glyphicon glyphicon-pencil"> </i>  Düzenle  </asp:LinkButton>
                                             <span class="badge badge-theme pull-right"><%# Eval("Durum") %></span>
                                         </p>
                                     </asp:Label>
                                 </ItemTemplate>
                             </asp:TemplateColumn>
                         </Columns>

                     </asp:DataGrid>


                     <div class="spacing"></div>
                 </div>
                 <! --/col-lg-8 -->
             </div>
             <!-- /Proses Değerler Listeleme Bölümü -->

             <!-- Proses Değerler Ekleme Bölümü -->
             <div id="ProsesDegerEkleDiv" runat="server" visible="false">
                 <div class="col-lg-8">
                     <h4>Proses Değer Ekleme</h4>
                     <div class="hline"></div>
                     <p>Bu Bölümden Proses Değerleri Ekleyebilirsiniz</p>
                     <form role="form">
                         <asp:Label ID="ProsesDegerId" runat="server" Visible="false"></asp:Label>
                         <div class="form-group">
                             <label for="InputAdi">Görev</label>
                             <input type="text" class="form-control" id="GorevData" runat="server">
                         </div>
                         <asp:Button ID="ProsesDegerKaydetButton" class="btn btn-theme" Visible="false" runat="server" Text="Kaydet" OnClick="ProsesDegerKaydetButton_Click" />
                         <asp:Button ID="ProsesDegerGuncelleButton" Visible="false" class="btn btn-theme" runat="server" Text="Güncelle" OnClick="ProsesDegerGuncelleButton_Click" />

                     </form>
                 </div>
                 <! --/col-lg-8 -->
             </div>

             <!-- Proses Değerler Ekleme Bölümü -->



         </div>
         <! --/row -->
     </div>
        <! --/container -->
    

    </form>



</asp:Content>
