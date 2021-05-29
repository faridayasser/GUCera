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
    public partial class Submit_Assignmet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void submitAssig(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int sidd = Int16.Parse(userid.Text);
            int cidd = Int16.Parse(courid.Text);
            int Assinumber = Int16.Parse(assignumber.Text);
            string AssiType = assigtype.Text;

            SqlCommand submitAssignproc = new SqlCommand("submitAssign", conn);
            submitAssignproc.CommandType = CommandType.StoredProcedure;
            submitAssignproc.Parameters.Add(new SqlParameter("@sid", sidd));
            submitAssignproc.Parameters.Add(new SqlParameter("@cid", cidd));
            submitAssignproc.Parameters.Add(new SqlParameter("@assignnumber", Assinumber));
            submitAssignproc.Parameters.Add(new SqlParameter("@assignType", AssiType));

            conn.Open();
            submitAssignproc.ExecuteNonQuery();
            conn.Close();

           
   

            if (AssiType == null)
            {
                Response.Write("please enter data correctly");
            }





        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student2.aspx");
        }
    }
}