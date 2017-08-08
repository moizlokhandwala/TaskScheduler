using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

        public int isError { get; set; }
        public string ErrorMessage { get; set; }

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

        public User isUserValid(string email,string password)
        {
            List<User> users = new List<User>();
            users = GetUsers();
            User LoggedInUser=new User();
            foreach(User user in users)
            {
                if (user.EmailID.Equals(email, StringComparison.CurrentCultureIgnoreCase))
                {
                    if(user.Password== password)
                    {
                        if (user.Active != 0) { 
                        LoggedInUser=user;
                        break;
                        }
                        else
                        {
                            LoggedInUser.isError = 1;
                            LoggedInUser.ErrorMessage = "User not Active, Kindly contact the admin!!!";
                            break;
                        }
                    }
                    else
                    {
                        LoggedInUser.isError=1;
                        LoggedInUser.ErrorMessage = "Incorrect Password!!!";
                        break;
                    }
                }
                else
                {
                    LoggedInUser.isError = 1;
                    LoggedInUser.ErrorMessage = "User not found!!!";
                }
            }

            return LoggedInUser;
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

            //OleDbDataReader reader = dbService.ExecuteDataReader(selectUsers);
            DataTable dts= dbService.ExecuteDataReader(selectUsers); 
            if (dts != null)
            {
              //  while (reader.Read())
              foreach(DataRow reader in dts.Rows)
                {
                    User user = new User();
                    Role role = new Role();
                    user.role = role;
                    user.ID = Int32.Parse(reader[0].ToString());
                    user.Name = reader[1].ToString();
                    user.FathersName = reader[2].ToString();
                    user.role.RoleName = reader[3].ToString();
                    user.AddressLocal = reader[4].ToString();
                    user.AddressPermanent = reader[5].ToString();
                    user.CelNumber = reader[6].ToString();
                    user.WhatsAppNumber = reader[7].ToString();
                    user.EmailID = reader[8].ToString();
                    user.CRONumber = reader[9].ToString();
                    if (reader["ArticleshipStartDate"] != DBNull.Value)
                    {
                        user.ArticleShipStartDate = DateTime.Parse(reader["ArticleshipStartDate"].ToString());
                    }
                    if (reader["MembershipDate"] != DBNull.Value)
                    {
                        user.MembershipDate = DateTime.Parse(reader[11].ToString());
                    }
                    user.MembershipNumber = reader[12].ToString();
                    user.Active = Int32.Parse(reader[13].ToString());
                    user.role.ID = Int32.Parse(reader[14].ToString());
                    user.role.Active = Int32.Parse(reader[15].ToString());
                    user.Password = reader[16].ToString();
                    users.Add(user);

                }

                // dbService.CloseDB();
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

        public int ActivateUser(int userID)
        {
            string query = "update [USER] set Active = 1 where ID=" + userID;

            int result = dbService.ExecuteUpdate(query);

            return result;

        }

        public int UpdateProfile()
        {
            
            string query = ConfigurationManager.AppSettings["UpdateProfile"].ToString();

            query = query.Replace("{Name}", Name);
            query = query.Replace("{FathersName}", FathersName);
            query = query.Replace("{AddressLocal}", AddressLocal);
            query = query.Replace("{AddressPermanent}", AddressPermanent);
            query = query.Replace("{CellNumber}", CelNumber);
            query = query.Replace("{WhatsappNumber}", WhatsAppNumber);
            query = query.Replace("{EmailID}", EmailID);
            query = query.Replace("{ID}", ""+ID);

            int result = dbService.ExecuteUpdate(query);

            return result;
        }
    }
}