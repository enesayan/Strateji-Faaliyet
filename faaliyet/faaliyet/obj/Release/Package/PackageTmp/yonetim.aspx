<%@ Page Title="" Language="C#" MasterPageFile="~/FaaliyetMasterPage.Master" AutoEventWireup="true" CodeBehind="yonetim.aspx.cs" Inherits="faaliyet.yonetim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="KKU" runat="server">

    <div class="wrapper">
		<div class="header header-filter" style="background-image: url('../assets/img/city.jpg'); background-size: cover; background-position: top center;">
			<div class="container">
				<div class="row">
					<div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3">
                        <br /><br /><br /><br /><br /><br /><br /><br />
						<div class="card card-signup">
							<form id="Form1" class="form" method="" action="" runat="server">
								
								
								<div class="content">

									<div class="input-group">
										<span class="input-group-addon">
											<i class="material-icons">email</i>
										</span>
										<input type="text" id="F_Email" runat="server" placeholder="Kullanıcı Adı" class="form-control">
									</div>

									<div class="input-group">
										<span class="input-group-addon">
											<i class="material-icons">lock_outline</i>
										</span>
										<input type="password" id="F_Pass" runat="server"  placeholder="Şifre..." class="form-control" />
									</div>

									<!-- If you want to add a checkbox to this form, uncomment this code

									<div class="checkbox">
										<label>
											<input type="checkbox" name="optionsCheckboxes" checked>
											Subscribe to newsletter
										</label>
									</div> -->
								</div>
								<div class="footer text-center">
									
                                    <asp:Button ID="YonetimLoginButton" runat="server" CssClass="btn btn-simple btn-primary btn-lg" Text="Yönetici Girişi" OnClick="YonetimLoginButton_Click" />
								</div>
                                
							</form>
						</div>
					</div>
				</div>
			</div>
            <br /><br />
			<footer class="footer">
		        <div class="container">
		            <nav class="pull-left">
						<ul>
							<li>
								<a href="kku.edu.tr">
									Kırıkkale Üniversitesi
								</a>
							</li>
							
						</ul>
		            </nav>
		            <div class="copyright pull-right">
		                
		            </div>
		        </div>
		    </footer>

		</div>

    </div>



</asp:Content>
