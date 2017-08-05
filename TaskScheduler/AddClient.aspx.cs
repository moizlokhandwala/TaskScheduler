using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler.Model;
using TaskScheduler.Service;

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

            FillStructureGrid();
            FillNatureGrid();

        }

        public void FillNatureGrid()
        {
            Nature nature = new Nature();
            nature_ddl.DataSource = nature.GetNatures();
            nature_ddl.DataValueField = "ID";
            nature_ddl.DataTextField = "Value";
            nature_ddl.DataBind();
        }

        public void FillStructureGrid()
        {
            Structure structure = new Structure();


            structure_ddl.DataSource = structure.GetStructures();

            structure_ddl.DataValueField = "ID";
            structure_ddl.DataTextField = "Value";
            structure_ddl.DataBind();
        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
            string clientname = name_txt.Text;
            string landline = landline_txt.Text;
            string localaddress = localaddress_txt.Text;
            string registeredAddress = registeredAddress_txt.Text;
            string email = emailid_txt.Text;
            string structure = structure_ddl.SelectedValue.ToString();
            string pan = pan_txt.Text;
            string tan = tan_txt.Text;
            string gst = gst_txt.Text;
            string nature = nature_ddl.SelectedValue.ToString();
            string businessType = business_txt.Text;
            string accName = accName_txt.Text;
            string accMobile = mobile_txt.Text;
            string accWhatsapp = whatsapp_txt.Text;
            string accEmail = accemail_txt.Text;

            Client client = new Client();

            

            int returnValue = client.AddClient();


        }
    }
}