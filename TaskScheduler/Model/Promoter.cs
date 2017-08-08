using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskScheduler.Service;

namespace TaskScheduler.Model
{
    public class Promoter
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Client client { get; set; }

        DBService dbService = DBService.GetInstance();

        public int AddPromter()
        {
            int returnValue = 0;
            string query = @"insert into PROMOTER 
                                values('{NAME}','{DESIGNATION}',
                                '{EMAIL}','{MOBILE}',{CLIENTID})";

            query = query.Replace("{NAME}", Name);
            query = query.Replace("{DESIGNATION}", Designation);
            query = query.Replace("{EMAIL}", Email);
            query = query.Replace("{MOBILE}", Mobile);
            query = query.Replace("{CLIENTID}", client.ID+"");

            returnValue=dbService.ExecuteUpdate(query);

            return returnValue;
        }
    }
}