using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class StudentRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Studentreg(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            if (firstname.Text.Length == 0 || lastname.Text.Length == 0 || password.Text.Length == 0 || email.Text.Length == 0 || address.Text.Length == 0)
            {
                Response.Write("Please make sure no fields are empty");
            }
            else
            {
                String first = firstname.Text;
                String last = lastname.Text;
                String pass = password.Text;
                String mail = email.Text;
                String add = address.Text;
                String gen = gender.SelectedItem.Value;
                byte g;
                SqlCommand n = new SqlCommand("isExistEmail", conn);
                n.CommandType = CommandType.StoredProcedure;
                n.Parameters.Add(new SqlParameter("@email", mail));
                SqlParameter o = n.Parameters.Add("@var", SqlDbType.Bit);

                o.Direction = ParameterDirection.Output;
                conn.Open();
                n.ExecuteNonQuery();
                conn.Close();

                SqlParameter name1 = n.Parameters.Add("@name1", SqlDbType.VarChar, 10);
                if (gen == "Female")
                {
                    g = 1;
                }
                else
                {
                    g = 0;
                }
                if (first.Length > 10 || last.Length > 10 || pass.Length > 10 || mail.Length > 10 || add.Length > 10)
                {
                    Label8.Text = "One of the inputs exceeds 10 characters.";
                }
                else if (Convert.ToBoolean(o.Value))
                {
                    Label8.Text = "this email belongs to another user";
                }

                else
                {
                    Label8.Text = "";

                    SqlCommand student = new SqlCommand("studentRegister", conn);
                    student.CommandType = CommandType.StoredProcedure;
                    student.Parameters.Add(new SqlParameter("@first_name", first));
                    student.Parameters.Add(new SqlParameter("@last_name", last));
                    student.Parameters.Add(new SqlParameter("@password", pass));
                    student.Parameters.Add(new SqlParameter("@email", mail));
                    student.Parameters.Add(new SqlParameter("@address", add));
                    student.Parameters.Add(new SqlParameter("@gender", g));

                    conn.Open();
                    student.ExecuteNonQuery();
                    conn.Close();

                    SqlCommand getID = new SqlCommand("getUserID", conn);
                    getID.CommandType = CommandType.StoredProcedure;
                    getID.Parameters.Add(new SqlParameter("@mail", mail));

                    SqlParameter id = getID.Parameters.Add("@id", SqlDbType.Int);
                    id.Direction = ParameterDirection.Output;
                    conn.Open();
                    getID.ExecuteNonQuery();
                    conn.Close();
                    int i = (int)id.Value;
                    Session["user"] = i;
                    Session["name"] = (String)first + " " + last;
                    Response.Redirect("Student.aspx");

                }


            }

            


        }

    }
}