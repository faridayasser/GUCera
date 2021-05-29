<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewFeedback.aspx.cs" Inherits="GUCera.ViewFeedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Feedback on my Courses"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Please enter course ID"></asp:Label>
            <br />
            <asp:TextBox ID="cid" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="View" Text="View" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Home" Text="Home" />
            <br />
        </div>
    </form>
</body>
</html>
