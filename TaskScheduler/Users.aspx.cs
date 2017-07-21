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


                for (int i = 0; i < users_gv.Rows.Count; i++)
                {
                    Label lbl = (Label)users_gv.Rows[i].Cells[6].FindControl("status_lbl");
                    Label lbl2 = (Label)users_gv.Rows[i].Cells[2].FindControl("active_lbl");
                   
                    String status = lbl2.Text;

                    if (status == "Inactive")
                    {
                     
                       
                        

                        lbl.CssClass = "fa fa-check fa-fw";
                    }
                    else
                    {

                        lbl.CssClass = "fa fa-times fa-fw";


                    }
                }

            }
        }

        protected void users_gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int ID = Int32.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Details")
            {
                

                Response.Redirect("UserDetails.aspx?userid="+ID);
            }else {
                User user = new User();
                int result = user.ActivateUser(ID);

                Response.Redirect("Users.aspx");
            }
        }
    }
}