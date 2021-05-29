<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreditCard.aspx.cs" Inherits="GUCera.CreditCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        enter your credit card details:-<br />
        <br />
        Number<p>
            <asp:TextBox ID="no" runat="server"></asp:TextBox>
        </p>
        <p>
            CardHolder Name</p>
        <asp:TextBox ID="chn" runat="server"></asp:TextBox>
        <p>
            Expiry Date</p>
        <p>
            <asp:TextBox ID="ed" runat="server"></asp:TextBox>
        &nbsp;&quot;dd-mm-yyyy&quot;</p>
        <p>
            CVV</p>
        <p>
            <asp:TextBox ID="cv" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="save" runat="server" Text="save" OnClick="save_Click" />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </p>
    </form>
</body>
</html>
