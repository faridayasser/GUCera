using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace GUCera
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

           protected void Viewallcourses(object sender, EventArgs e)

        {
            Response.Redirect("viewcourses.aspx");
            


        }



        protected void Coursesnotaccepted(object sender, EventArgs e)

        {
            Response.Redirect("courses not accepted.aspx");
            

        }

        protected void Acceptrejectcourses(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(ConnStr);
            String c = TextBox8.Text;
            String s = TextBox9.Text;
            if (s.Length == 0)
            {
                Response.Write("one of the inputs is empty");

            }
            else
            {
                int id2 = Int16.Parse(TextBox9.Text);

                SqlCommand AcceptCoursesproc = new SqlCommand("AdminAcceptRejectCourse", conn);
                AcceptCoursesproc.CommandType = CommandType.StoredProcedure;
                SqlCommand checkcid = new SqlCommand("checkcid", conn);
                checkcid.CommandType = CommandType.StoredProcedure;
                checkcid.Parameters.Add(new SqlParameter("@cid", id2));
                SqlParameter checkc = checkcid.Parameters.Add("@checkc", SqlDbType.Bit);
                checkc.Direction = ParameterDirection.Output;
                conn.Open();
                checkcid.ExecuteNonQuery();
                conn.Close();
                if (c.Length == 0 || s.Length == 0)
                {
                    Response.Write("one of the inputs is empty");
                }
                else if (!Convert.ToBoolean(checkc.Value))
                {
                    Response.Write("please enter a valid course id");
                }
                else
                {


                    int id1 = Int16.Parse(TextBox8.Text);
                    AcceptCoursesproc.Parameters.Add(new SqlParameter("@adminid", id1));
                    AcceptCoursesproc.Parameters.Add(new SqlParameter("@courseId", id2));

                    conn.Open();
                    AcceptCoursesproc.ExecuteNonQuery();
                    conn.Close();

                    Response.Write("done!");
                }

            }
        }

        protected void Createpromocode(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(ConnStr);

            String ids = TextBox5.Text;
            String discs = TextBox4.Text;
            String code1 = TextBox1.Text;
            
            String issue1 = TextBox2.Text;
            String expiry1 = TextBox3.Text;
            
            DateTime dDate;
            SqlCommand Createpromoproc = new SqlCommand("AdminCreatePromocode", conn);
            Createpromoproc.CommandType = CommandType.StoredProcedure;

            SqlCommand checkpid = new SqlCommand("checkPidd", conn);
            checkpid.CommandType = CommandType.StoredProcedure;
            checkpid.Parameters.Add(new SqlParameter("@pid", code1));
            SqlParameter checkp = checkpid.Parameters.Add("@check", SqlDbType.Bit);
            checkp.Direction = ParameterDirection.Output;
            conn.Open();
            checkpid.ExecuteNonQuery();
            conn.Close();
            if (code1.Length == 0 || ids.Length == 0 || discs.Length == 0 || issue1.Length == 0 || expiry1.Length == 0)
            {
                Response.Write("one of the inputs is empty");
            }
            else if (code1.Length > 6) {
                Response.Write("Please enter code less than 7 characters");

            }
            else if (!DateTime.TryParse(issue1, out dDate))
            {
                Response.Write("please enter the date in the given format");
            }
            else if (!DateTime.TryParse(expiry1, out dDate))
            {
                Response.Write("please enter the date in the given format");
            }
            else if (Convert.ToBoolean(checkp.Value))
            {
                Response.Write(" This code exists");
            }

            else
            {
                int id = Int16.Parse(TextBox5.Text);
                decimal disc = decimal.Parse(TextBox4.Text);
                DateTime issue = Convert.ToDateTime(issue1);
                DateTime expiry = Convert.ToDateTime(expiry1);

                Createpromoproc.Parameters.Add(new SqlParameter("@code", code1));
                Createpromoproc.Parameters.Add(new SqlParameter("@issueDate", issue));
                Createpromoproc.Parameters.Add(new SqlParameter("@expiryDate", expiry));
                Createpromoproc.Parameters.Add(new SqlParameter("@discount", disc));
                Createpromoproc.Parameters.Add(new SqlParameter("@adminid", id));

                conn.Open();
                Createpromoproc.ExecuteNonQuery();
                conn.Close();

                Response.Write("done!");


            }
        }

        protected void Issuepromocode(object sender, EventArgs e)
        {
            string ConnStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(ConnStr);
            String si = TextBox6.Text;
            String pid = TextBox7.Text;

            if (si.Length == 0 || pid.Length == 0)
            {
                Response.Write("one of the inputs is empty");
            }
            else
            {
                int id = Int16.Parse(TextBox6.Text);

                SqlCommand Issuepromoproc = new SqlCommand("AdminIssuePromocodeToStudent", conn);
                Issuepromoproc.CommandType = CommandType.StoredProcedure;
                SqlCommand checkpid = new SqlCommand("checkPidd", conn);
                checkpid.CommandType = CommandType.StoredProcedure;
                SqlCommand checksid = new SqlCommand("checksidd", conn);
                checksid.CommandType = CommandType.StoredProcedure;

                checkpid.Parameters.Add(new SqlParameter("@pid", pid));
                checksid.Parameters.Add(new SqlParameter("@sid", id));

                SqlParameter checkp = checkpid.Parameters.Add("@check", SqlDbType.Bit);
                SqlParameter checks = checksid.Parameters.Add("@checks", SqlDbType.Bit);

                checkp.Direction = ParameterDirection.Output;
                checks.Direction = ParameterDirection.Output;

                conn.Open();

                checkpid.ExecuteNonQuery();
                checksid.ExecuteNonQuery();
                conn.Close();
                if (si.Length == 0 || pid.Length == 0)
                {
                    Response.Write("one of the inputs is empty");
                }
                else if (!Convert.ToBoolean(checkp.Value))
                {
                    Response.Write("please enter a valid promocode id ");
                }
                else if (!Convert.ToBoolean(checks.Value))
                {
                    Response.Write("please enter a valid student id ");
                }
                else
                {


                    Issuepromoproc.Parameters.Add(new SqlParameter("@sid", id));

                    Issuepromoproc.Parameters.Add(new SqlParameter("@pid", pid));

                    conn.Open();
                    Issuepromoproc.ExecuteNonQuery();
                    conn.Close();

                    Response.Write("done!");
                }
            }
        }
        protected void Addnumber(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String num = phonenumber.Text;
            int id = (int)Session["user"];
            if (num.Length != 11)
                Response.Write("Phone number should be 11 numbers");
            else
            {

                SqlCommand mobile = new SqlCommand("addMobile", conn);
                mobile.CommandType = CommandType.StoredProcedure;
                mobile.Parameters.Add(new SqlParameter("@mobile_number", num));
                mobile.Parameters.Add(new SqlParameter("@id", id));

                conn.Open();
                mobile.ExecuteNonQuery();
                conn.Close();


            }

        }

    }
}

