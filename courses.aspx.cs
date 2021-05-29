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
    public partial class courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand courseproc = new SqlCommand("availableCourses", conn);
            courseproc.CommandType = CommandType.StoredProcedure;
           
            conn.Open();
            SqlDataReader rdr = courseproc.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String name = rdr.GetString(rdr.GetOrdinal("name"));

                Button a = new Button();
                a.Text = name;
                a.ID = name;

                a.Click += new EventHandler(button_Click);
                form1.Controls.Add(a);
            }
        }
        protected void button_Click(object sender, EventArgs e)
       {
            Button button = sender as Button;
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
          
            SqlCommand getCID = new SqlCommand("getCID", conn);
            getCID.CommandType = CommandType.StoredProcedure;
            getCID.Parameters.Add(new SqlParameter("@name", button.ID));

            SqlParameter id = getCID.Parameters.Add("@id", SqlDbType.Int);
            id.Direction = ParameterDirection.Output;
            conn.Open();
            getCID.ExecuteNonQuery();
            conn.Close();
            int i = (int)id.Value;
            Session["course"] = i;
            Session["cname"] = button.ID;
            Response.Redirect("CourseInfo.aspx");
            // identify which button was clicked and perform necessary actions
        }
    }
}