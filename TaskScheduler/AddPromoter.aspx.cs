using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler.Model;

namespace TaskScheduler
{
    public partial class AddPromoter : System.Web.UI.Page
    {
        Client client = new Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
               
                client_ddl.DataSource = client.GetClients();
                client_ddl.DataTextField = "Name";
                client_ddl.DataValueField = "ID";

                client_ddl.DataBind();
                if (Request["clientId"] != null)
            {
                    string clientID = Request["clientId"].ToString();

                    client_ddl.SelectedValue = clientID;
                    client_ddl.Enabled = false;
            }
            }
        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
            string promoterName = name_txt.Text;
            string promoterDesignation = designation_txt.Text;
            string promoterEmail = email_txt.Text;
            string promoterMobile = mobile_txt.Text;
            string clientId = client_ddl.SelectedValue;

            Promoter promoter = new Promoter();
            promoter.client = new Client();
            promoter.client.ID = Int32.Parse(clientId);
            promoter.Name = promoterName;
            promoter.Designation = promoterDesignation;
            promoter.Email = promoterEmail;
            promoter.Mobile = promoterMobile;

           int returnValue = promoter.AddPromter();

            name_txt.Text="";
            designation_txt.Text="";
            email_txt.Text="";
            mobile_txt.Text="";
            
        }
    }
}