<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="GUCera.AddCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Add Course"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Course Name:"></asp:Label>
        </div>
        <asp:TextBox ID="Coursename" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Credit Hours:"></asp:Label>
        <br />
        <asp:TextBox ID="credithrs" runat="server"></asp:TextBox>
        <br />
        Price:<br />
        <asp:TextBox ID="price" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="courseadd" runat="server" OnClick="Add" Text="Submit" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="home" Text="Home" />
    </form>
</body>
</html>
