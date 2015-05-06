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
            <div data-bind='component: {name: "user-create", params:{dptos: $data.dptos, roles: $data.roles, objModal: null, isVisible: $data.isVisible, users: $data.users, isEdit: false}}'></div>
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
                            <div data-bind='component: {name: "user-create", params:{dptos: $root.dptos, roles: $data.roles, objModal: $data, isVisible: null, users: $root.users, isEdit: true}}'></div>
                        </td>
                        <td>
                            <a href="#" data-bind="click: $root.onRemoveClicked"><i class="glyphicon glyphicon-remove-circle"></i></a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
