using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler.Model;

namespace TaskScheduler
{
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["userid"] != null) { 
            int userID = Int32.Parse(Request["userid"].ToString());
                User user = new User();
                user = user.GetUserDetails(userID);
                username_lbl.Text = user.Name;
                permanentaddress_lbl.Text = user.AddressPermanent;
                localaddress_lbl.Text = user.AddressLocal;
            }
            else
            {
                Response.Redirect("Users.aspx");
            }

        }
    }
}