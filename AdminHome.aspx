<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="GUCera.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           
            <br />
            <asp:Button ID="view1" runat="server" OnClick="Viewallcourses" Text="view all courses in the system" /> <br />
            <br />
          
            <br />
             <asp:Button ID="Button1" runat="server" OnClick="Coursesnotaccepted" Text="View courses not yet accepted" />
            <br />
            <br />
             
            Add phone number
            
            <br />
            <asp:TextBox ID="phonenumber" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" OnClick="Addnumber"  Text="Add phone number" />
            <br />
            <br />
           Accept/reject requested projects<br />
            <br />
            AdminId:
            <br />
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <br />
            CourseId:
            <br />
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <br />
            <br />

            <asp:Button ID="Button3" runat="server" OnClick="Acceptrejectcourses" Text="accept/reject requested course" />
            <br />
            <br />
           Create new promocode<br />
            <br />
            Promocode code:
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            
            <br />

            Please make sure that date is in this format dd-mm-yyyy
           
            <br />
            Issuedate:<br />
&nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="152px"></asp:TextBox>
            <br />
            Expirydate:
             <br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Discount:
             <br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            AdminId:
             <br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Createpromocode" Text="Create promocode" />
            <br />
            <br />
          Issue a promocode to a student<br />
            <br />
            StudentId:
            <br />
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            PromocodeId:
            <br />
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Issuepromocode" Text="Issue Promocode" />

        </div>
  </form>
</body>
</html>
