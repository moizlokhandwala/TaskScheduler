using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler.Model;

namespace TaskScheduler
{
    public partial class TaskList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Session["username_ts"] != null)
                {
                    ActivityView aview = new ActivityView();
                    Activity activity = new Activity();

                    int userid = Int32.Parse(Session["userid_ts"].ToString());

                    tasks_gv.DataSource = activity.GetActivityViewsByAssignee(userid);
                    tasks_gv.DataBind();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void tasks_gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            

            if(e.CommandName== "update")
            {
                int ActivityID = Int32.Parse(e.CommandArgument.ToString());
                Response.Redirect("TaskDetails.aspx?activityid="+ActivityID);
            }
        }

        protected void tasks_gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void tasks_gv_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTask.aspx");
        }

        protected void tasks_gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int userType = Int32.Parse(Session["usertype_ts"].ToString());
            if(userType==1 || userType == 2)
            {

            }
            else
            {
                e.Row.Cells[0].Visible = false;
            }
            
        }
    }
}