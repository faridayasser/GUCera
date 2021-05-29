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
    public partial class viewProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label mylab = new Label();
            mylab.Text = "My profile";
            h1.Controls.Add(mylab);
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand viewProfproc = new SqlCommand("viewMyProfile", conn);
            viewProfproc.CommandType = CommandType.StoredProcedure;
            viewProfproc.Parameters.Add(new SqlParameter("@id", Session["user"]));
            conn.Open();
            SqlDataReader rdr = viewProfproc.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                int i = rdr.GetInt32(rdr.GetOrdinal("id"));
                Label l = new Label();
                l.Text = "\n" + "id:" + i.ToString();
                String name = rdr.GetString(rdr.GetOrdinal("FirstName"))+" "+ rdr.GetString(rdr.GetOrdinal("LastName"));
                Label l2 = new Label();
                l2.Text = "\n" + "Full Name:" + name;
                String a = rdr.GetString(rdr.GetOrdinal("Address"));
                Label l3 = new Label();
                l3.Text = "\n" + "Address:" + a;
                String Email = rdr.GetString(rdr.GetOrdinal("Email"));
                Label l4 = new Label();
                l4.Text = "\n" + "Email:" + Email;
               
                decimal gpa= rdr.GetDecimal(rdr.GetOrdinal("gpa"));
                Label l5 = new Label();
                l5.Text = "\n"+"GPA:" + gpa.ToString();
                form1.Controls.Add(l);
                form1.Controls.Add(l2); form1.Controls.Add(l3); form1.Controls.Add(l4); form1.Controls.Add(l5);
            }
        }

       

        protected void home(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
        }
    }
}