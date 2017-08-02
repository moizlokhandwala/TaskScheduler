using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using TaskScheduler.Service;

namespace TaskScheduler.Model
{
    public class Structure
    {
        public int ID { get; set; }
        public string Value { get; set; }

        DBService dbService = DBService.GetInstance();

        public List<Structure> GetStructures()
        {
            List<Structure> structures = new List<Structure>();

            string query = "select * from ORGANIZATIONSTRUCTURE";

            DataTable dt = dbService.ExecuteDataReader(query);

            foreach(DataRow dr in dt.Rows)
            {
                Structure structure = new Structure();
                structure.ID = Int32.Parse(dr[0].ToString());
                structure.Value = dr[1].ToString();

                structures.Add(structure);
            }

            return structures;
        }

        public int AddStructure()
        {
            int ID = 0;
            OleDbCommand procCommand = new OleDbCommand("AddStructure");
            procCommand.CommandType = CommandType.StoredProcedure;
            procCommand.Parameters.AddWithValue("@pValue", Value);
            procCommand.Parameters.AddWithValue("@pScopeID", 0).Direction = ParameterDirection.Output;

           int k = dbService.ExecuteClientProc(procCommand);

            return ID;
        }
    }
}