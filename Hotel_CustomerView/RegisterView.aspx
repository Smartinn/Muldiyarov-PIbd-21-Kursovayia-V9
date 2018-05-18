<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterView.aspx.cs" Inherits="Hotel_CustomerView.RegisterView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #Password1 {
            width: 160px;
        }
        #Password2 {
            width: 160px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Name" runat="server" Width ="120px">Фамилия</asp:Label>
                        <asp:TextBox ID="TextBox" runat="server" Width="160px"></asp:TextBox>
            <br />
            <asp:Label ID="Label1" runat="server"  Width ="120px">Имя</asp:Label>
                       <asp:TextBox ID="TextBox1" runat="server" Width="160px"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server"  Width ="120px">Login</asp:Label>
                       <asp:TextBox ID="TextBox3" runat="server" Width="160px"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server"  Width ="120px">@Mail</asp:Label>
                       <asp:TextBox ID="TextBox2" runat="server" Width="160px"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server"  Width ="120px">Password</asp:Label>
                       <asp:TextBox ID="TextBox4" Type="Password" runat="server" maxlength="4" minlength="4" Width="160px"/>
            <br />
            <asp:Label ID="Label5" runat="server"  Width ="120px">PasswordConfirm</asp:Label>
                       <asp:TextBox ID="TextBox5" Type="Password" runat="server" maxlength="4" minlength="4" Width="160px"/>
            <br />
            <asp:Button ID="ButtonAdd" runat="server" Text="Регистрация" OnClick="ButtonAdd_Click" />
            <asp:Button ID="ButtonCancel" runat="server" Text="Отмена" OnClick="ButtonCancel_Click" />
        </div>
    </form>
</body>
</html>
