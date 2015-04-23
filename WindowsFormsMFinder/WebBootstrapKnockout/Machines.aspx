<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Machines.aspx.cs" Inherits="WebBootstrapKnockout.EditMachine" MasterPageFile="~/Layout/Layout.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <script src='<%= ResolveUrl("~/Machines.js") %>'></script>
    <script type="text/javascript">
        var machines = <%= new  System.Web.Script.Serialization.JavaScriptSerializer().Serialize(machines) %>;
        var dptos = <%= new  System.Web.Script.Serialization.JavaScriptSerializer().Serialize(dptos) %>;
    </script>
    <div class="row" id="machines">
        <div class="col-xs-10 col-xs-offset-1" style="margin-top: 10px;">
            <button type="button" class="btn btn-primary" data-bind="click: onAddNewClicked">Add new machine</button>
        </div>
        <div class="col-xs-10 col-xs-offset-1" style="margin-top: 100px;">
            <h2 style="text-align: center;">Machines</h2>

            <table id="loansTable" class="table">
                <thead>
                    <tr>
                        <th>Nodel
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
                            <a href="#" data-bind="click: $root.onEditClicked"><i class="glyphicon glyphicon-edit"></i></a>
                        </td>
                        <td>
                            <a href="#" data-bind="click: $root.onRemoveClicked"><i class="glyphicon glyphicon-remove-circle"></i></a>
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
                        <h4 class="modal-title">Edit Machine</h4>
                    </div>
                    <div class="modal-body" data-bind="with: objModal">
                        <div class="form-group margin-bottom20">
                            <label class="control-label label-centralized col-lg-4">Model:</label>
                            <input class="input-nice col-lg-8" type="text" id="model" data-bind="value: model" />
                        </div>
                        <br />
                        <div class="form-group margin-bottom20">
                            <label class="control-label label-centralized col-lg-4">Name:</label>
                            <input class="input-nice col-lg-8" type="text" id="name" data-bind="value: name" />
                        </div>
                        <br />
                        <div class="form-group margin-bottom20">
                            <label class="control-label label-centralized col-lg-4">Serialnumber:</label>
                            <input class="input-nice col-lg-8" type="text" id="serialnumber" data-bind="value: serialnumber" />
                        </div>
                        <br />
                        <div class="form-group margin-bottom20">
                            <label class="control-label label-centralized col-lg-4">AquisitionDate:</label>
                            <input class="input-nice col-lg-8" type="text" id="aquisitionDate" data-bind="pickadate: aquisitionDate, value: aquisitionDate" />
                        </div>
                        <br />
                        <div class="form-group margin-bottom20">
                            <label class="control-label label-centralized col-lg-4">WarrantyExpirationDate:</label>
                            <input class="input-nice col-lg-8" type="text" id="warrantyExpirationDate" data-bind="pickadate: warrantyExpirationDate, value: warrantyExpirationDate" />
                        </div>
                        <br />
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-bind="toggle: isVisible">Close</button>
                        <button type="button" class="btn btn-primary" data-bind="click: onSaveClicked">Save</button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
    </div>
</asp:Content>
