<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="TaskScheduler.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Edit Profile</h1>
        </div>

        <div class="col-lg-12">
            <div class="row">
                <div class="form-group col-md-6">
                    <label>Full Name</label>

                    <asp:TextBox runat="server" ID="fullname_txt" name="fullname_txt" ng-model="fullname_txt" placeholder="First and Lastname" CssClass="form-control" required></asp:TextBox>

                </div>


                <div class="form-group col-md-6">
                    <label>Father's Name</label>

                    <asp:TextBox runat="server" ID="fathername_txt" ng-model="fathername_txt" placeholder="Father's Name" CssClass="form-control" required></asp:TextBox>
                </div>

                <div class="form-group col-md-6">
                    <label>Local Address</label>

                    <asp:TextBox TextMode="MultiLine" ng-model="localaddress_txt" ng-change="setAddress()" runat="server" ID="localaddress_txt" Rows="5" Columns="10" CssClass="form-control" required></asp:TextBox>
                </div>

                <div class="form-group col-md-6">
                    <label>Permanent Address</label>

                    <asp:TextBox TextMode="MultiLine" runat="server" ng-model="permanetAddress_txt" ID="permanetAddress_txt" Rows="5" Columns="10" CssClass="form-control" required></asp:TextBox>
                </div>

                <div class="form-group col-md-6">
                    <label>Mobile Number</label>

                    <asp:TextBox runat="server" ID="mobilenumber_txt" ng-change="mobileChange()" name="mobilenumber_txt" ng-maxlength="10" ng-minlength="10" ng-model="mobilenumber_txt" placeholder="Mobile Number" CssClass="form-control" ng-pattern="pattern" required></asp:TextBox>


                </div>

                <div class="form-group col-md-6">
                    <label>Whatsapp Number</label>

                    <asp:TextBox runat="server" ID="whatsappnumber_txt" name="whatsappnumber_txt" ng-model="whatsappnumber_txt" placeholder="Whatsapp Number" CssClass="form-control" ng-maxlength="10" ng-minlength="10" ng-pattern="pattern" required></asp:TextBox>
                </div>
                <div class="form-group col-md-6">
                    <label>EmailID</label>

                    <asp:TextBox runat="server" ID="emailid_txt" ng-model="emailid_txt" type="email" placeholder="abc@test.com" CssClass="form-control" required></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="form-group col-md-6">
                    <asp:Button ID="update_btn" OnClick="update_btn_Click" Text="Update" runat="server" CssClass="btn btn-default btn-block" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>
