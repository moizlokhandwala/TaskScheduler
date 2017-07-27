using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler.Model;

namespace TaskScheduler
{
    public partial class TaskDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Activity activity = new Activity();
            List<Activity> activities = new List<Activity>();

            if (Request["TaskID"] != null)
            {
                int TaskID = Int32.Parse(Request["TaskID"].ToString());
                activities = activity.GetActivityByTask(TaskID);

                Task task = new Task();
                task = activities[0].Task;
                tasktitle_lbl.Text = task.Title;
                description_lbl.Text = task.Description;
                author_lbl.Text = task.Author.Name;
                creationdate_lbl.Text = task.CreationDate.ToString();
                priority_lbl.Text = task.priority.Value;
            }
            else
            {

            }
          

        }
    }
}