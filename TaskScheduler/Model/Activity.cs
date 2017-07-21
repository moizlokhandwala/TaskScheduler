using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskScheduler.Service;
using System.Data.OleDb;
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
            string query = "select * from Activity";

             OleDbDataReader reader= dbService.ExecuteDataReader(query);
            while (reader.Read())
            {
                Task task = new Task();
                User user = new User();

                Activity activity = new Activity();
                activity.ID = reader.GetInt32(0);
                activity.Task = task.GetTask(reader.GetInt32(1));
                activity.AssignedBy = user.GetUserDetails(reader.GetInt32(2));
                activity.Assignee=user.GetUserDetails(reader.GetInt32(3));
                activity.Status = reader.GetInt32(4);
                activity.Comments = reader.GetString(7);
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
    }
}