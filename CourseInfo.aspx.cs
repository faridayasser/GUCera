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
    public partial class CourseInfo : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Label7.Text = "";
            list.Visible = false;
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand proc = new SqlCommand("courseInformation", conn);
            proc.CommandType = CommandType.StoredProcedure;
            proc.Parameters.Add(new SqlParameter("@id", Session["course"]));
            conn.Open();
            SqlDataReader rdr = proc.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                int i = rdr.GetInt32(rdr.GetOrdinal("id"));
                int i2 = rdr.GetInt32(rdr.GetOrdinal("instructorId"));
                Label l = new Label();
                l.Text = "id:" + i.ToString();
                Label1.Controls.Add(l);
                String name = rdr.GetString(rdr.GetOrdinal("Name"));
                Label l2 = new Label();
                Session["inst"] = i2;
                l2.Text = "name:" + name;
                Label2.Controls.Add(l2);
                if (!rdr.IsDBNull(rdr.GetOrdinal("coursedescription")))
                {


                    String desc = rdr.GetString(rdr.GetOrdinal("coursedescription"));
                    Label l3 = new Label();
                    l3.Text = "descrpition:" + desc;
                    Label3.Controls.Add(l3);
                }
                else
                {
                    Label l3 = new Label();
                    l3.Text = "descrpition:" + "NO description";
                    Label3.Controls.Add(l3);
                }
                String aname = rdr.GetString(rdr.GetOrdinal("FirstName")) + " " + rdr.GetString(rdr.GetOrdinal("LastName"));
                Label l4 = new Label();
                l4.Text = "\n" + "Instructor:" + aname + " " + "(Id:" + i2.ToString() + ")";
                Label4.Controls.Add(l4);
                decimal p = rdr.GetDecimal(rdr.GetOrdinal("price"));
                Label l5 = new Label();
                l5.Text = "price:" + p.ToString();
                Label5.Controls.Add(l5);

            } conn.Close();///


            SqlCommand enr = new SqlCommand("isEnroll", conn);
            enr.CommandType = CommandType.StoredProcedure;
            enr.Parameters.Add(new SqlParameter("@id", Session["user"]));
            enr.Parameters.Add(new SqlParameter("@cid", Session["course"]));

            SqlParameter b = enr.Parameters.Add("@f", SqlDbType.Bit);
            b.Direction = ParameterDirection.Output;
            conn.Open();
            enr.ExecuteNonQuery();
            conn.Close();
            if (Convert.ToBoolean(b.Value))
            {
                ListBox1.Visible = false;
                enroll.Visible = false;
                HyperLink link = new HyperLink();
                link.Text = "view course content";
                link.NavigateUrl = "content.aspx";
                form1.Controls.Add(link);
            }
            else {
                
                    string connStr1 = WebConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
                    SqlConnection conn1 = new SqlConnection(connStr1);
                    SqlCommand ins = new SqlCommand("getCourseInst", conn);
                    ins.CommandType = CommandType.StoredProcedure;
                    ins.Parameters.Add(new SqlParameter("@cid", Session["course"]));
                    conn.Open();
                    rdr = ins.ExecuteReader(CommandBehavior.CloseConnection);
                    while (rdr.Read())
                    {
                        int i = rdr.GetInt32(rdr.GetOrdinal("insid"));
                        String name1 = rdr.GetString(rdr.GetOrdinal("firstName"));
                        String name2 = rdr.GetString(rdr.GetOrdinal("lastName"));

                        list.Items.Add(i.ToString());

                        ListBox1.Items.Add(name1 + " " + name2 + "(" + i.ToString() + ")");
                    }
                    conn.Close();
                    Label7.Text = "please choose an Instructor ID:-";
                    list.Visible = true;
                ListBox1.Visible = true;
                    int x = Int16.Parse(list.SelectedValue);
                }
            }

            protected void enroll_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera32"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand enr = new SqlCommand("isEnroll", conn);
            enr.CommandType = CommandType.StoredProcedure;
            enr.Parameters.Add(new SqlParameter("@id", Session["user"]));
            enr.Parameters.Add(new SqlParameter("@cid", Session["course"]));

            SqlParameter b = enr.Parameters.Add("@f", SqlDbType.Bit);
            b.Direction = ParameterDirection.Output;
            conn.Open();
            enr.ExecuteNonQuery();
            conn.Close();
            if (!Convert.ToBoolean(b.Value)) {
                ListBox1.Visible = false;
                list.Visible = false;
                int x = Int16.Parse(list.SelectedValue);

                    SqlCommand enr1 = new SqlCommand("enrollInCourse", conn);
                    enr1.CommandType = CommandType.StoredProcedure;
                    enr1.Parameters.Add(new SqlParameter("@sid", Session["user"]));
                    enr1.Parameters.Add(new SqlParameter("@cid", Session["course"]));
                    enr1.Parameters.Add(new SqlParameter("@instr ", x));


                    conn.Open();
                    enr1.ExecuteNonQuery();
                    conn.Close();
                ListBox1.Visible = false;
                Label6.Text = "you are now enrrolled in the course";
                    HyperLink link = new HyperLink();
                    link.Text = "view course content";
                    link.NavigateUrl = "content.aspx";
                    form1.Controls.Add(link);
                }
                else
                {
                    Label7.Text = "";
                    list.Visible = false;
                ListBox1.Visible = false;
                    Label6.Text = "you are already enrrolled in the course";
                    HyperLink link = new HyperLink();

                }
            }
        } 
}