using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Data.OleDb;
using System.Configuration;
using System.Data;

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

        public OleDbDataReader ExecuteDataReader(string _query)
        {
            OleDbDataReader dr = null;
           
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                OleDbCommand selectCommand = new OleDbCommand(_query, connection);

                dr = selectCommand.ExecuteReader();

                
            }catch(Exception ex)
            {
              
                dr = null;
            }
            finally
            {
              
            }

            return dr;

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

    }
}