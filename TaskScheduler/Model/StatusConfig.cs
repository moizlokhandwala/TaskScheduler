using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using TaskScheduler.Service;

namespace TaskScheduler.Model
{
    public class StatusConfig
    {
        public int ID { get; set; }
        public string Value { get; set; }

        DBService dbService = DBService.GetInstance();

        public List<StatusConfig> GetStatuses()
        {
            List<StatusConfig> statuses = new List<StatusConfig>();

            OleDbDataReader dr = dbService.ExecuteDataReader("select * from STATUSCONFIG");

            while (dr.Read())
            {
                StatusConfig status = new StatusConfig();

                status.ID = dr.GetInt32(0);
                status.Value = dr.GetString(1);

                statuses.Add(status);
            }
            dbService.CloseDB();
            return statuses;
        }
    }
}