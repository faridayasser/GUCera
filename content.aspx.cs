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
    public partial class content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //enrollInCourseViewContent
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand courseproc = new SqlCommand("enrollInCourseViewContent", conn);
            courseproc.CommandType = CommandType.StoredProcedure;
            courseproc.Parameters.Add(new SqlParameter("@id", Session["user"]));
            courseproc.Parameters.Add(new SqlParameter("@cid", Session["course"]));
            conn.Open();
            SqlDataReader rdr = courseproc.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                if (!rdr.IsDBNull(rdr.GetOrdinal("content")))
                {
                    String content = rdr.GetString(rdr.GetOrdinal("content"));
                    HyperLink l = new HyperLink();
                    l.NavigateUrl = content;
                }
            }
        }
    }
}