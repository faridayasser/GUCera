﻿using System;
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
    public partial class ViewCertifcate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void viewcertificat(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int sidd = Int16.Parse(userid.Text);
            int cidd = Int16.Parse(courid.Text);
            SqlCommand viewcertificateproc = new SqlCommand("viewCertificate", conn);
            viewcertificateproc.CommandType = CommandType.StoredProcedure;
            viewcertificateproc.Parameters.Add(new SqlParameter("@sid", sidd));
            viewcertificateproc.Parameters.Add(new SqlParameter("@cid", cidd));

            conn.Open();
            viewcertificateproc.ExecuteNonQuery();
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student2.aspx");
        }
    }
}