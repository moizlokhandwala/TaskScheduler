<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddClient.aspx.cs" Inherits="TaskScheduler.AddClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Add Client</h1>
        </div>
    </div>

    <div class="row">
        <div>
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <b>Please fill the client information.</b>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-1">

                            </div>
                            <div class="col-lg-10">
                                <div class="form-group col-md-6">
                                    <label>Name</label>

                                    <asp:TextBox runat="server" ID="name_txt"
                                        name="name_txt"
                                        placeholder="Client Name"
                                        CssClass="form-control" required>

                                    </asp:TextBox>

                                </div>
                                <div class="form-group col-md-6">
                                    <label>Landline Number</label>

                                    <asp:TextBox runat="server" ID="landline_txt"
                                        name="landline_txt"
                                        placeholder="Landline Number"
                                        CssClass="form-control" required>

                                    </asp:TextBox>

                                </div>

                                <div class="form-group col-md-6">
                                    <label>Local Address</label>

                                    <asp:TextBox TextMode="MultiLine" ng-model="localaddress_txt" ng-change="setAddress()" runat="server" ID="localaddress_txt" Rows="5" Columns="10" CssClass="form-control" required></asp:TextBox>
                                </div>

                                <div class="form-group col-md-6">
                                    <label>Registered Address</label>

                                    <asp:TextBox TextMode="MultiLine" runat="server"  ID="registeredAddress_txt" Rows="5" Columns="10" CssClass="form-control" required></asp:TextBox>
                                </div>

                                <div class="form-group col-md-12">

                                    <div class="checkbox">
                                        <label>
                                            <input type="checkbox" />
                                            Local address and registered address are same.
                                             
                                        </label>

                                    </div>
                                </div>

                                <div class="form-group col-md-6">
                                    <label>Email ID</label>

                                    <asp:TextBox runat="server" ID="emailid_txt"  type="email" placeholder="abc@test.com" CssClass="form-control" required></asp:TextBox>
                                </div>
                                <div class="form-group col-md-6">
                                    <label>Structure</label>

                                    <asp:DropDownList ID="structure_ddl" runat="server" CssClass="form-control" ></asp:DropDownList>
                                </div>
                                 <div class="form-group col-md-6">
                                    <label>PAN Number</label>

                                    <asp:TextBox runat="server" ID="pan_txt"   placeholder="PAN Number" CssClass="form-control" ></asp:TextBox>
                                </div>

                                 <div class="form-group col-md-6">
                                    <label>TAN Number</label>

                                    <asp:TextBox runat="server" ID="tan_txt"   placeholder="TAN Number" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="form-group col-md-6">
                                    <label>GST Number</label>

                                    <asp:TextBox runat="server" ID="gst_txt"   placeholder="GST Number" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="form-group col-md-6">
                                    <label>Nature</label>

                                    <asp:DropDownList ID="nature_ddl" runat="server" CssClass="form-control" required></asp:DropDownList>
                                </div>

                                <div class="form-group col-md-6">
                                    <label>Business Type</label>

                                    <asp:TextBox runat="server" ID="business_txt"   placeholder="Business Type" CssClass="form-control" required></asp:TextBox>
                                </div>


                            </div>
                        </div>
                        <hr />
                        <div class="row text-center">
                            <b>Accountant Details</b>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-1">

                            </div>
                            <div class="col-md-10">
                                <div class="form-group col-md-6">
                                    <label>Name</label>

                                    <asp:TextBox runat="server" ID="accName_txt" placeholder="Accountant's Name" CssClass="form-control" required></asp:TextBox>
                                </div>

                                <div class="form-group col-md-6">
                                    <label>Mobile Number</label>

                                    <asp:TextBox runat="server" ID="mobile_txt" placeholder="Accountant's Mobile Number" CssClass="form-control" required></asp:TextBox>
                                </div>

                                <div class="form-group col-md-6">
                                    <label>Whatsapp Number</label>

                                    <asp:TextBox runat="server" ID="whatsapp_txt" placeholder="Accountant's Whatsapp Number" CssClass="form-control" required></asp:TextBox>
                                </div>

                                <div class="form-group col-md-6">
                                    <label>Email</label>

                                    <asp:TextBox runat="server" ID="accemail_txt" placeholder="Accountant's Email" CssClass="form-control" required></asp:TextBox>
                                </div>

                                <div class="form-group col-md-6">
                                     <asp:Button ID="add_btn" OnClick="add_btn_Click" Text="Add" runat="server" CssClass="btn btn-primary btn-block" 
                                             />
                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
