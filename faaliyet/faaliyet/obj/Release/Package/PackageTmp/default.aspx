<%@ Page Title="" Language="C#" MasterPageFile="~/FaaliyetMasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="faaliyet._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="KKU" runat="server">

    <!-- *****************************************************************************************************************
	 BLUE WRAP
	 ***************************************************************************************************************** -->
	<div id="blue">
        
	    <div class="container">
			<div class="row">
				<h3><asp:Label ID="Hosgeldiniz_label" runat="server" Text="Hoşgeldiniz"></asp:Label></h3>
			</div><!-- /row -->
	    </div> <!-- /container -->
	</div><!-- /blue -->

	 
	<!-- *****************************************************************************************************************
	 AGENCY ABOUT
	 ***************************************************************************************************************** -->
    <div class="container mtb">
	 	<div class="row">
	 		<div class="col-lg-6">
	 			<img class="img-responsive" src="assets/img/strateji.jpg" alt="">
	 		</div>
	 		
	 		<div class="col-lg-6">
		 		<h4>Kırıkkale Üniversitesi Strateji Faaliyet Takip Programı</h4>
		 		<p> Kırıkkale Üniversitesi Strateji daire başkanlığı tarafından üniversitede yer alan her bir birimlerin faaliyet raporlarını elde etmeye yarayan bu program birimler ve strateji daire başkanlığı bünyesinde yer almaktadır   .</p>
				<p> Bu sistemde her birim kendi faaliyet hareketlerini periyodik olarak (aylık) sisteme girmesi sağlanacaktır. Böylece strateji daire başkanlığı tarafından veri kontrolü ve raporlama sürecinde hızlı, verimli ve güvenli bir strateji faaliyet takibi sağlanmaktadır. </p>
			</div>
	 	</div><! --/row -->
	 </div><! --/container -->

	
	 <div id="twrap">
	 	<div class="container centered">
	 		<div class="row">
	 			<div class="col-lg-8 col-lg-offset-2">
	 			<i class="fa fa-comment"></i>
	 			<p>Bu programın en önenmli hedefi Kırıkkale Üniversitesi kaynaklarının etkinlik ve verimliliğini sağlamak, saydamlık ve hesap verebilirlik çerçevesinde kaynakların, mali işlem ve süreçlerin yönetiminde ihtiyaç duyduğu analizleri yaparak Üniversitenin gelişimine katkı sağlamak ve mali işlemler ile karar alma süreçlerini iyileştirerek karar destek sistemleri geliştirmektir.</p>
	 			<h4><br/>Bilgi İşlem Dairesi Başkanlığı Yazılım Alt Çalışma Grubu</h4>
	 			</div>
	 		</div><! --/row -->
	 	</div><! --/container -->
	 </div><! --/twrap -->
	 
	<!-- *****************************************************************************************************************
	 OUR CLIENTS
	 ***************************************************************************************************************** -->
	 <div id="cwrap">
		 <div class="container">
		 	<div class="row centered">
			 	<h3>Diğer Programlar</h3>
			 	<div class="col-lg-3 col-md-2 col-sm-2">
			 		<img src="assets/img/clients/client01.png" class="img-responsive">
			 	</div>
			 	<div class="col-lg-3 col-md-2 col-sm-2">
			 		<img src="assets/img/clients/client02.png" class="img-responsive">
			 	</div>
			 	<div class="col-lg-3 col-md-2 col-sm-2">
			 		<img src="assets/img/clients/client03.png" class="img-responsive">
			 	</div>
			 	<div class="col-lg-3 col-md-2 col-sm-2">
			 		<img src="assets/img/clients/client04.png" class="img-responsive">
			 	</div>
		 	</div><! --/row -->
		 </div><! --/container -->
	 </div><! --/cwrap -->

</asp:Content>
