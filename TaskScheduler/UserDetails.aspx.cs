using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler.Model;

namespace TaskScheduler
{
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["userid"] != null) { 
            int userID = Int32.Parse(Request["userid"].ToString());
                User user = new User();
                   user = user.GetUserDetails(userID);
                //user.Name = "Moiz Lokhandwala";
                //user.FathersName = "Mansoor Ali Lokhandwala";
                //user.AddressLocal = "10, Manik bagh road, Holkar appartment B-Block Flat-No.-501, Indore";
                //user.AddressPermanent = "10, Manik bagh road, Holkar appartment B-Block Flat-No.-501, Indore";
                //user.CelNumber = "8827697095";
                //user.WhatsAppNumber = "8827697095";
                //user.EmailID = "moizlokhandwala9@gmail.com";

                //fathername_lbl.Text = user.FathersName;
                //email_lbl.Text = user.EmailID;

                //user.role = new Role();
                //user.role.RoleName = "Admin";

                username_lbl.Text = user.Name;
                permanentaddress_lbl.Text = user.AddressPermanent;
                localaddress_lbl.Text = user.AddressLocal;
                whatsapp_lbl.Text = user.WhatsAppNumber;
                mobile_lbl.Text = user.CelNumber;
                fathername_lbl.Text = user.FathersName;
                email_lbl.Text = user.EmailID;
            }
            else
            {
                Response.Redirect("UserDetails.aspx?userid=" + 1);

                Response.Redirect("Users.aspx");
            }

        }

        protected void updateUser_btn_Click(object sender, EventArgs e)
        {

        }
    }
}