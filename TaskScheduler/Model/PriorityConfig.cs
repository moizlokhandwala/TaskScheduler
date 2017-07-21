using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using TaskScheduler.Service;

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

            OleDbDataReader dr = dbService.ExecuteDataReader("select * from PRIORITYCONFIG");

            while (dr.Read())
            {
                PriorityConfig priority = new PriorityConfig();

                priority.ID = dr.GetInt32(0);
                priority.Value = dr.GetString(1);

                priorities.Add(priority);
            }
            dbService.CloseDB();
            return priorities;
        }
    }
}