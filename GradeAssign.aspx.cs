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
    public partial class GradeAssign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Grade(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (studenti.Text.Length == 0 || course.Text.Length == 0 || num.Text.Length == 0 || typ.Text.Length == 0 || grade.Text.Length == 0)
            {
                Response.Write("You can't leave an empty field");
            }
            else
            {
                int sid = Int16.Parse(studenti.Text);
                int cid = Int16.Parse(course.Text);
                int number = Int16.Parse(num.Text);
                String type = typ.Text;
                decimal g = decimal.Parse(grade.Text);
                int id = (int)Session["user"];

                SqlCommand check = new SqlCommand("InsGrade", conn);
                check.CommandType = CommandType.StoredProcedure;
                check.Parameters.Add(new SqlParameter("@sid", sid));
                check.Parameters.Add(new SqlParameter("@cid", cid));
                check.Parameters.Add(new SqlParameter("@assignmentNumber", number));
                check.Parameters.Add(new SqlParameter("@type", type));
                check.Parameters.Add(new SqlParameter("@instrId", id));

                SqlParameter success = check.Parameters.Add("@s", SqlDbType.Int);
                success.Direction = ParameterDirection.Output;
                conn.Open();
                check.ExecuteNonQuery();
                conn.Close();

                if (studenti.Text.Length == 0 || course.Text.Length == 0 || num.Text.Length == 0 || type.Length == 0 || grade.Text.Length == 0)
                    Response.Write("Please make sure no fields are empty");
                else if (success.Value.ToString() == "0")
                    Response.Write("Please make sure this assignment exists(all input details are correct), and this student has submitted it");
                else
                {
                    SqlCommand gradea = new SqlCommand("InstructorgradeAssignmentOfAStudent", conn);
                    gradea.CommandType = CommandType.StoredProcedure;
                    gradea.Parameters.Add(new SqlParameter("@sid", sid));
                    gradea.Parameters.Add(new SqlParameter("@cid", cid));
                    gradea.Parameters.Add(new SqlParameter("@assignmentNumber", number));
                    gradea.Parameters.Add(new SqlParameter("@type", type));
                    gradea.Parameters.Add(new SqlParameter("@grade", g));
                    gradea.Parameters.Add(new SqlParameter("@instrId", id));

                    conn.Open();
                    gradea.ExecuteNonQuery();
                    conn.Close();

                    Label msg = new Label();
                    msg.Text = "Assignment graded!";
                    form1.Controls.Add(msg);
                }
            }
        }

        protected void Home(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHome.aspx");
        }
    }
}