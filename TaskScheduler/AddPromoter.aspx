<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddPromoter.aspx.cs" Inherits="TaskScheduler.AddPromoter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Add Promoter Details</h1>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <b>Please Enter the Promoter details.</b>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-1">
                        </div>
                        <div class="col-lg-10">
                            <div class="form-group col-md-6">
                                <label>Client</label>
                                <asp:DropDownList ID="client_ddl" runat="server"
                                    CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-md-6">
                                <label>Name</label>

                                <asp:TextBox runat="server" ID="name_txt"
                                    name="name_txt"
                                    placeholder="Name"
                                    CssClass="form-control" required>

                                </asp:TextBox>

                            </div>

                            <div class="form-group col-md-6">
                                <label>Designation</label>

                                <asp:TextBox runat="server" ID="designation_txt"
                                    name="designation_txt"
                                    placeholder="Designation"
                                    CssClass="form-control" required>

                                </asp:TextBox>

                            </div>

                            <div class="form-group col-md-6">
                                <label>Email</label>

                                <asp:TextBox runat="server" ID="email_txt"
                                    name="email_txt"
                                    type="email"
                                    placeholder="Email"
                                    CssClass="form-control" required>

                                </asp:TextBox>

                            </div>

                            <div class="form-group col-md-6">
                                <label>Mobile Number</label>

                                <asp:TextBox runat="server" ID="mobile_txt"
                                    name="mobile_txt"
                                    
                                    placeholder="Mobile Number"
                                    CssClass="form-control" required>

                                </asp:TextBox>

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
