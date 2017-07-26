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
                        <asp:Label runat="server" ID="tasktitle_lbl"></asp:Label>
                    </div>

                    <div class="panel-body">
                        <div class="row">
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
















