using System;
using System.Collections.Generic;
using System.Data;
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

            // OleDbDataReader dr = dbService.ExecuteDataReader("select * from STATUSCONFIG");
            DataTable dts = dbService.ExecuteDataReader("select * from STATUSCONFIG");

            //while (dr.Read())
            foreach(DataRow dr in dts.Rows)
            {
                StatusConfig status = new StatusConfig();

                status.ID = Int32.Parse(dr[0].ToString());
                status.Value = dr[1].ToString();

                statuses.Add(status);
            }
            dbService.CloseDB();
            return statuses;
        }

        public StatusConfig GetStatus(int id) {
            StatusConfig sc = new StatusConfig();
            List<StatusConfig> statuses = new List<StatusConfig>();
            statuses = GetStatuses();
            foreach(StatusConfig status in statuses)
            {
                if (status.ID == id)
                {
                    sc = status;
                    break;
                }
            }
            return sc;
        }
    }
}