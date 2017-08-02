<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditActivity.aspx.cs" Inherits="TaskScheduler.EditActivity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Edit Task</h1>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
               <b>     Add Comments and update the status</b>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-8">
                            <div class="row">
                                <div class="form-group col-md-12">
                                    <label>Comment</label>

                                    <asp:TextBox TextMode="MultiLine" runat="server" ID="comment_txt" Rows="5" Columns="10" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                             <div class="row">
                                <div class="form-group col-md-6">
                                    <label>Status</label>

                                    <asp:DropDownList runat="server" ID="status_ddl"></asp:DropDownList>
                                </div>
                                 <div class="form-group col-md-6">
                                     <asp:Button runat="server" ID="update_btn" Text="Update" class="btn btn-primary" OnClick="update_btn_Click" />
                                 </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
