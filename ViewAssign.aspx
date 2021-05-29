<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAssign.aspx.cs" Inherits="GUCera.ViewAssign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="View Submitted Assignments of a Course"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Please enter the course ID "></asp:Label>
        <br />
        <asp:TextBox ID="cid" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="View" Text="View" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Home" Text="Home" />
        <br />
    </form>
</body>
</html>
