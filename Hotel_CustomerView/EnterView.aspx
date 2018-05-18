<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterView.aspx.cs" Inherits="Hotel_CustomerView.EnterView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label4" runat="server"  Width ="120px">Login</asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" Width="160px"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server"  Width ="120px">Password</asp:Label>
            <asp:TextBox ID="TextBox4" Type="Password" runat="server" maxlength="4" minlength="4" Width="160px"/>
            <br />
            <asp:Button ID="ButtonEnter" runat="server" Text="Вход" OnClick="ButtonEnter_Click" />
            <asp:Button ID="Button1" runat="server" Text="Регистрация" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
