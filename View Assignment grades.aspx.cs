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
    public partial class View_Assignment_grades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

      
        protected void viewAssigrades(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            int sidd = Int16.Parse(userid.Text);
            int cidd = Int16.Parse(courid.Text);
            int assinumber = Int16.Parse(asssignumber.Text);
            string assigntype =assigtype.Text;
            SqlCommand viewAssigngradesproc = new SqlCommand("viewAssignGrades", conn);
            viewAssigngradesproc.CommandType = CommandType.StoredProcedure;

            viewAssigngradesproc.Parameters.Add(new SqlParameter("@sid", sidd));
            viewAssigngradesproc.Parameters.Add(new SqlParameter("@cid", cidd));
            viewAssigngradesproc.Parameters.Add(new SqlParameter("@assignnumber", assinumber));
            viewAssigngradesproc.Parameters.Add(new SqlParameter("@assignType", assigntype));

            SqlParameter @assignGrade = viewAssigngradesproc.Parameters.Add("@assignGrade", SqlDbType.Int);

            assignGrade.Direction = ParameterDirection.Output;


            conn.Open();
            viewAssigngradesproc.ExecuteNonQuery();
            conn.Close();




        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student2.aspx");
        }
    }
}