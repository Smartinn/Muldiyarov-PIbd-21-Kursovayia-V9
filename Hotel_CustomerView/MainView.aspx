<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainView.aspx.cs" Inherits="Hotel_CustomerView.MainView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Name" runat="server" Width="120px">Фамилия</asp:Label>
            <asp:Label ID="Label1" runat="server" Width="120px"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Width="120px">Имя</asp:Label>
            <asp:Label ID="Label3" runat="server" Width="120px"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Width="120px">Login</asp:Label>
            <asp:Label ID="Label5" runat="server" Width="120px"></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" Width="120px">Mail</asp:Label>
            <asp:Label ID="Label7" runat="server" Width="120px"></asp:Label>
            <br />
                        <asp:GridView ID="dataGridView" runat="server"  ShowHeaderWhenEmpty="True" BackColor="White" BorderColor="#336666" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" BorderStyle="Double">
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" ForeColor="White" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
