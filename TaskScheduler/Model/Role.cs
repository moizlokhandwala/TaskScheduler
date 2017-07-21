using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using TaskScheduler.Service;

namespace TaskScheduler.Model
{
    public class Role
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public int Active { get; set; }

        private string selectRoles = ConfigurationManager.AppSettings["selectRoles"].ToString();
        DBService dbService = DBService.GetInstance();

        public List<Role> GetAllRoles()
        {
            List<Role> roles = new List<Role>();

            OleDbDataReader reader = dbService.ExecuteDataReader(selectRoles);
            if (reader != null) { 
            while(reader.Read())
            {
                Role role = new Role();

                role.ID = reader.GetInt32(0);
                role.RoleName = reader.GetString(1);
                role.Active = reader.GetInt32(2);
                roles.Add(role);
            }
            }
           // dbService.CloseDB();
            return roles;
        }

        public List<Role> GetActiveRoles()
        {
            List<Role> activeRoles = new List<Role>();

            List<Role> Roles = new List<Role>();

            Roles = GetAllRoles();

            foreach(Role role in Roles)
            {
                if (role.Active == 1)
                {
                    activeRoles.Add(role);
                }
            }

            return activeRoles;
        }
    }
}