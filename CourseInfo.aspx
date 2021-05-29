
<label >COURSE INFORMATION:</label>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseInfo.aspx.cs" Inherits="GUCera.CourseInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        </p>
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
      
        <asp:DropDownList ID="list" runat="server">
        </asp:DropDownList>
         
       
            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        </p>
         
        <p>
            <asp:Button ID="enroll" runat="server" Text="Enroll" OnClick="enroll_Click" />
            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
        </p>
        <p>
            &nbsp; </p>
      
       
    </form>
</body>
</html>
