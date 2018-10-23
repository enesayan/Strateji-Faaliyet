<%@ Page Title="" Language="C#" MasterPageFile="~/FaaliyetMasterPage.Master"  AutoEventWireup="true" CodeBehind="birimislemler.aspx.cs" Inherits="faaliyet.birimislemler" EnableEventValidation="false"  %>

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


        function Test() {
            var mesaj="";
            $("#KKU_PanelProsesVeriler input").each(function (i, e) {
                mesaj += e.value + ";";
            });
   
            var hidden = document.getElementById('KKU_Hidden');
            hidden.value = mesaj;
        }

        //$("#kapat").click(function () {
        //    $("#KKU_islem_basarili").hide("fade");
        //    console.log("merhaba");
        //});



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

                <div id="yonetim_islemleri" runat="server" visible="true">

                    <div class="col-lg-2 col-md-2 col-sm-2">
                        <div class="he-wrap tpl6">
                            <img src="assets/img/process_img/birim_ekle.jpg" alt="">
                            <div class="he-view">
                                <div class="bg a0" data-animate="fadeIn">
                                    <h3 class="a1" data-animate="fadeInDown">Proses Veri Giriş</h3>
                                    <a href="?ProsesVeri=Ekle" class="dmbutton a2" data-animate="fadeInUp"><i class="fa fa-external-link-square fa-2x"></i></a>
                                </div>
                                <!-- he bg -->
                            </div>
                            <!-- he view -->
                        </div>
                        <!-- he wrap -->
                        <h5 class="ctitle"><a href="?ProsesVeri=listele">Proses Listele</a></h5>
                        <p><a href="?ProsesVeri=Ekle">Proses Veri Ekle</a></p>
                        <div class="hline"></div>
                    </div>
                </div>
                <! --/col-lg-3 -->
            </div>
            <! --/row -->
        </div>
        <! --/container -->

	 <div class="container" id="islemler_div" runat="server">
         <div class="row">
             <!-- uyarı kısmı -->
             <div class="section section-notifications" id="notifications">


                 <div class="alert alert-success " id="islem_basarili" runat="server" visible="false">
                     <div class="container-fluid">
                         <div class="alert-icon">
                             <i class="material-icons">check</i>
                         </div>
                         <button type="button" id="kapat" class="close" data-dismiss="alert" aria-label="Close">
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
                 <div class="col-lg-12 centered">
                     <asp:Literal ID="Literal_Uyari" runat="server"></asp:Literal>
                     <br>
                     <div class="hline"></div>
                 </div>
             </div>
             <!-- /Uyarı Bölümü -->

             <!-- Proses Veri Ekleme Bölümü -->

             <div id="ProsesVeriEkleDiv" runat="server" visible="false">
                 <div class="col-lg-12">
                     <h4>Proses Veri Ekleme</h4>
                     <div class="hline"></div>
                     <p>Prosesler Değerlerine Ait Verileri Bu Bölümden Ekleyebilirsiniz</p>
                     <div class="hline"></div>
                     <asp:DropDownList ID="DropDownDonemler" class="btn btn-danger dropdown-toggle" runat="server" Visible="true" AutoPostBack="False"></asp:DropDownList>
                     <asp:DropDownList ID="DropDownListProses" class="btn btn-danger dropdown-toggle" runat="server" Visible="false" OnSelectedIndexChanged="DropDownListProses_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                     <asp:Button ID="ProsesVeriKaydetButton" class="btn btn-theme" Visible="false" runat="server" Text="Kaydet" OnClientClick="Test()" OnClick="ProsesVeriKaydetButton_Click"  />
                     <asp:Button ID="ProsesVeriGuncelleButton" Visible="false" class="btn btn-theme" runat="server" Text="Güncelle" OnClick="ProsesVeriGuncelleButton_Click" />

                     
                     <div class="form-group">
                         <asp:Panel ID="PanelProsesVeriler" runat="server" CssClass="form-group">
                         </asp:Panel>
                         <asp:HiddenField ID="Hidden" runat="server" />
                     </div>
                       

                 </div>

                 <! --/col-lg-8 -->
             </div>
             <!-- /Proses Ekleme Bölümü -->

         </div>
         <%--<row div>--%>
     </div>
        <%--<asp:TabContainer div>--%>
    </form>

</asp:Content>
