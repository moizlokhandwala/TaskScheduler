using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler.Model;

namespace TaskScheduler
{
    public partial class AddClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Client client = new Client();
            
            client.Name = "Moiz Lokh";
            client.Landline = "88288282";
            client.LocalAddress = "Local Address";
            client.RegAddress = "Registered Address";
            client.Email = "abc@test.com";
            client.AccEmail = "";
        }
    }
}