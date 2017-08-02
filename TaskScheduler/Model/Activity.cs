using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskScheduler.Service;
using System.Data.OleDb;
using System.Configuration;
using System.Data;

namespace TaskScheduler.Model
{
    public class Activity
    {
        public int ID { get; set; }
        public Task Task{ get; set; }
        public User AssignedBy { get; set; }
        public User Assignee { get; set; }
        public int Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Comments { get; set; }

        DBService dbService = DBService.GetInstance();

        public List<Activity> GetActivities()
        {
            List<Activity> activities = new List<Activity>();
            string query = "select * from Activity order by id desc";

            //OleDbDataReader reader = dbService.ExecuteDataReader(query);
            DataTable dts= dbService.ExecuteDataReader(query); 
           // while (reader.Read())
           foreach(DataRow reader in dts.Rows)
            {
                Task task = new Task();
                User user = new User();

                Activity activity = new Activity();
                activity.ID = Int32.Parse(reader[0].ToString());
                activity.Task = task.GetTask(Int32.Parse(reader[1].ToString()));
                activity.AssignedBy = user.GetUserDetails(Int32.Parse(reader[2].ToString()));
                activity.Assignee = user.GetUserDetails(Int32.Parse(reader[3].ToString()));
                activity.Status = Int32.Parse(reader[4].ToString());
                activity.Comments = reader[7].ToString();
                activities.Add(activity);
            }

            return activities;
        }

        public List<Activity> GetActivitiesByAssignee(int id)
        {
            List<Activity> activities = new List<Activity>();
            List<Activity> filterActivities = new List<Activity>();
            

            activities = GetActivities();
           foreach(Activity activity in activities)
            {
                Task task = new Task();
                User user = new User();

                if (activity.Assignee.ID == id)
                {

                    filterActivities.Add(activity);
                }
               
            }

            return filterActivities;
        }
        public List<ActivityView> GetActivityViewsByAssignee(int id)
        {
            List<ActivityView> aviews = new List<ActivityView>();
            List<Activity> activities = new List<Activity>();
            activities = GetActivitiesByAssignee(id);

            foreach(Activity ac in activities)
            {
                ActivityView av = new ActivityView();

                av.ActivityID = ac.ID;
                av.ActivityStatus = ac.Status;
                av.Author = ac.AssignedBy.Name;
                av.Assignee = ac.Assignee.Name;
                av.Priority = ac.Task.priority.Value;
                av.TaskID = ac.Task.TaskID;
                av.TaskTitle = ac.Task.Title;

                aviews.Add(av);
            }


            return aviews;
        }

        public List<Activity> GetActivityByTask(int id)
        {
            List<Activity> activities = new List<Activity>();
            List<Activity> filterActivities = new List<Activity>();


            activities = GetActivities();
            foreach (Activity activity in activities)
            {
              //  Task task = new Task();
               // User user = new User();

                if (activity.Task.TaskID == id)
                {

                    filterActivities.Add(activity);
                }

            }

            return filterActivities;
        }

        public int StartStopActivity(int ActivityID,int operation)
        {
            int updateCount = 0;
            string query = ""; 
            if (operation == 2)
            {
                query = "update ACTIVITY set starttime=getdate(),Status=2 where ID=" + ActivityID;
            }
            else
            {
                query = "update ACTIVITY set endtime=getdate(),Status=3 where ID=" + ActivityID;
            }
            
            updateCount = dbService.ExecuteUpdate(query);
            return updateCount;
        }

        public int AddUpdate()
        {
            int updateCount = 0;
            string query = ConfigurationManager.AppSettings["UpdateActvity"].ToString();
            //{Author},{ASSIGNEE},'{Comments}'

            query = query.Replace("{TaskID}", Task.TaskID + "");
            query = query.Replace("{ActivityID}", ID+"");
            query = query.Replace("{Author}", AssignedBy.ID+"");
            query = query.Replace("{ASSIGNEE}", Assignee.ID+"");
            query = query.Replace("{Comments}", Comments);
            query = query.Replace("{Status}", Task.Status.ID+"");
            query = query.Replace("{ActivityStatus}", Status + "");
            updateCount = dbService.ExecuteUpdate(query);
            return updateCount;

        }

    }
}