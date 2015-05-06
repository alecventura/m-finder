<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loans.aspx.cs" Inherits="WebBootstrapKnockout.Loans" MasterPageFile="~/Layout/Layout.Master" %>



<asp:Content ContentPlaceHolderID="content" runat="server">
    <div class="row" id="loans">
        <div class="col-xs-10 col-xs-offset-1" style="margin-top: 10px;">
            <button type="button" class="btn btn-primary" data-bind="toggle: isVisible">Make a Loan</button>
        </div>

        <div class="col-xs-10 col-xs-offset-1" style="margin-top: 100px;">
            <h2 style="text-align: center;">LOANS</h2>

            <table id="loansTable" class="table">
                <thead>
                    <tr>
                        <th>Machine Name
                        </th>
                        <th>Serial Number
                        </th>
                        <th>Model
                        </th>
                        <th>Loan Date
                        </th>
                        <th>User Name
                        </th>
                        <th>Dpto
                        </th>
                        <th style="text-align: center;">Return
                        </th>

                    </tr>
                </thead>
                <tbody data-bind="foreach: loans">
                    <tr>
                        <td data-bind="text: $data.machineName"></td>
                        <td data-bind="text: $data.machineSerialNumber"></td>
                        <td data-bind="text: $data.machineModel"></td>
                        <td data-bind="text: $data.loanDateText"></td>
                        <td>
                            <!-- ko text: userFirstname -->
                            <!--/ko-->
                            <!-- ko text: userLastName -->
                            <!--/ko-->
                        </td>
                        <td data-bind="text: $data.dptoText"></td>
                        <td style="text-align: center;">
                            <a href="#" data-bind="click: $root.onReturnLoanClicked"><i class="glyphicon glyphicon-edit"></i></a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

        <div class="modal large-modal" data-bind="isVisibleBig: $data.isVisible" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-bind="toggle: isVisible" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">New Loan</h4>
                    </div>
                    <div class="modal-body  margin-bottom20">
                        <div id="rootwizard">
                            <div class="navbar">
                                <div class="navbar-inner stepwizard">
                                    <div class="container stepwizard-row">
                                        <ul>
                                            <li class="stepwizard-step oneThird"><a href="#machine" data-toggle="tab" class="btn btn-default btn-circle">1</a></li>
                                            <li class="stepwizard-step oneThird"><a href="#user" data-toggle="tab" class="btn btn-default btn-circle">2</a></li>
                                            <li class="stepwizard-step oneThird"><a href="#aditionalInfo" data-toggle="tab" class="btn btn-default btn-circle">3</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-content">
                                <%--Machine Tab--%>
                                <div class="tab-pane" id="machine">
                                    <div data-bind="visible: hasSelectedMachine">
                                        <div data-bind="with: $root.newLoan().machine">
                                            <!-- ko text: model -->
                                            <!--/ko-->
                                            -
                                            <!-- ko text: name -->
                                            <!--/ko-->
                                            -
                                            <!-- ko text: serialnumber -->
                                            <!--/ko-->
                                            <a href="#" style="margin-left: 10px;" data-bind="click: $root.changeMachine"><i class="glyphicon glyphicon-edit"></i></a>
                                        </div>
                                    </div>
                                    <div class="row" data-bind="visible: !hasSelectedMachine()">
                                        <h4 class="col-lg-2" style="text-align: left;">Select a Machine</h4>

                                        <div class="col-lg-10 " data-bind="with: $root.machineRequest">
                                            <div class="row">
                                                <div class="form-group" style="margin-bottom: 0">
                                                    <label class="control-label label-centralized col-lg-1">Model:</label>
                                                    <input class="input-nice col-lg-2" type="text" data-bind="value: model" />
                                                </div>
                                                <div class="form-group" style="margin-bottom: 0">
                                                    <label class="control-label label-centralized col-lg-1">Name:</label>
                                                    <input class="input-nice col-lg-2" type="text" data-bind="value: name" />
                                                </div>
                                                <div class="form-group" style="margin-bottom: 0">
                                                    <label class="control-label label-centralized col-lg-2">Serialnumber:</label>
                                                    <input class="input-nice col-lg-2" type="text" data-bind="value: serialnumber" />
                                                </div>
                                                <div class="pull-right">
                                                    <button type="button" class="btn btn-primary" style="margin-right: 50px;" data-bind="click: $root.searchMachines">Search</button>
                                                </div>
                                            </div>

                                        </div>

                                        <table id="machinesTable" class="table table-hover" data-bind="visible: $root.machines().length > 0">
                                            <thead>
                                                <tr>
                                                    <th>Model
                                                    </th>
                                                    <th>Name
                                                    </th>
                                                    <th>SerialNumber
                                                    </th>
                                                    <th>Aquisition Date
                                                    </th>
                                                    <th>Warranty Expiration Date
                                                    </th>

                                                </tr>
                                            </thead>
                                            <tbody data-bind="foreach: machines">
                                                <tr data-bind="click: $root.selectMachine">
                                                    <td data-bind="text: $data.model"></td>
                                                    <td data-bind="text: $data.name"></td>
                                                    <td data-bind="text: $data.serialnumber"></td>
                                                    <td data-bind="text: $data.aquisitionDateText"></td>
                                                    <td data-bind="text: $data.warrantyExpirationDateText"></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <%--User Tab--%>
                                <div class="tab-pane" id="user">
                                    <div data-bind="visible: hasSelectedUser">
                                        <div data-bind="with: $root.newLoan().user">
                                            <!-- ko text: $data.firstname -->
                                            <!--/ko-->

                                            <!-- ko text: $data.lastname -->
                                            <!--/ko-->
                                            -
                                            <!-- ko text: $data.dptoName -->
                                            <!--/ko-->
                                            <a href="#" style="margin-left: 10px;" data-bind="click: $root.changeUser"><i class="glyphicon glyphicon-edit"></i></a>
                                        </div>
                                    </div>
                                    <div class="row" data-bind="visible: !hasSelectedUser()">
                                        <h4 class="col-lg-2" style="text-align: left;">Select a User</h4>

                                        <div class="col-lg-10 " data-bind="with: $root.userRequest">
                                            <div class="row ">
                                                <div class="form-group" style="margin-bottom: 0">
                                                    <label class="control-label label-centralized col-lg-2">Firstname:</label>
                                                    <input class="input-nice col-lg-2" type="text" data-bind="value: firstname" />
                                                </div>
                                                <div class="form-group col-lg-offset-2" style="margin-bottom: 0">
                                                    <label class="control-label label-centralized col-lg-2">Lastname:</label>
                                                    <input class="input-nice col-lg-2" type="text" data-bind="value: lastname" />
                                                </div>
                                                <div class="pull-right">
                                                    <button type="button" class="btn btn-primary" style="margin-right: 50px;" data-bind="click: $root.searchUsers">Search</button>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row ">
                                                <div class="form-group" style="margin-bottom: 0">
                                                    <label class="control-label label-centralized col-lg-2">Ramal:</label>
                                                    <input class="input-nice col-lg-2" type="text" data-bind="value: ramal" />
                                                </div>
                                                <div class="form-group" style="margin-bottom: 0">
                                                    <label class="control-label label-centralized col-lg-2">Dpto:</label>
                                                    <select class="select-nice col-lg-2" data-bind="options: $root.dptos, optionsValue:'id', optionsText: 'name',value: dpto, optionsCaption: 'Choose a dpto'"></select>
                                                </div>
                                            </div>

                                        </div>

                                        <table id="usersTable" class="table table-hover" data-bind="visible: $root.users().length > 0">
                                            <thead>
                                                <tr>
                                                    <th>First Name
                                                    </th>
                                                    <th>Last Name
                                                    </th>
                                                    <th>Dpto
                                                    </th>
                                                    <th>Ramal
                                                    </th>

                                                </tr>
                                            </thead>
                                            <tbody data-bind="foreach: users">
                                                <tr data-bind="click: $root.selectUser">
                                                    <td data-bind="text: $data.firstname"></td>
                                                    <td data-bind="text: $data.lastname"></td>
                                                    <td data-bind="text: $data.dptoName"></td>
                                                    <td data-bind="text: $data.ramal"></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <%--Aditional Info Tab--%>
                                <div class="tab-pane" id="aditionalInfo">
                                    <div data-bind="with: $root.newLoan().aditional">
                                        <div class="form-group">
                                            <label class="control-label label-centralized col-lg-2 col-lg-offset-3">Date of Loan:</label>
                                            <input class="input-nice col-lg-2" type="text" data-bind="pickadate: loanDate" />
                                        </div>
                                    </div>
                                </div>


                                <br />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default button-previous">Previous</button>
                        <button type="button" class="btn btn-primary button-next" data-bind="visible: !isFinalStep(), disable: !canGoNext()">Next</button>
                        <button type="button" class="btn btn-primary" data-bind="visible: isFinalStep(), click: $data.onSaveClicked">Save</button>
                        <button type="button" class="btn btn-default" data-bind="toggle: $data.isVisible">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        var loansJSON = <%= new  System.Web.Script.Serialization.JavaScriptSerializer().Serialize(loansJSON) %>;
        var dptos = <%= new  System.Web.Script.Serialization.JavaScriptSerializer().Serialize(dptos) %>;
        var roles = <%= new  System.Web.Script.Serialization.JavaScriptSerializer().Serialize(roles) %>;
    </script>
    <script src='<%= ResolveUrl("~/Loans.js") %>'></script>
</asp:Content>
