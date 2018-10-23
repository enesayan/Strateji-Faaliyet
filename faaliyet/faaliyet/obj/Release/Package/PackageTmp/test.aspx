<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="faaliyet.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="ProsesVeriKaydetButton" class="btn btn-theme"  runat="server" Text="Kaydet" OnClick="ProsesVeriKaydetButton_Click" />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
            <div class="form-group">
                <asp:Panel ID="PanelProsesVeriler" runat="server" CssClass="form-group">
                </asp:Panel>
            </div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
