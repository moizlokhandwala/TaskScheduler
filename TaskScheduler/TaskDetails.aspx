<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TaskDetails.aspx.cs" Inherits="TaskScheduler.TaskDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Task Details</h1>
        </div>

        <div class="row">
            <div class="col-lg-10">
                <div class="panel panel-default">

                    <div class="panel-heading">
                        <asp:Label Font-Bold="true" runat="server" ID="tasktitle_lbl"></asp:Label>
                    </div>

                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label runat="server" Font-Bold="true" Text="Description : "></asp:Label>
                            </div>
                            <div class="col-md-9">
                                <asp:Label runat="server" ID="description_lbl"></asp:Label>
                            </div>

                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label runat="server" Text="Author : " Font-Bold="true"></asp:Label>
                            </div>
                            <div class="col-md-9">
                                <asp:Label runat="server" ID="author_lbl"></asp:Label>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label runat="server" Font-Bold="true" Text="Creation Date and Time : "></asp:Label>
                            </div>
                            <div class="col-md-9">
                                <asp:Label runat="server" ID="creationdate_lbl"></asp:Label>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label runat="server" Text="Priority : " Font-Bold="true"></asp:Label>
                            </div>
                            <div class="col-md-9">
                                <asp:Label runat="server" ID="priority_lbl"></asp:Label>
                            </div>
                        </div>

                        <hr />
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label runat="server" Text="Client Name : " Font-Bold="true"></asp:Label>
                            </div>
                            <div class="col-md-9">
                                <asp:Label runat="server" ID="clientname_lbl"></asp:Label>
                            </div>
                        </div>

                        <hr />
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label runat="server" Text="Status : " Font-Bold="true"></asp:Label>
                            </div>
                            <div class="col-md-9">
                                <asp:Label runat="server" ID="status_lbl"></asp:Label>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="form-group col-md-10">
                                <asp:Label runat="server" ID="comments_lbl" Visible="false" Text="Comment : "></asp:Label>

                                <asp:TextBox Visible="false" TextMode="MultiLine" runat="server" ID="comment_txt" Rows="5" Columns="10" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group col-md-6">
                                <asp:Label Font-Bold="true" runat="server" ID="activitystatus_lbl" Visible="false">Status</asp:Label>

                                <asp:DropDownList Visible="false" runat="server" ID="status_ddl" CssClass="form-control"></asp:DropDownList>
                            </div>

                        </div>
                        <hr />
                        <div class="row">
                            <div class="form-group col-md-6">
                                <asp:Label Font-Bold="true" runat="server" ID="assignee_lbl" Visible="false" Text="Assignee"></asp:Label>

                                <asp:DropDownList Visible="false" runat="server" ID="assignee_ddl" CssClass="form-control"></asp:DropDownList>
                            </div>

                        </div>

                        <div class="row">
                            <div class="form-group col-md-6">
                                <asp:Button Visible="false" runat="server" ID="update_btn" Text="Update" class="btn btn-primary" OnClick="update_btn_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <i class="fa fa-clock-o fa-fw"></i>Actvity Timeline
                      
                        <asp:Label runat="server" ID="activityId_lbl" Visible="false"></asp:Label>
                        <asp:LinkButton Visible="false" runat="server" class="pull-right" ID="edit_btn" OnClick="edit_btn_Click">
                     <i class="fa fa-edit fa-fw"></i>
                        </asp:LinkButton>

                        <asp:LinkButton Visible="false" runat="server" class="pull-right" ID="start_btn" OnClick="start_btn_Click">
                     <i class="fa fa-play fa-fw"></i>
                        </asp:LinkButton>

                        <asp:LinkButton Visible="false" runat="server" class="pull-right" ID="stop_btn" OnClick="stop_btn_Click">
                     <i class="fa fa-stop fa-fw"></i>
                        </asp:LinkButton>
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <ul class="timeline">
                            <asp:Literal runat="server" ID="activities_ltl">
                                 
                            </asp:Literal>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
















