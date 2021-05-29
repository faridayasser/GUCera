<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View Assignment.aspx.cs" Inherits="GUCera.View_Assignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Please enter data"></asp:Label>
        <div>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Student id:"></asp:Label>
            <br />
            <asp:TextBox ID="userid" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Course id"></asp:Label>
            <br />
            <asp:TextBox ID="courid" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="signin" runat="server" OnClick="viewAss" Text="Log in" Width="124px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="home page" OnClick="Button1_Click" Width="124px" />
            <br />
        </div>
    </form>
</body>
</html>
