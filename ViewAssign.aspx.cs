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
    public partial class ViewAssign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void View(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int id = (int)Session["user"];
            if (cid.Text.Length == 0)
            {
                Response.Write("You can't leave an empty field");
            }
            else
            {
                int c = Int16.Parse(cid.Text);

                SqlCommand checkIns = new SqlCommand("checkInsT", conn);
                checkIns.CommandType = CommandType.StoredProcedure;
                checkIns.Parameters.Add(new SqlParameter("@instrId", id));
                checkIns.Parameters.Add(new SqlParameter("@cid", c));
                SqlParameter success = checkIns.Parameters.Add("@s", SqlDbType.Int);
                success.Direction = ParameterDirection.Output;
                conn.Open();
                checkIns.ExecuteNonQuery();
                conn.Close();
                if (cid.Text.Length == 0)
                    Response.Write("You can't leave an empty field");
                else if (success.Value.ToString() == "0")
                    Response.Write("Sorry, you do not manage this course");
                else
                {
                    SqlCommand assign = new SqlCommand("InstructorViewAssignmentsStudents", conn);
                    assign.CommandType = CommandType.StoredProcedure;
                    assign.Parameters.Add(new SqlParameter("@instrId", id));
                    assign.Parameters.Add(new SqlParameter("@cid", c));

                    conn.Open();
                    GridView grid = new GridView();
                    grid.EmptyDataText = "No records";
                    grid.DataSource = assign.ExecuteReader();
                    grid.DataBind();
                    form1.Controls.Add(grid);
                    conn.Close();
                }
            }
        }

        protected void Home(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHome.aspx");
        }
    }
}