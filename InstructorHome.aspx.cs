using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace GUCera
{
    public partial class InstructorHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = (int)Session["user"];
            iid.Text = "Your ID is: "+id + "";

            String connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand courses = new SqlCommand("InstructorViewAcceptedCoursesByAdmin", conn);
            courses.CommandType = CommandType.StoredProcedure;
            courses.Parameters.Add(new SqlParameter("@instrId", id));

            conn.Open();
            GridView grid = new GridView();
            grid.EmptyDataText = "No records";
            grid.DataSource = courses.ExecuteReader();
            grid.DataBind();
            form1.Controls.Add(grid);
            conn.Close();
        }

        protected void Defassignment(object sender, EventArgs e)
        {
            Response.Redirect("DefineAssign.aspx");
        }

        protected void Viewassign(object sender, EventArgs e)
        {
            Response.Redirect("ViewAssign.aspx");
        }

        protected void Gradeassign(object sender, EventArgs e)
        {
            Response.Redirect("GradeAssign.aspx");
        }

        protected void Feedback(object sender, EventArgs e)
        {
            Response.Redirect("ViewFeedback.aspx");
        }

        protected void Certificate(object sender, EventArgs e)
        {
            Response.Redirect("CertificateIssue.aspx");
        }

        protected void AddNumber(object sender, EventArgs e)
        {
            Response.Redirect("AddNumber.aspx");
        }

        protected void Certificateissue(object sender, EventArgs e)
        {
            Response.Redirect("CertificateIssue.aspx");
        }

        protected void Addcourse(object sender, EventArgs e)
        {
            Response.Redirect("AddCourse.aspx");
        }
    }
}