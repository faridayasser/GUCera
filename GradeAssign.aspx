<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeAssign.aspx.cs" Inherits="GUCera.GradeAssign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Grade a student's assignment"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Please fill the following"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Student ID:"></asp:Label>
            <br />
            <asp:TextBox ID="studenti" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Course ID:"></asp:Label>
            <br />
            <asp:TextBox ID="course" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Assignmnent Number:"></asp:Label>
            <br />
            <asp:TextBox ID="num" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Assignment Type:"></asp:Label>
            <br />
            <asp:TextBox ID="typ" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Student's grade:"></asp:Label>
            <br />
            <asp:TextBox ID="grade" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Grade" Text="Submit Grade" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Home" Text="Home" />
        </div>
    </form>
</body>
</html>
