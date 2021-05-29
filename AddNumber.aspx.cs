using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GUCera
{
    public partial class AddNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Addnumber(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            if (phonenumber.Text.Length == 0)
            {
                Response.Write("Please make sure no fields are empty");
            }
            else
            {
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

                    Label msg = new Label();
                    msg.Text = "Number added";
                    form1.Controls.Add(msg);

                }
            }

        }
    }
}