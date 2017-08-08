using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler.Model;

namespace TaskScheduler
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                try { 
                int sessionUserID = Int32.Parse(Session["userid_ts"].ToString());
                    User user = new User();
                    user = user.GetUserDetails(sessionUserID);

                    fullname_txt.Text = user.Name;
                    fathername_txt.Text = user.FathersName;
                    localaddress_txt.Text = user.AddressLocal;
                    permanetAddress_txt.Text = user.AddressPermanent;
                    mobilenumber_txt.Text = user.CelNumber;
                    whatsappnumber_txt.Text = user.WhatsAppNumber;
                    emailid_txt.Text = user.EmailID;

                }
                catch(Exception ex)
                {
                    Response.Redirect("Home.aspx");
                }
                }
            
        }

        protected void update_btn_Click(object sender, EventArgs e)
        {
            User user = new User();
            int sessionUserID = Int32.Parse(Session["userid_ts"].ToString());

            user.ID = sessionUserID;
            user.Name=fullname_txt.Text;
            user.FathersName= fathername_txt.Text;
            user.AddressLocal= localaddress_txt.Text;
            user.AddressPermanent = permanetAddress_txt.Text;
            user.CelNumber= mobilenumber_txt.Text;
            user.WhatsAppNumber= whatsappnumber_txt.Text;
            user.EmailID= emailid_txt.Text;

            int returnValue=user.UpdateProfile();
        }
    }
}