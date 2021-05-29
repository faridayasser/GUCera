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
    public partial class viewcourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string ConnStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(ConnStr);

            SqlCommand viewcoursesproc = new SqlCommand("AdminViewAllCourses", conn);
            viewcoursesproc.CommandType = CommandType.StoredProcedure;
            viewcoursesproc.Connection = conn;
            conn.Open();
            GridView gridview = new GridView();
            gridview.EmptyDataText = "No records found";
            gridview.DataSource = viewcoursesproc.ExecuteReader();
            gridview.DataBind();
            form1.Controls.Add(gridview);
            conn.Close();



            //SqlDataReader rdr = NotAcceptedproc.ExecuteReader(CommandBehavior.CloseConnection);
            //while (rdr.Read())
            //{


            //String coursename = rdr.GetString(rdr.GetOrdinal("name"));
            //          Label name = new Label
            //        {
            //       Text = coursename
            //       };
            //form1.Controls.Add(name);


            //     String hours = rdr.GetInt32(rdr.GetOrdinal("creditHours"))+"";
            //   Label creditHours = new Label
            //  {
            //    Text = hours
            // };
            //form1.Controls.Add(creditHours);

            //String pri = rdr.GetDecimal(rdr.GetOrdinal("price"))+"";
            //Label price = new Label
            //{
            //   Text = pri
            //};
            //form1.Controls.Add(price);

            //  String cont = rdr.GetString(rdr.GetOrdinal("content"));
            // Label content = new Label
            //   {
            //      Text = cont
            //};
            //form1.Controls.Add(content);

            // String acc = rdr.GetBoolean(rdr.GetOrdinal("accepted"))+"";
            // Label accepted = new Label
            //  {
            //       Text = acc
            // };
            //form1.Controls.Add(accepted);


            //Label courses = new Label
            //{
            //  Text = "Course name:" + " " + coursename + " "
            //   + "Credit hours:" + " " + hours + " "
            //   + "price:" + " " + pri + " "
            //  + "Content:" + " " + cont + " "
            //    + "accepted:" + " " + acc + " " + "<br>    <br/>"
            // };
            //form1.Controls.Add(courses);
        //}
        }
    }





        
    }