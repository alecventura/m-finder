﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="machinecreate.aspx.cs" Inherits="WebBootstrapKnockout.components.machine_create.machinecreate" %>

<div class="col-xs-10 col-xs-offset-1" style="margin-top: 10px;">
    <button type="button" class="btn btn-primary" data-bind="click: onAddNewClicked">Add new machine</button>
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
                    <input class="input-nice col-lg-8" type="text" id="aquisitionDate" data-bind="pickadate: aquisitionDate" />
                </div>
                <br />
                <div class="form-group margin-bottom20">
                    <label class="control-label label-centralized col-lg-4">WarrantyExpirationDate:</label>
                    <input class="input-nice col-lg-8" type="text" id="warrantyExpirationDate" data-bind="pickadate: warrantyExpirationDate" />
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
