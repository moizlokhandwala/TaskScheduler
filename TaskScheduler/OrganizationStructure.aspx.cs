﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler.Model;

namespace TaskScheduler
{
    public partial class OrganizationStructure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Structure structure = new Structure();
                structures_gv.DataSource = structure.GetStructures();
                structures_gv.DataBind();
            }
        }

        protected void add_btn_Click(object sender, EventArgs e)
        {
            string value = structurename_txt.Text;

            Structure structure = new Structure();
            structure.Value = value;
            structure.AddStructure();

            Response.Redirect("OrganizationStructure.aspx");
        }

        protected void structures_gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void structures_gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void structures_gv_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void structures_gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void structures_gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}