using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using TaskScheduler.Service;
using TaskScheduler.ViewModel;

namespace TaskScheduler.Model
{
    public class User
    {
        string insertQuery = ConfigurationManager.AppSettings["registerUser"].ToString();
        string selectUsers = ConfigurationManager.AppSettings["selectUser"].ToString();
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

        public List<UserView> GetUsersView()
        {
            List<UserView> usersView = new List<UserView>();
            List<User> users = new List<User>();
            users = GetUsers();
            foreach(User user in users)
            {
                UserView userview = new UserView();

                userview.ID = user.ID;
                userview.Name = user.Name;
                userview.RoleName = user.role.RoleName;
                userview.EmailID = user.EmailID;
                userview.Active = user.Active == 1 ? "Active" : "Inactive";
                userview.MobileNumber = user.CelNumber;
                usersView.Add(userview);
            }
            return usersView;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            
            OleDbDataReader reader = dbService.ExecuteDataReader(selectUsers);
            if (reader != null)
            {
                while (reader.Read())
                {
                    User user = new User();
                    Role role = new Role();
                    user.role = role;
                    user.ID = reader.GetInt32(0);
                    user.Name = reader.GetString(1);
                    user.FathersName = reader.GetString(2);
                    user.role.RoleName = reader.GetString(3);
                    user.AddressLocal = reader.GetString(4);
                    user.AddressPermanent = reader.GetString(5);
                    user.CelNumber = reader.GetString(6);
                    user.WhatsAppNumber = reader.GetString(7);
                    user.EmailID = reader.GetString(8);
                    user.CRONumber = reader.GetString(9);
                    if ( reader["ArticleshipStartDate"] != DBNull.Value) {
                        user.ArticleShipStartDate = reader.GetDateTime(10);
                    }
                    if (reader["MembershipDate"] != DBNull.Value)
                    {
                        user.MembershipDate = reader.GetDateTime(11);
                    }
                    user.MembershipNumber = reader.GetString(12);
                    user.Active = reader.GetInt32(13);
                    user.role.ID = reader.GetInt32(14);
                    user.role.Active = reader.GetInt32(15);
                    users.Add(user);

                }

                dbService.CloseDB();
            }

                    return users;
        }

        public User GetUserDetails(int userid)
        {
            User user = new User();
            List<User> users = new List<User>();

            users = GetUsers();

            foreach(User u in users)
            {
                if (u.ID == userid)
                {
                    user = u;
                    break;
                }
            }


            return user;
        }
    }
}