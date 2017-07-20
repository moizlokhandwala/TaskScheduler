<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="TaskScheduler.UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">User Details</h1>
        </div>

        <div class="row">
            <div class="col-lg-10">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <asp:Label ID="username_lbl" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="col-md-5 text-right">
                                    <b>Permanent Address: </b>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="permanentaddress_lbl"> </asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">

                                <div class="col-md-5  text-right">
                                    <b>Local Address: </b>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="localaddress_lbl"> </asp:Label>
                                </div>

                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="col-md-5  text-right">
                                    <b>Mobile Number:</b>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="mobile_lbl"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="col-md-5  text-right">
                                    <b>Whatsapp Number:</b>
                                </div>
                                <div class="col-md-6">
                                     <asp:Label runat="server" ID="whatsapp_lbl"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <hr />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="col-md-5  text-right">
                                    <b>Father's Name:</b>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="fathername_lbl"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="col-md-5  text-right">
                                    <b>Email:</b>
                                </div>
                                <div class="col-md-6">
                                     <asp:Label runat="server" ID="email_lbl"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-3"></div>
                            <div class="form-group col-md-6">
                                <asp:Button ID="updateUser_btn" OnClick="updateUser_btn_Click" Text="Update" runat="server" CssClass="btn btn-default btn-success" />


                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
