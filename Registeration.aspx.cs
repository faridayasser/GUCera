using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class Registeration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Studentregister(object sender, EventArgs e)
        {
            Response.Redirect("StudentRegister.aspx");
        }

        protected void Instregister(object sender, EventArgs e)
        {
            Response.Redirect("InstructorRegister.aspx");
        }
    }
}