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
    public partial class View_Assignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void viewAss(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int Sidd = Int16.Parse(userid.Text);
            string cidd = courid.Text;
            SqlCommand viewAssigProc = new SqlCommand("viewAssign", conn);
            viewAssigProc.CommandType = CommandType.StoredProcedure;

            viewAssigProc.Parameters.Add(new SqlParameter("@courseId", cidd));
            viewAssigProc.Parameters.Add(new SqlParameter("@Sid", Sidd));

            conn.Open();

            SqlDataReader rdr = viewAssigProc .ExecuteReader(CommandBehavior.CloseConnection);
            while(rdr.Read())
            {
                String Assignmentcontent = rdr.GetString(rdr.GetOrdinal("content"));
                Label content = new Label();
                content.Text = Assignmentcontent;
                Form.Controls.Add(content);

            }











        }

     

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student2.aspx");
        }
    }
}