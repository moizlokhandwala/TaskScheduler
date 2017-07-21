using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler.Model;

namespace TaskScheduler
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Role role = new Role();

                //userType_ddl.DataSource = role.GetActiveRoles();
                //userType_ddl.DataTextField = "RoleName";
                //userType_ddl.DataValueField = "ID";
                //userType_ddl.DataBind();
            }
        }

        protected void login_btn_Click(object sender, EventArgs e)
        {
            string username = emailid_txt.Text;
            string password = password_txt.Text;

            User user = new User();

            user = user.isUserValid(username, password);
            if (user.isError!=1)
            {
                Session["username_ts"] = user.Name;
                Session["userid_ts"] = user.ID;
                Session["usertype_ts"] = user.role.ID;

                if (user.role.ID == 1)
                {
                    Response.Redirect("Users.aspx");
                }
                else
                {
                    Response.Redirect("TaskList.aspx");
                }
                
            }
            else
            {
                error_lbl.Text = user.ErrorMessage;
                //Response.Redirect("Login.aspx");
            }
        }
    }
}