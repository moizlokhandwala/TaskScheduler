<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TaskList.aspx.cs" Inherits="TaskScheduler.TaskList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Task Lists</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div width="100%" class="table table-responsive">
                <asp:GridView ClientIDMode="Static" AutoGenerateColumns="false" 
                        Width="100%" class="table table-responsive table-striped table-bordered table-hover"
                        runat="server" ID="tasks_gv" EmptyDataText="There are no tasks for you today." 
                        OnRowCommand="tasks_gv_RowCommand" OnRowUpdating="tasks_gv_RowUpdating" OnRowEditing="tasks_gv_RowEditing"
                    OnRowDataBound="tasks_gv_RowDataBound">
                    <Columns>

                        <asp:TemplateField>

                            <HeaderTemplate>
                                <asp:Button runat="server" ID="add_btn" OnClick="add_btn_Click" Text="+" CssClass="btn btn-primary" />
                            </HeaderTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Title">
                            <ItemTemplate>
                                <asp:Label ID="tasktitle_lbl" runat="server"
                                    Text='<%# Eval("TaskTitle")%>'></asp:Label>


                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Author">
                            <ItemTemplate>
                                <asp:Label ID="author_lbl" runat="server"
                                    Text='<%# Eval("Author")%>'></asp:Label>


                            </ItemTemplate>

                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Assignee">
                            <ItemTemplate>
                                <asp:Label ID="assignee_lbl" runat="server"
                                    Text='<%# Eval("Assignee")%>'></asp:Label>


                            </ItemTemplate>

                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Priority">
                            <ItemTemplate>
                                <asp:Label ID="priority_lbl" runat="server"
                                    Text='<%# Eval("Priority")%>'></asp:Label>


                            </ItemTemplate>

                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="status_lbl" runat="server"
                                    Text='<%# Eval("ActivityStatus")%>'></asp:Label>


                            </ItemTemplate>

                        </asp:TemplateField>
                         <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="edit_btn" runat="server" CausesValidation="false" CommandName="update"
                                        CommandArgument='<%# Eval("ActivityID") %>'>
                                        <asp:Label runat="server" ID="edit_lbl" class="fa fa-edit">
                                      
                                        </asp:Label>

                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>



                    </Columns>
                    </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
