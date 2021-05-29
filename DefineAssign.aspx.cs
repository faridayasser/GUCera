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
    public partial class DefineAssign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DefAssign(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            
            if (cid.Text.Length == 0 || num.Text.Length == 0 || type.Text.Length == 0 || grade.Text.Length == 0 || weight.Text.Length == 0 || content.Text.Length == 0 || deadline.Text.Length == 0)
            { 
                Response.Write("Please make sure no fields are empty"); 
            }
            else
            {
                int courseid = Int16.Parse(cid.Text);
                int id = (int)Session["user"];

                SqlCommand checkIns = new SqlCommand("checkInsT", conn);
                checkIns.CommandType = CommandType.StoredProcedure;
                checkIns.Parameters.Add(new SqlParameter("@instrId", id));
                checkIns.Parameters.Add(new SqlParameter("@cid", courseid));
                SqlParameter success = checkIns.Parameters.Add("@s", SqlDbType.Int);
                success.Direction = ParameterDirection.Output;
                conn.Open();
                checkIns.ExecuteNonQuery();
                conn.Close();

                if (success.Value.ToString() == "0")
                {
                    Response.Write("Sorry, you do not manage this course");
                }
                else
                {
                    String typ = type.Text;
                    decimal w = decimal.Parse(weight.Text);
                    DateTime ddate;

                    if (typ.Length > 10)
                    {
                        Response.Write("Type has to be within 10 characters");
                    }
                    else if (!(typ == "quiz" || typ == "exam" || typ == "project"))
                    {
                        Response.Write("Assignment types can only be exam, quiz or project");
                    }
                    else if (w >= 100 || w <= 0)
                    {
                        Response.Write("weight has to be between 0 and 100");
                    }
                    else if(!DateTime.TryParse(deadline.Text, out ddate))
                    {
                        Response.Write("Please enter date in format [mm/dd/yyyy]");
                    }
                    else
                    {
                       
                        int number = Int16.Parse(num.Text);
                        int fullgrade = Int16.Parse(grade.Text);
                        String con = content.Text;
                        DateTime deadlin = Convert.ToDateTime(deadline.Text);

                        SqlCommand defineAssign = new SqlCommand("DefineAssignmentOfCourseOfCertianType", conn);
                        defineAssign.CommandType = CommandType.StoredProcedure;
                        defineAssign.Parameters.Add(new SqlParameter("@cid", courseid));
                        defineAssign.Parameters.Add(new SqlParameter("@number", number));
                        defineAssign.Parameters.Add(new SqlParameter("@type", typ));
                        defineAssign.Parameters.Add(new SqlParameter("@weight", w));
                        defineAssign.Parameters.Add(new SqlParameter("@content", con));
                        defineAssign.Parameters.Add(new SqlParameter("@deadline", deadlin));
                        defineAssign.Parameters.Add(new SqlParameter("@instId", id));
                        defineAssign.Parameters.Add(new SqlParameter("@fullGrade", fullgrade));


                        conn.Open();
                        defineAssign.ExecuteNonQuery();
                        conn.Close();

                        Response.Write("Assignment defined");
                    }
                }
            }
        }

        protected void Home(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHome.aspx");
        }
    }
}