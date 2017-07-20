<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="TaskScheduler.UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">User Details</h1>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <asp:Label ID="username_lbl" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="panel-body">
                        <div class="col-md-6">
                            <b>Permanent Address : </b>
                            <asp:Label runat="server" ID="permanentaddress_lbl"> </asp:Label>
                        </div>
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="localaddress_lbl"> </asp:Label>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
