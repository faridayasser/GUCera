<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CertificateIssue.aspx.cs" Inherits="GUCera.CertificateIssue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Issue a Certificate for a Student"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Student ID:"></asp:Label>
            <br />
            <asp:TextBox ID="StudentID" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Course ID:"></asp:Label>
            <br />
            <asp:TextBox ID="CourseID" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="IssueCert" Text="Issue" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Home" Text="Home" />
        </div>
    </form>
</body>
</html>
