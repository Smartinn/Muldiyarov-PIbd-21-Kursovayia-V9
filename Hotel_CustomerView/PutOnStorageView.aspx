<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PutOnStorageView.aspx.cs" Inherits="Hotel_CustomerView.PutOnStorageView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Name" runat="server" Width ="120px">Склад</asp:Label> 
            <asp:DropDownList ID="DropDownListStorage" runat="server" Height="17px" Width="200px" >
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label1" runat="server"  Width ="120px">Чист-средство</asp:Label>
            <asp:DropDownList ID="DropDownListElement" runat="server" Height="17px" Width="200px">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label2" runat="server"  Width ="120px">Количество</asp:Label>
            <asp:TextBox ID="TextBoxCount" runat="server" Width="192px"></asp:TextBox>
            <br />
            <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Сохранить" />
        </div>
    </form>
</body>
</html>
