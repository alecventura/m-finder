<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="WebBootstrapKnockout.Users" MasterPageFile="~/Layout/Layout.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <script src='<%= ResolveUrl("~/Users.js") %>'></script>
    <script type="text/javascript">
        var usersJSON = <%= new  System.Web.Script.Serialization.JavaScriptSerializer().Serialize(usersJSON) %>;
        var dptos = <%= new  System.Web.Script.Serialization.JavaScriptSerializer().Serialize(dptos) %>;
        var roles = <%= new  System.Web.Script.Serialization.JavaScriptSerializer().Serialize(roles) %>;
    </script>
    <div class="row" id="users">
        <div class="col-xs-10 col-xs-offset-1" style="margin-top: 10px;">
            <button type="button" class="btn btn-primary" data-bind="click: onAddNewUserClicked">Add new user</button>
        </div>
        <div class="col-xs-10 col-xs-offset-1" style="margin-top: 100px;">
            <h2 style="text-align: center;">USERS</h2>

            <table id="loansTable" class="table">
                <thead>
                    <tr>
                        <th>First Name
                        </th>
                        <th>Last Name
                        </th>
                        <th>Dpto
                        </th>
                        <th>Role
                        </th>
                        <th>Edit
                        </th>
                        <th>Remove
                        </th>

                    </tr>
                </thead>
                <tbody data-bind="foreach: users">
                    <tr>
                        <td data-bind="text: $data.firstname"></td>
                        <td data-bind="text: $data.lastname"></td>
                        <td data-bind="text: $data.dptoName"></td>
                        <td data-bind="text: $data.roleName"></td>
                        <td>
                            <a href="#" data-bind="click: $root.onEditUserClicked"><i class="glyphicon glyphicon-edit"></i></a>
                        </td>
                        <td>
                            <a href="#" data-bind="click: $root.onRemoveUserClicked"><i class="glyphicon glyphicon-remove-circle"></i></a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>


        <div class="modal fade" data-bind="isVisible: isVisible" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-bind="toggle: isVisible" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Edit User</h4>
                    </div>
                    <div class="modal-body" data-bind="with: userModal">
                        <div class="form-group margin-bottom20">
                            <label class="control-label label-centralized col-lg-4">Firstname:</label>
                            <input class="input-nice col-lg-8" type="text" id="firstname" data-bind="value: firstname" />
                        </div>
                        <br />
                        <div class="form-group margin-bottom20">
                            <label class="control-label label-centralized col-lg-4">Lastname:</label>
                            <input class="input-nice col-lg-8" type="text" id="lastname" data-bind="value: lastname" />
                        </div>
                        <br />
                        <div class="form-group margin-bottom20">
                            <label class="control-label label-centralized col-lg-4">Ramal:</label>
                            <input class="input-nice col-lg-8" type="text" id="ramal" data-bind="value: ramal" />
                        </div>
                        <br />
                        <div class="form-group margin-bottom20">
                            <label class="control-label label-centralized col-lg-4">Dpto:</label>
                            <select class="select-nice  col-lg-8" data-bind="options: $root.dptos, optionsValue:'id', optionsText: 'name',value: dpto"></select>
                        </div>
                        <br />
                        <div class="form-group margin-bottom20">
                            <label class="control-label label-centralized col-lg-4">Role:</label>
                            <select class="select-nice col-lg-8" data-bind="options: $root.roles, optionsValue:'id' ,optionsText: 'name',value: role"></select>
                        </div>
                        <br />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-bind="toggle: isVisible">Close</button>
                        <button type="button" class="btn btn-primary" data-bind="click: onSaveUserClicked">Save User</button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
    </div>
</asp:Content>
