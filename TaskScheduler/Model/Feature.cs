using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskScheduler.Model
{
    public class Feature
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public string FeatureName { get; set; }
        public string FeatureUrl { get; set; }
        public int Active { get; set; }
    }
}