using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskScheduler.Model
{
    public class Activity
    {
        public int ID { get; set; }
        public Task Task{ get; set; }
        public User AssignedBy { get; set; }
        public User Assignee { get; set; }
        public StatusConfig Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Comments { get; set; }

    }
}