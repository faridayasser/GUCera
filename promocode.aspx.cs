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
    public partial class promocode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand promo = new SqlCommand("viewPromocode", conn);
            promo.CommandType = CommandType.StoredProcedure;
            promo.Parameters.Add(new SqlParameter("@sid", Session["user"]));
            conn.Open();
            SqlDataReader rdr = promo.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                String code = rdr.GetString(rdr.GetOrdinal("code"));
                Label l1 = new Label();
                l1.Text ="*"+ code;
                String i = rdr.GetString(rdr.GetOrdinal("issueDate"));
                Label l2 = new Label();
                l2.Text =  i;
                String ex = rdr.GetString(rdr.GetOrdinal("ExpiryDate"));
                Label l3 = new Label();
                l3.Text = ex;


            }
        }
    }
}