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
    }
}