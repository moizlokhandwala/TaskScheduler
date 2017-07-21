using System;
using System.Collections.Generic;
using System.Configuration;
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

            OleDbDataReader dr = dbService.ExecuteDataReader("select * from STATUSCONFIG");

            while (dr.Read())
            {
                Task task = new Task();

                task.TaskID = dr.GetInt32(0);
                task.Title = dr.GetString(1);


                tasks.Add(task);
            }
            dbService.CloseDB();
            return tasks;
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
            AddTaskQuery = AddTaskQuery.Replace("{ASSIGNEE}", activity.ID+"");
            AddTaskQuery = AddTaskQuery.Replace("{Comments}", activity.Comments);

            int result = dbService.ExecuteUpdate(AddTaskQuery);

            return response;
        }
    }
}