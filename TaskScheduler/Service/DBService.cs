using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using TaskScheduler.Model;

namespace TaskScheduler.Service
{
    public class DBService
    {
        private static OleDbConnection connection = null;
        private static object syncLock = new object();
        private static DBService _instance;
        private string ConnectionString = ConfigurationManager.AppSettings["SQLConnectionString"].ToString();

        protected DBService()
        {
            if (connection == null)
            {
                connection = new OleDbConnection(ConnectionString);
            }
            
        }

        public static DBService GetInstance()
        {
            if (_instance == null)

            {

                lock (syncLock)

                {

                    if (_instance == null)

                    {

                        _instance = new DBService();

                    }

                }

            }



            return _instance;
        }

        public DataTable ExecuteDataReader(string _query)
        {
            OleDbDataReader dr = null;
            DataTable dt = new DataTable("dt");
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                OleDbCommand selectCommand = new OleDbCommand(_query, connection);

                dr = selectCommand.ExecuteReader();

                
                dt.Load(dr);

            }
            catch(Exception ex)
            {
              
                dr = null;
            }
            finally
            {
                
                dr.Close();
            }

            return dt;

        }

        public void CloseDB()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public int ExecuteUpdate(string _query)
        {
            int resultCount = 0;

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                OleDbCommand upsertCommand = new OleDbCommand(_query, connection);
                resultCount = upsertCommand.ExecuteNonQuery();

            }catch(Exception ex)
            {
                resultCount = -1;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            return resultCount;
        }

        public int ExecuteClientProc(OleDbCommand procCommand)
        {
            int returnValue = 0;

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                procCommand.Connection = connection;

                int returnvalue = procCommand.ExecuteNonQuery();

                int ScopeID = Int32.Parse(procCommand.Parameters["@pScopeID"].Value.ToString());

            }
            catch(Exception ex)
            {
                returnValue = -1;
            }
                return returnValue;
        }

    }
}