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
        public static Activity myActivity = new Activity();
        Activity activity = new Activity();
        List<Activity> activities;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                activities = new List<Activity>();
                if (Request["TaskID"] != null)
                {
                    string userid = Session["userid_ts"].ToString();
                    int TaskID = Int32.Parse(Request["TaskID"].ToString());
                    activities = activity.GetActivityByTask(TaskID);
                    if (activities.Count > 0) {
                        Task task = new Task();
                        myActivity = activities[0];
                        task = activities[0].Task;
                        tasktitle_lbl.Text = task.Title;
                        description_lbl.Text = task.Description;
                        author_lbl.Text = task.Author.Name;
                        creationdate_lbl.Text = task.CreationDate.ToString();
                        priority_lbl.Text = task.priority.Value;
                        status_lbl.Text = task.Status.Value;

                        activityId_lbl.Text = activities[0].ID + "";

                        if (activities[0].Status == 1 && activities[0].Assignee.ID== Int32.Parse(userid))
                        {
                            start_btn.Visible = true;
                        }
                        else if (activities[0].Status == 2 && activities[0].Assignee.ID == Int32.Parse(userid))
                        {
                            stop_btn.Visible = true;
                            edit_btn.Visible = true;

                        }

                        string li = "";
                        string liTag = "";
                        string titleBadge = "";
                        foreach (Activity act in activities)
                        {
                            if (act.AssignedBy.ID == Int32.Parse(userid))
                            {
                                liTag = "<li>";
                            }
                            else
                            {
                                liTag = "<li class='timeline-inverted'>";
                            }

                            if (act.Status == 1)
                            {
                                titleBadge = "fa-exclamation";
                            }
                            else
                            {
                                titleBadge = "fa-check";
                            }
                            li += liTag + @"
                                    <div class='timeline-badge'><i class='fa " + titleBadge
                                            + @"'></i>
                                    </div>
                                    <div class='timeline-panel'>
                                        <div class='timeline-heading'>
                                            <h4 class='timeline-title'>" + act.AssignedBy.Name + @"</h4>
                                            <p><small class='text-muted'><i class='fa fa-clock-o'></i> assigned to " + act.Assignee.Name + " on " + "" + @"</small>
                                            </p>
                                        </div>
                                        <div class='timeline-body'>
                                            <p>" + act.Comments + @"</p>
                                            
                                          </div>
                                    </div>
                                </li>";
                        }



                        activities_ltl.Text = li;
                    }
                    
                }
                else
                {

                }
            }

        }

        protected void edit_btn_Click(object sender, EventArgs e)
        {
            //if (activityId_lbl.Text != "")
            //{
            //   // Response.Redirect("EditActivity.aspx?activityid="+activityId_lbl.Text);
            //}



            comments_lbl.Visible = true;
            comment_txt.Visible = true;
            activitystatus_lbl.Visible = true;
            status_ddl.Visible = true;
            update_btn.Visible = true;

            StatusConfig sc = new StatusConfig();
            status_ddl.DataSource = sc.GetStatuses();
           
            status_ddl.DataTextField = "Value";
            status_ddl.DataValueField = "ID";

            string roleId = Session["usertype_ts"].ToString();
            if (roleId == "1")
            {
                assignee_lbl.Visible = true;
                User user = new User();
                assignee_ddl.DataSource = user.GetUsers();
                assignee_ddl.DataValueField = "ID";
                assignee_ddl.DataTextField = "Name";
                assignee_ddl.DataBind();
                assignee_ddl.Visible = true;
            }
            else
            {
                status_ddl.SelectedValue = 5 + "";
                status_ddl.Enabled = false;
            }
            

            
            status_ddl.DataBind();
        }

        protected void start_btn_Click(object sender, EventArgs e)
        {
            if (activityId_lbl.Text != "")
            {
                
                int activityId = Int32.Parse(activityId_lbl.Text);
                Activity activity = new Activity();
                int returnVal = activity.StartStopActivity(activityId,2);

                if (returnVal == 1)
                {
                    Response.Redirect("TaskList.aspx");
                }
            }
        }

        protected void stop_btn_Click(object sender, EventArgs e)
        {
            if (activityId_lbl.Text != "")
            {

                int activityId = Int32.Parse(activityId_lbl.Text);
                Activity activity = new Activity();
                string comments = "Task Completed";
                int Status = 3;
                int assignedBy = Int32.Parse(Session["userid_ts"].ToString());
                int assignee = myActivity.AssignedBy.ID;

                myActivity.Comments = comments;
                myActivity.AssignedBy.ID = assignedBy;
                myActivity.Assignee.ID = assignee;
                myActivity.Task.Status.ID = Status;
                myActivity.Status = 3;

                //  int returnVal = activity.StartStopActivity(activityId, 3);
                int returnVal = myActivity.AddUpdate();
                if (returnVal > 0)
                {
                    Response.Redirect("TaskList.aspx");
                }
            }
        }

        protected void update_btn_Click(object sender, EventArgs e)
        {
            if (activityId_lbl.Text != "")
            {
                string comments = comment_txt.Text;
                int Status = Int32.Parse(status_ddl.SelectedValue);

                myActivity.Comments = comments;
                
                string roleId = Session["usertype_ts"].ToString();
                int assignedBy = Int32.Parse(Session["userid_ts"].ToString());
                int assignee = 0;
                if (roleId == "1")
                {
                    assignee = Int32.Parse(assignee_ddl.SelectedValue);
                }
                else
                {
                    assignee=myActivity.AssignedBy.ID;
                }
                myActivity.AssignedBy.ID = assignedBy;
                myActivity.Assignee.ID = assignee;
                myActivity.Task.Status.ID = Status;
                myActivity.Status = 3;

                int returnVal=myActivity.AddUpdate();

                if (returnVal > 0)
                {
                    Response.Redirect("TaskList.aspx");
                }
            }

            }
    }
}