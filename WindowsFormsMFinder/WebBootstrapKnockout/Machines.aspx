<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Machines.aspx.cs" Inherits="WebBootstrapKnockout.EditMachine" MasterPageFile="~/Layout/Layout.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <script src='<%= ResolveUrl("~/Machines.js") %>'></script>
    <script type="text/javascript">
        var dptos = <%= new  System.Web.Script.Serialization.JavaScriptSerializer().Serialize(dptos) %>;
    </script>
    <div class="row" id="machines" style="margin: 0">
        <div class="col-xs-10 col-xs-offset-1" style="margin-top: 10px;">
            <div data-bind='component: {name: "machine-create", params:{dptos: $data.dptos, objModal: null, isVisible: $data.isVisible, machines: $data.machines, isEdit: false, search: $data.findMachines}}'></div>
        </div>
        <div class="col-xs-10 col-xs-offset-1">
            <h2 style="text-align: center;">Machines</h2>

            <table id="machinesTable" class="table">
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
                        <th>Edit
                        </th>
                        <th>Remove
                        </th>

                    </tr>
                </thead>
                <tbody data-bind="foreach: machines">
                    <tr>
                        <td data-bind="text: $data.model"></td>
                        <td data-bind="text: $data.name"></td>
                        <td data-bind="text: $data.serialnumber"></td>
                        <td data-bind="text: $data.aquisitionDateText"></td>
                        <td data-bind="text: $data.warrantyExpirationDateText"></td>
                        <td>
                            <div data-bind='component: {name: "machine-create", params:{dptos: $root.dptos, objModal: $data, isVisible: null, machines: $root.machines, isEdit: true, search: $data.findMachines}}'></div>
                        </td>
                        <td>
                            <a href="#" data-bind="click: $root.onRemoveClicked"><i class="glyphicon glyphicon-remove-circle"></i></a>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div id="pager" class="pager"></div>
        </div>
    </div>
</asp:Content>
