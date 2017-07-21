<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="TaskScheduler.AddTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Add Task</h1>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
               <b>     Please fill the form to add a new task.</b>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-8">

                            <div class="row">
                                <div class="form-group col-md-6">
                                    <label>Title</label>

                                    <asp:TextBox runat="server" ID="title_txt" name="title_txt" placeholder="Title" CssClass="form-control"></asp:TextBox>

                                </div>

                                <div class="form-group col-md-6">
                                    <label>Priority</label>
                                    <asp:DropDownList ID="priority_ddl" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>

                            </div>
                          
                            <div class="row">
                                <div class="form-group col-md-12">
                                    <label>Description</label>

                                    <asp:TextBox TextMode="MultiLine"  runat="server" ID="description_txt" Rows="5" Columns="10" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="form-group col-md-6">
                                    <label>Assignee</label>
                                    <asp:DropDownList ID="assignee_ddl" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                
                                <div class="col-md-6">
                                    <label></label>
                                    <br />
                                   <asp:Button runat="server" ID="addtask_btn" OnClick="addtask_btn_Click" CssClass="btn btn-success" Text="Create Task" />
                                </div> 

                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
