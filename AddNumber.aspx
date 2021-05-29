<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNumber.aspx.cs" Inherits="GUCera.AddNumber" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Add Phone Number"></asp:Label>
        <br />
        <div>
            <br />
            <asp:TextBox ID="phonenumber" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Addnumber"  Text="Add" />
        </div>
    </form>
</body>
</html>
