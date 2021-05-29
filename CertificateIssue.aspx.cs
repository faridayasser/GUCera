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
    public partial class CertificateIssue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void IssueCert(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (CourseID.Text.Length == 0 || StudentID.Text.Length == 0)
                Response.Write("Please make sure no fields are empty");
            else
            {
                int cid = Int16.Parse(CourseID.Text);
                int sid = Int16.Parse(StudentID.Text);
                int id = (int)Session["user"];
                DateTime issuedate = DateTime.Now;
           
                SqlCommand ch = new SqlCommand("checkStu", conn);
                ch.CommandType = CommandType.StoredProcedure;
                ch.Parameters.Add(new SqlParameter("@sid", sid));
                ch.Parameters.Add(new SqlParameter("@cid", cid));
                SqlParameter suc = ch.Parameters.Add("@s", SqlDbType.Int);
                suc.Direction = ParameterDirection.Output;

                conn.Open();
                ch.ExecuteNonQuery();
                conn.Close();
                if (suc.Value.ToString() == "1")
                {
                    SqlCommand calc = new SqlCommand("calculateFinalGrade", conn);
                    calc.CommandType = CommandType.StoredProcedure;
                    calc.Parameters.Add(new SqlParameter("@sid", sid));
                    calc.Parameters.Add(new SqlParameter("@cid", cid));
                    calc.Parameters.Add(new SqlParameter("@insId", id));
                    conn.Open();
                    calc.ExecuteNonQuery();
                    conn.Close();

                    SqlCommand check = new SqlCommand("studentsucces", conn);
                    check.CommandType = CommandType.StoredProcedure;
                    check.Parameters.Add(new SqlParameter("@sid", sid));
                    check.Parameters.Add(new SqlParameter("@cid", cid));
                    check.Parameters.Add(new SqlParameter("@instid", id));

                    SqlParameter success = check.Parameters.Add("@success", SqlDbType.Int);
                    success.Direction = ParameterDirection.Output;

                    conn.Open();
                    check.ExecuteNonQuery();
                    conn.Close();
                    if (success.Value.ToString() == "1")
                    {

                        SqlCommand issueCert = new SqlCommand("InstructorIssueCertificateToStudent", conn);
                        issueCert.CommandType = CommandType.StoredProcedure;
                        issueCert.Parameters.Add(new SqlParameter("@cid", cid));
                        issueCert.Parameters.Add(new SqlParameter("@sid", sid));
                        issueCert.Parameters.Add(new SqlParameter("@insId", id));
                        issueCert.Parameters.Add(new SqlParameter("@issueDate", issuedate));

                        conn.Open();
                        issueCert.ExecuteNonQuery();
                        conn.Close();
                        Label msg = new Label();
                        msg.Text = "Certificate Issued";
                        form1.Controls.Add(msg);
                    }
                    else
                        Response.Write("Student did not pass this course");
                }
                else
                    Response.Write("Student does not take this course");
            }
        }

        protected void Home(object sender, EventArgs e)
        {
            Response.Redirect("InstructorHome.aspx");
        }
    }
}