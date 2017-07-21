using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskScheduler
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["username_ts"] = null;
            Session["userid_ts"] = null;
            Session["usertype_ts"] = null;

            Response.Redirect("Login.aspx");
        }
    }
}