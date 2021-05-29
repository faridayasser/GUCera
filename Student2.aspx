<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student2.aspx.cs" Inherits="GUCera.Student2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Student:"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="View Assignment" Width="267px" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="View certificate" Width="267px" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="View Assignment grades" OnClick="Button3_Click" Width="267px" />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" Text="Submit Assignment" Width="267px" OnClick="Button4_Click" />
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" Text="Add feedback" OnClick="Button5_Click" Width="267px" />
        </div>
    </form>
</body>
</html>
