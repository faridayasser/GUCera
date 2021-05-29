<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefineAssign.aspx.cs" Inherits="GUCera.DefineAssign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Define Assignment for Course"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Please fill the following:"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Course ID:"></asp:Label>
            <br />
            <asp:TextBox ID="cid" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Assignment Details:"></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Number:"></asp:Label>
            <br />
            <asp:TextBox ID="num" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Type:"></asp:Label>
            <br />
            <asp:TextBox ID="type" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Full Grade:"></asp:Label>
            <br />
            <asp:TextBox ID="grade" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Weight:"></asp:Label>
            <br />
            <asp:TextBox ID="weight" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Deadline:"></asp:Label>
            <br />
            <asp:TextBox ID="deadline" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label10" runat="server" Text="Content:"></asp:Label>
            <br />
            <asp:TextBox ID="content" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" onClick="DefAssign" runat="server" Text="Submit" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Home" Text="Home" />
            <br />
        </div>
    </form>
</body>
</html>
