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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            if (Username.Text.Length == 0 || Password.Text.Length == 0)
            {
                Response.Write("Please make sure no fields are empty");
            }
            else
            {
                int id = Int16.Parse(Username.Text);
                String pass = Password.Text;

                SqlCommand loginproc = new SqlCommand("userLogin", conn);
                loginproc.CommandType = CommandType.StoredProcedure;
                loginproc.Parameters.Add(new SqlParameter("@id", id));
                loginproc.Parameters.Add(new SqlParameter("@password", pass));

                SqlParameter success = loginproc.Parameters.Add("@success", SqlDbType.Int);
                SqlParameter type = loginproc.Parameters.Add("@type", SqlDbType.Int);

                success.Direction = ParameterDirection.Output;
                type.Direction = ParameterDirection.Output;


                conn.Open();
                loginproc.ExecuteNonQuery();
                conn.Close();
                if (success.Value.ToString() == "1")
                {
                    Session["user"] = id;
                    SqlCommand n = new SqlCommand("Insname", conn);
                    n.CommandType = CommandType.StoredProcedure;
                    n.Parameters.Add(new SqlParameter("@id", id));

                    SqlParameter name1 = n.Parameters.Add("@name1", SqlDbType.VarChar, 10);
                    SqlParameter name2 = n.Parameters.Add("@name2", SqlDbType.VarChar, 10);

                    name1.Direction = ParameterDirection.Output;
                    name2.Direction = ParameterDirection.Output;
                    conn.Open();
                    n.ExecuteNonQuery();
                    conn.Close();
                    String n1 = name1.Value.ToString();
                    String n2 = name2.Value.ToString();
                    Session["name"] = (String)n1 + " " + n2;
                    if (type.Value.ToString() == "0")
                        Response.Redirect("InstructorHome.aspx");
                    else if (type.Value.ToString() == "1")
                        Response.Redirect("AdminHome.aspx");
                    else
                        Response.Redirect("Student.aspx");
                }

            }

        }
      
    }
}