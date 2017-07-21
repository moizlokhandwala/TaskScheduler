using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler.Model;

namespace TaskScheduler
{
    public partial class AddTask : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                User user = new User();
                assignee_ddl.DataSource = user.GetUsers();

                assignee_ddl.DataTextField = "Name";
                assignee_ddl.DataValueField = "ID";

                assignee_ddl.DataBind();

                PriorityConfig priority = new PriorityConfig();


                priority_ddl.DataSource = priority.GetPriorities();

                priority_ddl.DataTextField = "Value";
                priority_ddl.DataValueField = "ID";

                priority_ddl.DataBind();

            }
        }

        protected void addtask_btn_Click(object sender, EventArgs e)
        {
            string title = title_txt.Text;
            int priority = Int32.Parse(priority_ddl.SelectedValue.ToString());
            string description = description_txt.Text;
            int assignee = Int32.Parse(assignee_ddl.SelectedValue.ToString());


            Task task = new Task();

            task.Title = title;
            task.priority = new PriorityConfig();
            task.priority.ID = priority;
            task.Description = description;
            task.Author = new User();
            task.Author.ID = Int32.Parse(Session["userid_ts"].ToString());
            task.Status = new StatusConfig();
            task.Status.ID = 1;

            Activity activity = new Activity();
            activity.Assignee = new User();
            activity.Assignee.ID = assignee;
            activity.Comments = "New";

            task.AddTask(activity);

        }
    }
}