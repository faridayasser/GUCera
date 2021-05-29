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
    public partial class InstructorRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InstReg(object sender, EventArgs e)
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
                if (gen == "Female")
                    g = 1;
                else
                    g = 0;
                if (first.Length > 10 || last.Length > 10 || pass.Length > 10 || mail.Length > 10 || add.Length > 10)
                    Response.Write("All inputs should not exceed 10 characters.");
                else
                {
                    SqlCommand em = new SqlCommand("isExistEmail", conn);
                    em.CommandType = CommandType.StoredProcedure;
                    em.Parameters.Add(new SqlParameter("@email", mail));
                    SqlParameter success = em.Parameters.Add("@var", SqlDbType.Int);
                    success.Direction = ParameterDirection.Output;
                    conn.Open();
                    em.ExecuteNonQuery();
                    conn.Close();
                    if (success.Value.ToString() == "1")
                    {
                        Response.Write("email has already been registered");
                    }
                    else
                    {
                        SqlCommand student = new SqlCommand("InstructorRegister", conn);
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
                        Response.Redirect("InstructorHome.aspx");
                    }
                }
            }
        }
    }
}