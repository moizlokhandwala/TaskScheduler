using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskScheduler.ViewModel
{
    public class UserView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string RoleName { get; set; }
        public string Active { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
    }
}