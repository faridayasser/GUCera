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
    public partial class AddCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (price.Text.Length == 0 || Coursename.Text.Length == 0 || credithrs.Text.Length == 0)
            {
                Response.Write("Please make sure no fields are empty");
            }
            else
            {
                decimal p = decimal.Parse(price.Text);
                String name = Coursename.Text;
                int credit = Int16.Parse(credithrs.Text);
                int id = (int)Session["user"];
                if (name.Length > 10)
                    Response.Write("Course name should be within 10 characters");
                else
                {

                    SqlCommand addcourseproc = new SqlCommand("InstAddCourse", conn);
                    addcourseproc.CommandType = CommandType.StoredProcedure;
                    addcourseproc.Parameters.Add(new SqlParameter("@price", p));
                    addcourseproc.Parameters.Add(new SqlParameter("@name", name));
                    addcourseproc.Parameters.Add(new SqlParameter("@creditHours", credit));
                    addcourseproc.Parameters.Add(new SqlParameter("@instructorId", id));

                    conn.Open();
                    addcourseproc.ExecuteNonQuery();
                    conn.Close();

                    Label msg = new Label();
                    msg.Text = "Course added!";
                    form1.Controls.Add(msg);
                }
            }
        }

        protected void home(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHome.aspx");
        }
    }
}