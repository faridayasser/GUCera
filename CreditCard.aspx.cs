using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class CreditCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void save_Click(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String number = no.Text;
            String name = chn.Text;
            string cvv = cv.Text;
            String exp = ed.Text;
          
            DateTime dDate;
            SqlCommand n = new SqlCommand("isExistNum", conn);
            n.CommandType = CommandType.StoredProcedure;
            n.Parameters.Add(new SqlParameter("@num", number));
            SqlParameter o = n.Parameters.Add("@var", SqlDbType.Bit);

            o.Direction = ParameterDirection.Output;
            conn.Open();
            n.ExecuteNonQuery();
            conn.Close();

            if (name.Length > 16 || number.Length > 15 || cvv.Length > 3)
                Label1.Text=("One of the inputs exceeds limit of characters.");

            else if(name.Length == 0 || number.Length ==0 || cvv.Length == 0) {
                Label1.Text = ("you cannot leave an empty field.");
            }
            else if (!DateTime.TryParse(exp, out dDate))
            {
 Label1.Text = ("please enter the date in the given format");
            }
            else if(Convert.ToBoolean(o.Value))
            {
                Label1.Text = ("please enter a valid cardNumber");
            }
            
               

            
            else
            {

                SqlCommand credit = new SqlCommand("addCreditCard", conn);
                credit.CommandType = CommandType.StoredProcedure;
                credit.Parameters.Add(new SqlParameter("@sid", Session["user"]));
                credit.Parameters.Add(new SqlParameter("@number",Int16.Parse(number)));

                credit.Parameters.Add(new SqlParameter("@cvv", cvv));
                credit.Parameters.Add(new SqlParameter("@expiryDate",Convert.ToDateTime(exp)));
                credit.Parameters.Add(new SqlParameter("@CardHolderName", name));

                conn.Open();
                credit.ExecuteNonQuery();
                conn.Close();Label1.Text = "saved!";
            }
            
        }
    }
}