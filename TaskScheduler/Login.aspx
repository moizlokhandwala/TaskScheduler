<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TaskScheduler.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <link href="Library/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!-- MetisMenu CSS -->
    <link href="Library/vendor/metisMenu/metisMenu.min.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="Library/dist/css/sb-admin-2.css" rel="stylesheet" />

    <!-- Morris Charts CSS -->
    <link href="Library/vendor/morrisjs/morris.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="Library/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="Library/style.css" rel="stylesheet" type="text/css" />
    <script src="Library/vendor/angular/angular.min.js"></script>  
</head>
<body>
    <div id="wrapper">
        <nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-bottom: 0">
            <div class="navbar-header">

                <a class="navbar-brand" href="index.html">Task Scheduler v1.0</a>
            </div>
            <ul class="nav navbar-top-links navbar-right">
                <li><a class="dropdown-toggle" data-toggle="dropdown" href="Register.aspx">
                    <i class="fa fa-registered fa-fw"></i>egister
                    </a></li>
            </ul>
        </nav>
        <div class="row">
            <div class="col-md-4">
            </div>
            <div id="LoginBlock" class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Login
                       
                    </div>

                    <div class="panel-body">
                        <div class="row"> 
                             <div class="col-lg-12">
                            <div class="form-group">
                                <asp:Label runat="server" ID="error_lbl" CssClass="text-danger"></asp:Label>
                            </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <form role="form" id="form1" runat="server" ng-app="myApp" ng-controller="validateCtrl"
                                    name="form1">
                                    <div class="form-group">
                                        <label>Email</label>

                                        <asp:TextBox  runat="server" ID="emailid_txt" placeholder="abc@test.com" CssClass="form-control" ng-model="emailid_txt" type="email" required></asp:TextBox>
                                       
                                        
                                    </div>
                                    <div class="form-group">
                                        <label>Password</label>
                                        <asp:TextBox type="password" runat="server" ID="password_txt" placeholder="********" ng-model="password_txt"  ng-minlength="5" ng-maxlength="8" required CssClass="form-control"></asp:TextBox>
                                    </div>

                                  <%--  <div class="form-group">
                                        <label>Type</label>
                                        <asp:DropDownList ID="userType_ddl" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>--%>

                                    <asp:Button ID="login_btn" Text="Sign In" runat="server" OnClick="login_btn_Click" CssClass="btn btn-default btn-block" />
                                     
                                </form>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
           
        </div>

    </div>
     <script>
         var app = angular.module('myApp', []);
         app.controller('validateCtrl', function ($scope) {
         });
</script>
</body>
</html>
