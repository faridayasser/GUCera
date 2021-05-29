<P>Student:</P>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="GUCera.Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="h1" runat="server">
    <title></title>
</head>
<body>
   
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button3" runat="server" Text="Add Mobile Number" OnClick="Button3_Click" Width="303px" />
        </div>
         <p>
         <asp:Button ID="Button1" runat="server" OnClick="viewProfile" Text="view my profile" Width="302px" />
         </p>
        <p>
            <asp:Button ID="acCourses" runat="server" Text="Availble Courses" OnClick="acCourses_Click" Width="304px" />
        </p>
        <asp:Button ID="credit" runat="server" Text="Add Credit Card " Width="307px" OnClick="credit_Click" />
        <p>
            <asp:Button ID="Button2" runat="server" Text="PromoCodes" Width="304px" OnClick="Button2_Click" />
        </p>
        <asp:Button ID="Button4" runat="server" Text="others" Width="298px" OnClick="Button4_Click" />
    </form>
</body>
</html>
