using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler.Model;
using TaskScheduler.ViewModel;

namespace TaskScheduler
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User user = new User();

                List<UserView> users = user.GetUsersView();
                users_gv.DataSource = users;
                users_gv.DataBind();
            }
        }

        protected void users_gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                int ID = Int32.Parse(e.CommandArgument.ToString());

                Response.Redirect("UserDetails.aspx?userid="+ID);
            }
        }
    }
}