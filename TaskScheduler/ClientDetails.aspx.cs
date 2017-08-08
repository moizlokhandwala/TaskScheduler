using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler.Model;

namespace TaskScheduler
{
    public partial class ClientDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Client client = new Client();

            client.ID = 1;

            client = client.GetClientByID();

            string name = client.Name;
        }
    }
}