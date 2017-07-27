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
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
















