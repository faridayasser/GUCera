<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorHome.aspx.cs" Inherits="GUCera.InstructorHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Welcome Instructor!"></asp:Label>
            <br />
            <asp:Label ID="iid" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="number" runat="server" onClick="AddNumber" Text="Add Number" Width="800px" style="margin-top: 0px" />
            <br />
            <asp:Button ID="addcourse" runat="server"  onClick="Addcourse" Text="Add New Course" Height="35px" Width="398px"/>
            <asp:Button ID="defassignment" runat="server" onClick="Defassignment" Text="Choose Course To Define its Assignments" Height="35px" Width="398px" />
            <br />
            <asp:Button ID="gradeassign" runat="server" onClick="Gradeassign" Text="Grade Submitted Assignments" Height="35px" Width="398px" />
            <asp:Button ID="certificate" runat="server" onClick="Certificateissue" Text="Issue a Certificate for a Student" Height="35px" Width="398px" />
            <br />
            <asp:Button ID="viewassignments" runat="server" onClick="Viewassign" Text="View Submitted Assignments" Height="35px" Width="398px" />
            <asp:Button ID="feedback" runat="server" onClick="Feedback" Text="View Feedback on my Courses" Height="35px" Width="398px" />
            <br />
            <br />
            My accepted courses:<br />
        </div>
    </form>
</body>
</html>
