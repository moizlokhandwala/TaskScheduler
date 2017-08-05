using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using TaskScheduler.Service;

namespace TaskScheduler.Model
{
    public class Nature
    {
        public int ID { get; set; }
        public string Value { get; set; }

        DBService dbService = DBService.GetInstance();

        public List<Nature> GetNatures()
        {
            List<Nature> natures = new List<Nature>();

            string query = "select * from ORGANIZATIONNature";

            DataTable dt = dbService.ExecuteDataReader(query);

            foreach (DataRow dr in dt.Rows)
            {
                Nature nature = new Nature();
                nature.ID = Int32.Parse(dr[0].ToString());
                nature.Value = dr[1].ToString();

                natures.Add(nature);
            }

            return natures;
        }

        public int AddNature()
        {
            int ID = 0;
            OleDbCommand procCommand = new OleDbCommand("AddNature");
            procCommand.CommandType = CommandType.StoredProcedure;
            procCommand.Parameters.AddWithValue("@pValue", Value);
            procCommand.Parameters.AddWithValue("@pScopeID", 0).Direction = ParameterDirection.Output;

            int k = dbService.ExecuteClientProc(procCommand);

            return ID;
        }

    }
}