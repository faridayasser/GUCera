<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="GUCera.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please log in<br />
            Username:<br />
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
            <br />
            Password:<br />
            <asp:TextBox ID="Password" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="signin" runat="server" OnClick="Login" Text="Login" />
        <br />
        <asp:HyperLink ID="HyperLink1" NavigateUrl="Registeration.aspx" runat="server">I don't have an account</asp:HyperLink>

    </form>
</body>
</html>
