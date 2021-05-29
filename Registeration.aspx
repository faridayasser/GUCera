<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registeration.aspx.cs" Inherits="GUCera.Registeration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Are you a student or an instructor?"></asp:Label>
        <div>
            <br />
            <asp:Button ID="Button1" runat="server" Onclick="Studentregister"  Text="Student" Width="211px" />
            <asp:Button ID="Button2" runat="server" Onclick="Instregister" Text="Instructor" Width="194px" />
        </div>
    </div>
    </form>
</body>
</html>
