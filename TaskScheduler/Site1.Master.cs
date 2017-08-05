using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskScheduler
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            menuItems.Text = "";
            if (Session["username_ts"] != null)
            {
                username_lbl.Text = Session["username_ts"].ToString();

                string roleId = Session["usertype_ts"].ToString();
                string userid = Session["userid_ts"].ToString();
                userprofile_lt.Text = "<li><a href='UserDetails.aspx?userid="+userid+"'><i class='fa fa-user fa-fw'></i> User Profile</a></li>";
                menuItems.Text += @"<li><a href = 'TaskList.aspx'><i class='fa fa-tasks fa-fw'></i> Tasks</a></li>";
                menuItems.Text += @"<li><a href = 'Clients.aspx'><i class='fa fa-users fa-fw'></i> Clients</a></li>";
                if (roleId == "1")
                {
                    menuItems.Text += @"<li><a href = 'Users.aspx'><i class='fa fa-users fa-fw'></i> Users</a></li>";
                    menuItems.Text += @"<li><a href = 'Reports.aspx'><i class='fa fa-table fa-fw'></i> Reports</a></li>";
                    menuItems.Text += @"<li><a href = 'OrganizationStructure.aspx'><i class='fa fa-table fa-fw'></i> Organization Structure</a></li>";
                    menuItems.Text += @"<li><a href = 'OrganizationNature.aspx'><i class='fa fa-table fa-fw'></i> Organization Nature</a></li>";
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}