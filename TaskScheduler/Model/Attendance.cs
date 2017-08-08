using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TaskScheduler.Service;

namespace TaskScheduler.Model
{
    public class Attendance
    {
        DBService dbService = DBService.GetInstance();

        public int ID { get; set; }
        public int UserID { get; set; }
        public string AttendanceDate { get; set; }
        public string LoginTime { get; set; }
        public string LogoutTime { get; set; }

        public int AddAttendance(int Operation)
        {
            int returnValue = 0;
            string query = ConfigurationManager.AppSettings["AddAttendance"].ToString();
            //,{Operation}
            query = query.Replace("{UserID}", UserID + "");
            query = query.Replace("{Operation}", Operation+"");
            returnValue = dbService.ExecuteUpdate(query);



            return returnValue;
        }
    }
}