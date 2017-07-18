using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TaskScheduler.Service;

namespace TaskScheduler.Model
{
    public class User
    {
        string insertQuery = ConfigurationManager.AppSettings["registerUser"].ToString();
        DBService dbService = DBService.GetInstance();

        public int ID { get; set; }
        public string Name { get; set; }
        public string FathersName { get; set; }
        public string AddressLocal { get; set; }
        public string AddressPermanent { get; set; }
        public string CelNumber { get; set; }
        public string WhatsAppNumber { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public string CRONumber { get; set; }
        public DateTime ArticleShipStartDate { get; set; }
        public DateTime MembershipDate { get; set; }
        public string MembershipNumber { get; set; }
        public int Active { get; set; }

        public Role role { get; set; }

        public string RegisterUser()
        {
            string response = "";
            //'','','',''
            insertQuery = insertQuery.Replace("{Name}",Name);
            insertQuery = insertQuery.Replace("{FathersName}",FathersName);
            insertQuery = insertQuery.Replace("{AddressLocal}", AddressLocal);
            insertQuery = insertQuery.Replace("{AddressPermanent}",AddressPermanent);
            insertQuery = insertQuery.Replace("{CellNumber}", CelNumber);
            insertQuery = insertQuery.Replace("{WhatsappNumber}", WhatsAppNumber);
            insertQuery = insertQuery.Replace("{EmailID}", EmailID);
            insertQuery = insertQuery.Replace("{Password}", Password);
            insertQuery = insertQuery.Replace("{RoleID}",RoleID+"");
           
            if (RoleID == 2)
            {
                insertQuery = insertQuery.Replace("{MembershipDate}", MembershipDate.ToString());
                insertQuery = insertQuery.Replace("{MembershipNumber}", MembershipNumber);
                insertQuery = insertQuery.Replace("{CRONumber}", "");
                insertQuery = insertQuery.Replace("'{ArticleshipStartDate}'", "null");

            }
            else if (RoleID == 4)
            {
                insertQuery = insertQuery.Replace("{CRONumber}", CRONumber);
                insertQuery = insertQuery.Replace("{ArticleshipStartDate}", ArticleShipStartDate.ToString());

                insertQuery = insertQuery.Replace("'{MembershipDate}'", "null");
                insertQuery = insertQuery.Replace("{MembershipNumber}", "");
            }
            else
            {
                insertQuery = insertQuery.Replace("'{MembershipDate}'", "null");
                insertQuery = insertQuery.Replace("{MembershipNumber}", "");

                insertQuery = insertQuery.Replace("{CRONumber}", "");
                insertQuery = insertQuery.Replace("'{ArticleshipStartDate}'", "null");

            }

            int status = dbService.ExecuteUpdate(insertQuery);


            return response;
        }
    }
}