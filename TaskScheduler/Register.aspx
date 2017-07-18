<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TaskScheduler.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>

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
                <li><a class="dropdown-toggle" data-toggle="dropdown" href="Login.aspx">
                    <i class="fa fa-sign-in fa-fw"></i>Login
                </a></li>
            </ul>
        </nav>
        <div class="row">
            <div class="col-md-3">
            </div>
            <div id="LoginBlock" class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Registration Form
                       
                    </div>

                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form role="form" id="form1" runat="server" ng-app="myApp" ng-controller="validateCtrl"
                                    name="form1">

                                    <asp:ScriptManager runat="server" ID="Script1"></asp:ScriptManager>

                                    <div class="form-group col-md-6">
                                        <label>Full Name</label>

                                        <asp:TextBox runat="server" ID="fullname_txt" name="fullname_txt" ng-model="fullname_txt" placeholder="First and Lastname" CssClass="form-control" required></asp:TextBox>

                                    </div>


                                    <div class="form-group col-md-6">
                                        <label>Father's Name</label>

                                        <asp:TextBox runat="server" ID="fathername_txt" ng-model="fathername_txt" placeholder="Father's Name" CssClass="form-control" required></asp:TextBox>


                                    </div>

                                    <div class="form-group col-md-12">
                                        <div class="col-md-6 text-danger" style="display:block;">
                                            <span ng-show="form1.fullname_txt.$invalid"> Fullname is required!!!</span>

                                        </div>

                                        <div class="col-md-6 text-danger" style="display:block;">
                                            <span ng-show="form1.fathername_txt.$invalid">Father's Name is required!!!</span>

                                        </div>
                                       
                                    </div>
                                   
                                    
                                    <div class="form-group col-md-6">
                                        <label>Local Address</label>

                                        <asp:TextBox TextMode="MultiLine" ng-model="localaddress_txt" ng-change="setAddress()" runat="server" ID="localaddress_txt" Rows="5" Columns="10" CssClass="form-control" required></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-6">
                                        <label>Permanent Address</label>

                                        <asp:TextBox TextMode="MultiLine" runat="server" ng-model="permanetAddress_txt" ID="permanetAddress_txt" Rows="5" Columns="10" CssClass="form-control" required></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-12">
                                        <div class="col-md-6 text-danger" style="display:block;">
                                            <span ng-show="form1.localaddress_txt.$invalid"> Local Address is required!!!</span>

                                        </div>

                                        <div class="col-md-6 text-danger" style="display:block;">
                                            <span ng-show="form1.permanetAddress_txt.$invalid">Permanent Address is required!!!</span>

                                        </div>
                                       
                                    </div>

                                    <div class="form-group col-md-12">

                                       <div class="checkbox">
                                            <label>
                                               <input type="checkbox" ng-click="setAddress()" ng-model="addressCheckbox.value1" /> Local address and permanent address are same.
                                             
                                            </label>
                                            
                                        </div>
                                    </div>

                                    <div class="form-group col-md-6">
                                        <label>Mobile Number</label>

                                        <asp:TextBox runat="server" ID="mobilenumber_txt" ng-change="mobileChange()" name="mobilenumber_txt" ng-maxlength="10" ng-minlength="10" ng-model="mobilenumber_txt" placeholder="Mobile Number" CssClass="form-control" ng-pattern="pattern"  required></asp:TextBox>


                                    </div>

                                    <div class="form-group col-md-6">
                                        <label>Whatsapp Number</label>

                                        <asp:TextBox  runat="server" ID="whatsappnumber_txt" name="whatsappnumber_txt" ng-model="whatsappnumber_txt" placeholder="Whatsapp Number" CssClass="form-control" ng-maxlength="10" ng-minlength="10" ng-pattern="pattern"  required></asp:TextBox>
                                    </div>

                                         <div class="form-group col-md-12">
                                        <div class="col-md-6 text-danger" style="display:block;">
                                            <span ng-show="form1.mobilenumber_txt.$invalid"> Mobile Number is required!!!</span>

                                        </div>

                                        <div class="col-md-6 text-danger" style="display:block;">
                                            <span ng-show="form1.whatsappnumber_txt.$invalid">Whatsapp number is required!!!</span>

                                        </div>
                                       
                                    </div>

                                    <div class="form-group col-md-12">

                                        <div class="checkbox">
                                            <label>
                                               <input type="checkbox" ng-click="setMobile()" ng-model="checkboxModel.value1" /> Mobile number and Whatsapp number are same
                                             
                                            </label>
                                            
                                        </div>
                                    </div>

                                    <div class="form-group col-md-6">
                                        <label>EmailID</label>

                                        <asp:TextBox runat="server" ID="emailid_txt" ng-model="emailid_txt" type="email" placeholder="abc@test.com" CssClass="form-control" required></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Password</label>
                                        <asp:TextBox type="password" runat="server" ID="password_txt" placeholder="Password should be Maximum 8 digit" CssClass="form-control" ng-model="password_txt"  ng-minlength="5" ng-maxlength="8" required></asp:TextBox>
                                    </div>

                                     <div class="form-group col-md-12">
                                        <div class="col-md-6 text-danger" style="display:block;">
                                            <span ng-show="form1.emailid_txt.$invalid"> Emailid is invalid!!!</span>

                                        </div>

                                        <div class="col-md-6 text-danger" style="display:block;">
                                            <span ng-show="form1.password_txt.$invalid">Password is required!!!</span>

                                        </div>
                                       
                                    </div>

                                    <div class="form-group col-md-6">
                                        <label>Confirm Password</label>
                                        <asp:TextBox type="password" runat="server" ID="cnfpwd_txt" placeholder="Password should be Maximum 8 digit" CssClass="form-control" ng-model="cnfpwd_txt" ng-minlength="5" ng-maxlength="8" required></asp:TextBox>
                                    </div>
                                    <div class="col-md-6"></div>
                                    <div class="form-group col-md-6">
                                        <label>Type</label>



                                        <asp:DropDownList ID="userType_ddl" ng-init="userType_ddl='1'" runat="server" ng-model="userType_ddl" ng-change="test()" AutoPostBack="false" OnSelectedIndexChanged="userType_ddl_SelectedIndexChanged" CssClass="form-control" required></asp:DropDownList>
                                    </div>

                                   
                                   
                                    <div class="form-group col-md-6" ng-show="userType_ddl=='4'">
                                        <asp:Label runat="server" ID="cronum_lbl" Text="CRO Number"></asp:Label>
                                        <asp:TextBox runat="server" ID="cronum_txt" ng-model="cronum_txt" placeholder="CRO Number" CssClass="form-control"  required="{{userType_ddl=='4'}}"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6" ng-show="userType_ddl=='4'">
                                        <asp:Label runat="server" ID="articleDate_lbl" Text="Articleship Start Date"></asp:Label>
                                        <asp:TextBox TextMode="Date" runat="server" ID="articleDate_txt" ng-model="articleDate_txt" placeholder="Articleship Date" CssClass="form-control"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="articleDate_txt" Format="dd/MM/yyyy" runat="server" />
                                    </div>

                                    <div class="form-group col-md-12">
                                        <div class="col-md-6 text-danger" style="display:block;">
                                            <span ng-show="form1.cronum_txt.$invalid && userType_ddl=='4'"> CRO Number is required!!!</span>

                                        </div>

                                        <div class="col-md-6 text-danger" style="display:block;">
                                           

                                        </div>
                                       
                                    </div>

                                    <div class="form-group col-md-6" ng-show="userType_ddl=='2'">
                                        <asp:Label runat="server" ID="membershipNumber_lbl" Text="Membership Number"></asp:Label>
                                        <asp:TextBox runat="server" ng-model="membershipNumber_txt" ID="membershipNumber_txt" placeholder="Membership Number" CssClass="form-control" required="{{userType_ddl=='2'}}"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6" ng-show="userType_ddl=='2'">
                                        <asp:Label runat="server" ID="membershipDate_lbl" Text="Membership Date"></asp:Label>
                                        <asp:TextBox TextMode="Date" ng-model="membershipDate_txt" runat="server" ID="membershipDate_txt" placeholder="Membership Date" CssClass="form-control" ></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="membershipDate_txt" Format="dd/MM/yyyy" runat="server" />
                                    </div>

                                    <div class="form-group col-md-12">
                                        <div class="col-md-6 text-danger" style="display: block;">
                                            <span ng-show="form1.membershipNumber_txt.$invalid && userType_ddl=='2'">Membership Number is required!!!</span>

                                        </div>

                                        <div class="col-md-6 text-danger" style="display: block;">
                                           

                                        </div>

                                    </div>

                                    <div class="form-group col-md-6">
                                        <asp:Button ID="register_btn" OnClick="register_btn_Click" Text="Register" runat="server" CssClass="btn btn-default btn-block" 
                                            ng-disabled="form1.fullname_txt.$invalid"  />

                                       
                                    </div>

                                 
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

       
        
         $scope.pattern = /^\d*$/;
         $scope.mobile_chk = true;
         $scope.checkboxModel = {
             value1: false
         };

         $scope.addressCheckbox = {
             value1: false
         };

         $scope.setAddress = function () {
             if ($scope.addressCheckbox.value1) {
                 $scope.permanetAddress_txt = $scope.localaddress_txt;
             }
         }

         $scope.test = function () {
             console.log($scope.userType_ddl);
         }

         $scope.setMobile = function () {


             if ($scope.checkboxModel.value1) {
             $scope.whatsappnumber_txt = $scope.mobilenumber_txt;
             }

             console.log('Function called');
             console.log($scope.mobilecheckbox.value1);
          //   $scope.whatsappnumber_txt = $scope.mobilenumber_txt;
         };

         $scope.mobileChange = function () {
             if ($scope.checkboxModel.value1) {
                 $scope.whatsappnumber_txt = $scope.mobilenumber_txt;
             }
         }

        
         
         
     });
</script>

</body>
</html>

