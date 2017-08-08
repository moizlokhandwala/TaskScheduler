using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using TaskScheduler.Service;

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

        DBService dbService = DBService.GetInstance();

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

            returnValue=dbService.ExecuteClientProc(procCommand);

            return returnValue;
        }

        public List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();
            string query = "select * from Client";
            DataTable dt = dbService.ExecuteDataReader(query);

            foreach(DataRow dr in dt.Rows)
            {
                Client client = new Client();

                client.ID = Int32.Parse(dr[0].ToString());
                client.Name = dr[1].ToString();
                client.Landline = dr[2].ToString();
                client.LocalAddress = dr[3].ToString();
                client.RegAddress = dr[4].ToString();
                client.Email = dr[5].ToString();
                client.StructureID = new Structure();
                client.StructureID.ID = Int32.Parse(dr[6].ToString());
                client.PAN = dr[7].ToString();
                client.TAN = dr[8].ToString();
                client.GST = dr[9].ToString();
                client.NatureID = new Nature();
                client.NatureID.ID = Int32.Parse(dr[10].ToString());
                client.BusinessType = dr[11].ToString();
                client.AccName = dr[12].ToString();              
                client.AccMobile = dr[13].ToString();
                client.AccWhatsapp = dr[14].ToString();
                client.AccEmail = dr[15].ToString();
                clients.Add(client);
            }

            return clients;
        }

        public Client GetClientByID()
        {
            Client client = new Client();
            List<Client> clients = new List<Client>();

            clients = GetClients();

            var client1 = from c in clients where c.ID == ID select c;
            client = client1.FirstOrDefault();

            return client;
        }
    }
}