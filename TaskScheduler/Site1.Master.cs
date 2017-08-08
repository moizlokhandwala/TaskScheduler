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
                    menuItems.Text += @" <li>
                            <a href='#'><i class='fa fa-wrench fa-fw'></i> Setting<span class='fa arrow'></span></a>
                            <ul class='nav nav-second-level'>
                                <li>
                                    <li><a href = 'OrganizationStructure.aspx'><i class='fa fa-sitemap fa-fw'></i> Organization Structure</a></li>
                                </li>
                                <li>
                                    <li><a href = 'OrganizationNature.aspx'><i class='fa fa-building fa-fw'></i> Organization Nature</a></li>
                                </li>
                               
                            </ul>
                        </li>";
                 //   menuItems.Text += @"<li><a href = 'OrganizationStructure.aspx'><i class='fa fa-sitemap fa-fw'></i> Organization Structure</a></li>";
                 //   menuItems.Text += @"<li><a href = 'OrganizationNature.aspx'><i class='fa fa-building fa-fw'></i> Organization Nature</a></li>";
                    menuItems.Text += @" <li>
                            <a href='#'><i class='fa fa-bar-chart-o fa-fw'></i> Reports<span class='fa arrow'></span></a>
                            <ul class='nav nav-second-level'>
                                <li>
                                    <a href = 'flot.html'>Attendance Summary</a>
                                </li>
                                <li>
                                    <a href = 'morris.html'>Login/Logout History</a>
                                </li>
                                <li>
                                    <a href = 'morris.html'>Task Report</a>
                                </li>
                            </ul>
                        </li>";
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}