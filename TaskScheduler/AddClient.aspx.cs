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
            if (!IsPostBack) { 
            FillStructureGrid();
            FillNatureGrid();
            }
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

            client.Name = clientname;
            client.Landline = landline;
            client.LocalAddress = localaddress;
            client.RegAddress = registeredAddress;
            client.Email = email;
            client.StructureID = new Structure();
            client.StructureID.ID = Int32.Parse(structure);
            client.PAN = pan;
            client.TAN = tan;
            client.GST = gst;
            client.NatureID = new Nature();
            client.NatureID.ID = Int32.Parse(nature);
            client.BusinessType = businessType;
            client.AccName = accName;
            client.AccEmail = accEmail;
            client.AccMobile = accMobile;
            client.AccWhatsapp = accWhatsapp;

            int returnValue = client.AddClient();

            Response.Redirect("AddPromoter.aspx?clientId="+returnValue);

        }
    }
}