<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="OrganizationNature.aspx.cs" Inherits="TaskScheduler.OrganizationNature" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Organization Nature</h1>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <b>Add a new Nature for Organization</b>
                </div>

                <div class="panel-body">
                    <div class="row">
                        <div class="form-group col-md-6">
                            <label>Name</label>

                            <asp:TextBox runat="server" ID="naturename_txt" name="naturename_txt" placeholder="Name" CssClass="form-control"></asp:TextBox>

                        </div>
                    </div>
                    <div class="row">
                         <div class="form-group col-md-6">
                            <asp:Button runat="server" ID="add_btn" OnClick="add_btn_Click" CssClass="btn btn-success" Text="Add" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div width="100%" class="table table-responsive">
            <asp:GridView ClientIDMode="Static" AutoGenerateColumns="false"
                Width="100%" class="table table-responsive table-striped table-bordered table-hover"
                runat="server" ID="natures_gv" EmptyDataText="No Data Found, Kindly add some."
                OnRowCommand="natures_gv_RowCommand"
                OnRowUpdating="natures_gv_RowUpdating"
                OnRowEditing="natures_gv_RowEditing"
                OnRowDataBound="natures_gv_RowDataBound">

                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="structureid_lbl" runat="server"
                                Text='<%# Eval("ID")%>'></asp:Label>


                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="structurename_lbl" runat="server"
                                Text='<%# Eval("Value")%>'></asp:Label>


                        </ItemTemplate>

                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
    </div>

</asp:Content>
