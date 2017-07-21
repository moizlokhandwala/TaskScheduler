using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskScheduler.Model
{
    public class ActivityView
    {
        public int ActivityID { get; set; }
        public int TaskID { get; set; }
        public string TaskTitle { get; set; }
        public string Author { get; set; }
        public string Assignee { get; set; }
        public string Priority { get; set; }
        public int ActivityStatus { get; set; }
    }
}