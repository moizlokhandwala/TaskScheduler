using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler.Model;

namespace TaskScheduler
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Attendance attendance = new Attendance();
            attendance.UserID = Int32.Parse(Session["userid_ts"].ToString());



            attendance.AddAttendance(0);

            Session["username_ts"] = null;
            Session["userid_ts"] = null;
            Session["usertype_ts"] = null;

           

            Response.Redirect("Login.aspx");
        }
    }
}