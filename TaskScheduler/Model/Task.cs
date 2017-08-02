using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using TaskScheduler.Service;

namespace TaskScheduler.Model
{
    public class Task
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PriorityConfig priority { get; set; }
        public User Author { get; set; }
        public DateTime CreationDate { get; set; }
        public StatusConfig Status { get; set; }


        DBService dbService = DBService.GetInstance();
        string AddTaskQuery = ConfigurationManager.AppSettings["AddTask"].ToString();

        public List<Task> GetTasks()
        {
            List<Task> tasks = new List<Task>();

            // OleDbDataReader dr = dbService.ExecuteDataReader("select * from TASK");
            DataTable dts = dbService.ExecuteDataReader("select * from TASK");
            //while (dr.Read())
            foreach(DataRow dr in dts.Rows)
            {
                Task task = new Task();

                PriorityConfig pr = new PriorityConfig();
                StatusConfig sc = new StatusConfig();
                User u = new User();
                task.TaskID = Int32.Parse(dr[0].ToString());
                task.Title = dr[1].ToString();
                task.Description = dr[2].ToString();
                task.priority = pr.GetPriority(Int32.Parse(dr[3].ToString()));
                task.Author = u.GetUserDetails(Int32.Parse(dr[4].ToString()));
                task.CreationDate = DateTime.Parse(dr[5].ToString());
                task.Status = sc.GetStatus(Int32.Parse(dr[6].ToString()));

                tasks.Add(task);
            }
            // dbService.CloseDB();
            return tasks;
        }

        public Task GetTask(int id)
        {
            Task task = new Task();
            List<Task> tasks = new List<Task>();
            tasks = task.GetTasks();

            foreach(Task t in tasks)
            {
                if (t.TaskID == id)
                {
                    task = t;
                    break;
                }
            }

            return task;
        }


       public int AddTask(Activity activity)
        {
            int response = 0;
            //'{Comments}'

            AddTaskQuery = AddTaskQuery.Replace("{TITLE}", Title);
            AddTaskQuery = AddTaskQuery.Replace("{DESCRIPTION}", Description);
            AddTaskQuery = AddTaskQuery.Replace("{Priority}", priority.ID+"");
            AddTaskQuery = AddTaskQuery.Replace("{Author}", Author.ID+"");
            AddTaskQuery = AddTaskQuery.Replace("{Status}", Status.ID+"");
            AddTaskQuery = AddTaskQuery.Replace("{ASSIGNEE}", activity.Assignee.ID+"");
            AddTaskQuery = AddTaskQuery.Replace("{Comments}", activity.Comments);

            int result = dbService.ExecuteUpdate(AddTaskQuery);

            return response;
        }
    }
}