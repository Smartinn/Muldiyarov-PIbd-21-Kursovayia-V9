<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClearView.aspx.cs" Inherits="Hotel_CustomerView.ClearView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #name {
            width: 144px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Name" runat="server" Width ="120px">Название</asp:Label>
            <asp:TextBox ID="TextBox" runat="server" Width="160px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ButtonSave" runat="server" Text="Сохранить" OnClick="ButtonSave_Click" />
            <asp:Button ID="ButtonCancel" runat="server" Text="Отмена" OnClick="ButtonCancel_Click" />
        </div>
    </form>
</body>
</html>
