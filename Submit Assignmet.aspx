<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Submit Assignmet.aspx.cs" Inherits="GUCera.Submit_Assignmet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Please submit Assignment"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Student id:"></asp:Label>
            <br />
            <asp:TextBox ID="userid" runat="server"></asp:TextBox>
            &nbsp;<br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Course id:"></asp:Label>
            <br />
            <asp:TextBox ID="courid" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Assignmet Type:"></asp:Label>
            <br />
            <asp:TextBox ID="assigtype" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Assignment number:"></asp:Label>
            <br />
            <asp:TextBox ID="assignumber" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="signin" runat="server" Text="submit" OnClick="submitAssig" Width="121px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="home page" OnClick="Button1_Click" Width="121px" />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
