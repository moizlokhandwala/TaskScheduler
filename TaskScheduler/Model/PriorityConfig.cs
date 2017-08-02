using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using TaskScheduler.Service;
using System.Data;

namespace TaskScheduler.Model
{
    public class PriorityConfig
    {
        public int ID { get; set; }
        public string Value { get; set; }

        DBService dbService = DBService.GetInstance();


        public List<PriorityConfig> GetPriorities()
        {
            List<PriorityConfig> priorities = new List<PriorityConfig>();

            DataTable dt = dbService.ExecuteDataReader("select * from PRIORITYCONFIG");

          //  while (dr.Read())
          foreach(DataRow dr in dt.Rows)
            {
                PriorityConfig priority = new PriorityConfig();

                //priority.ID = dr.GetInt32(0);
                //priority.Value = dr.GetString(1);
                //dr.
                priority.ID = Int32.Parse(dr[0].ToString());
                priority.Value = dr[1].ToString();
                priorities.Add(priority);
            }
           // dbService.CloseDB();
            return priorities;
        }

        public PriorityConfig GetPriority(int id) {
            PriorityConfig priority = new PriorityConfig();
            List<PriorityConfig> priorities = new List<PriorityConfig>();
            priorities = GetPriorities();
            foreach(PriorityConfig pc in priorities)
            {
                if (pc.ID == id)
                {
                    priority = pc;
                    break;
                }
            }

            return priority;
        }
    }
}