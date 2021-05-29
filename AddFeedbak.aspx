<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFeedbak.aspx.cs" Inherits="GUCera.Add_Feedbak" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Please enter feedback"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Student id:"></asp:Label>
            <br />
            <asp:TextBox ID="userid" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Course id:"></asp:Label>
            <br />
            <asp:TextBox ID="courid" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Comment:"></asp:Label>
            <br />
            <asp:TextBox ID="comment" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="signin" runat="server" OnClick="AddFeedback" Text="submit" Width="131px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="Home page" OnClick="Button1_Click" Width="131px" />
        </div>
    </form>
</body>
</html>
