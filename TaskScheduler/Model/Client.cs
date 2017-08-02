using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace TaskScheduler.Model
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Landline { get; set; }
        public string LocalAddress { get; set; }
        public string RegAddress { get; set; }
        public string Email { get; set; }
        public Structure StructureID { get; set; }
        public string TAN { get; set; }
        public string PAN { get; set; }
        public string GST { get; set; }
        public Nature NatureID { get; set; }
        public string BusinessType { get; set; }
        public string AccName { get; set; }
        public string AccMobile { get; set; }
        public string AccWhatsapp { get; set; }
        public string AccEmail { get; set; }

        public int AddClient()
        {
            int returnValue = 0;

            OleDbCommand procCommand = new OleDbCommand("AddCLientInfo");
            procCommand.CommandType = CommandType.StoredProcedure;

            procCommand.Parameters.AddWithValue("@pName", Name);
            procCommand.Parameters.AddWithValue("@pLandline", Landline);
            procCommand.Parameters.AddWithValue("@pLocalAdd", LocalAddress);
            procCommand.Parameters.AddWithValue("@pRegAdd", RegAddress);
            procCommand.Parameters.AddWithValue("@pEmail", Email);
            procCommand.Parameters.AddWithValue("@pStructure", StructureID.ID);
            procCommand.Parameters.AddWithValue("@pPAN", PAN);
            procCommand.Parameters.AddWithValue("@pTAN", TAN);
            procCommand.Parameters.AddWithValue("@pGST", GST);
            procCommand.Parameters.AddWithValue("@pNature", NatureID.ID);
            procCommand.Parameters.AddWithValue("@pBusinessType", BusinessType);
            procCommand.Parameters.AddWithValue("@pAccName", AccName);
            procCommand.Parameters.AddWithValue("@pAccMobile", AccMobile);
            procCommand.Parameters.AddWithValue("@pAccwhtsnum", AccWhatsapp);
            procCommand.Parameters.AddWithValue("@pAccEmail", AccEmail);
            procCommand.Parameters.AddWithValue("@pScopeID", 0).Direction = ParameterDirection.Output;

            

            return returnValue;
        }
    }
}