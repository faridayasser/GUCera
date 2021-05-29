using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          Label l = new Label();
            l.Text = (string)Session["name"];
            h1.Controls.Add(l);
        }

        protected void viewProfile(object sender, EventArgs e)
        {
            Response.Redirect("viewProfile.aspx");
        }

        protected void acCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("courses.aspx");
        }

        protected void credit_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreditCard.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("promocode.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("addMobile.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student2.aspx");
        }
    }
}