<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="TaskScheduler.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="Library/style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Users</h1>
        </div>
        <!-- /.col-lg-12 -->

        <div class="row">
            <div class="col-lg-12">
                <%--<div class="panel panel-default">--%>
                <%--  <div class="panel-heading">
                       
                     </div>--%>

                <%-- <div class="panel-body">--%>
                <div width="100%" class="table table-responsive">
                    <asp:GridView ClientIDMode="Static" AutoGenerateColumns="false" 
                        Width="100%" class="table table-responsive table-striped table-bordered table-hover"
                        runat="server" ID="users_gv" EmptyDataText="There are no users in the system" 
                        OnRowCommand="users_gv_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="name_lbl" runat="server"
                                        Text='<%# Eval("Name")%>'></asp:Label>


                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Role">
                                <ItemTemplate>
                                    <asp:Label ID="rolename_lbl" runat="server"
                                        Text='<%# Eval("RoleName")%>'></asp:Label>


                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="active_lbl" runat="server"
                                        Text='<%# Eval("Active")%>'></asp:Label>


                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Email Id">
                                <ItemTemplate>
                                    <asp:Label ID="email_lbl" runat="server"
                                        Text='<%# Eval("EmailID")%>'></asp:Label>


                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Mobile Number">
                                <ItemTemplate>
                                    <asp:Label ID="mobilenumber_lbl" runat="server"
                                        Text='<%# Eval("MobileNumber")%>'></asp:Label>


                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="details_btn" runat="server" CausesValidation="false" CommandName="Details"
                                        CommandArgument='<%# Eval("ID") %>'>
                                        <asp:Label runat="server" ID="details_lb" class="fa fa-user">
                                      
                                        </asp:Label>

                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField ShowHeader="false">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="activate_btn" CommandName="Inactive" CommandArgument='<%# Eval("ID")%>'>
                                        <asp:Label ID="status_lbl" runat="server"
                                        ></asp:Label>
                                    </asp:LinkButton>
                                    
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <%--           </div>
    </div>--%>
</asp:Content>
