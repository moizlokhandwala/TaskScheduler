using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler.Model;

namespace TaskScheduler
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                CalendarExtender2.SelectedDate = new DateTime();
                Role role = new Role();

                userType_ddl.DataSource = role.GetActiveRoles();
                userType_ddl.DataTextField = "RoleName";
                userType_ddl.DataValueField = "ID";
                userType_ddl.DataBind();


                //membershipNumber_lbl.Visible = false;
                //membershipNumber_txt.Visible = false;
                //cronum_lbl.Visible = false;
                //cronum_txt.Visible = false;

                //membershipDate_lbl.Visible = false;
                //membershipDate_txt.Visible = false;
                //articleDate_lbl.Visible = false;
                //articleDate_txt.Visible = false;

            }
        }

        protected void userType_ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(userType_ddl.SelectedValue == "1" || userType_ddl.SelectedValue=="3"){
                membershipNumber_lbl.Visible = false;
                membershipNumber_txt.Visible = false;
                cronum_lbl.Visible = false;
                cronum_txt.Visible = false;
               
                membershipDate_lbl.Visible = false;
                membershipDate_txt.Visible = false;
                articleDate_lbl.Visible = false;
                articleDate_txt.Visible = false;
                
            }else if (userType_ddl.SelectedValue == "2")
            {
                membershipNumber_lbl.Visible = true;
                membershipNumber_txt.Visible = true;
                membershipDate_lbl.Visible = true;
                membershipDate_txt.Visible = true;

                cronum_lbl.Visible = false;
                cronum_txt.Visible = false;
                articleDate_lbl.Visible = false;
                articleDate_txt.Visible = false;
            }
            else
            {
                membershipNumber_lbl.Visible = false;
                membershipNumber_txt.Visible = false;
                membershipDate_lbl.Visible = false;
                membershipDate_txt.Visible = false;

                cronum_lbl.Visible = true;
                cronum_txt.Visible = true;
                articleDate_lbl.Visible = true;
                articleDate_txt.Visible = true;
            }
        }

       
       

      

        protected void register_btn_Click(object sender, EventArgs e)
        {
          
            string FullName = fullname_txt.Text;
            string FatherName = fathername_txt.Text;
            string LocalAddress = localaddress_txt.Text;
            string PermanentAddress = permanetAddress_txt.Text;
            string MobileNumber = mobilenumber_txt.Text;
            string WhatsappNumber = whatsappnumber_txt.Text;
            string EmailID = emailid_txt.Text;
            string password = password_txt.Text;
            string cnfPassword = cnfpwd_txt.Text;
            string userType = userType_ddl.SelectedValue;
            string membershipDate = membershipDate_txt.Text;
            string membershipNumber = membershipNumber_txt.Text;
            string croNum = cronum_txt.Text;
            string articleshipDate = articleDate_txt.Text;

            if (String.IsNullOrWhiteSpace(FullName))
            {

            }

            User user = new User();
            //DateTime dt = DateTime.ParseExact("04/26/2016", "MM/dd/yyyy", CultureInfo.InvariantCulture);
            user.Name = FullName;
            user.FathersName = FatherName;
            user.AddressLocal = LocalAddress;
            user.AddressPermanent = PermanentAddress;
            user.CelNumber = MobileNumber;
            user.WhatsAppNumber = WhatsappNumber;
            user.EmailID = EmailID;
            user.Password = password;

            
            user.RoleID = Int32.Parse(userType);
            if (user.RoleID == 2)
            {
                user.MembershipDate = DateTime.ParseExact(membershipDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                user.MembershipNumber = membershipNumber;
            }else if (user.RoleID == 4)
            {
                user.CRONumber = croNum;
                user.ArticleShipStartDate = DateTime.ParseExact(articleshipDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            }
            else
            {
                user.CRONumber = "";
                user.MembershipNumber = "";

                user.MembershipDate = new DateTime();
                user.ArticleShipStartDate = new DateTime();
            }


            user.RegisterUser();
            
        }
    }
}