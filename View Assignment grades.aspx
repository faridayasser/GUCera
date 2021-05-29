<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View Assignment grades.aspx.cs" Inherits="GUCera.View_Assignment_grades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="View Assignmet grades"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Assignment number:"></asp:Label>
            <br />
            <asp:TextBox ID="asssignumber" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Assignment type:"></asp:Label>
            <br />
            <asp:TextBox ID="assigtype" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Course id:"></asp:Label>
            <br />
            <asp:TextBox ID="courid" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Student id:"></asp:Label>
            <br />
            <asp:TextBox ID="userid" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="signin" runat="server" OnClick="viewAssigrades" Text="submit" Width="123px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="home page" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
