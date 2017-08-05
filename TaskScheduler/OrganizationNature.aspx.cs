using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler.Model;

namespace TaskScheduler
{
    public partial class OrganizationNature : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Nature nature = new Nature();
                natures_gv.DataSource = nature.GetNatures();
                natures_gv.DataBind();
            }
        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
            string value = naturename_txt.Text;

            Nature nature = new Nature();
            nature.Value = value;
            nature.AddNature();
            Response.Redirect("OrganizationNature.aspx");
        }

        protected void natures_gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void natures_gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void natures_gv_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void natures_gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}