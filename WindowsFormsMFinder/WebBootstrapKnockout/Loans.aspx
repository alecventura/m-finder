<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loans.aspx.cs" Inherits="WebBootstrapKnockout.Loans" MasterPageFile="~/Layout/Layout.Master" %>



<asp:Content ContentPlaceHolderID="content" runat="server">
    <script src='<%= ResolveUrl("~/Loans.js") %>'></script>
    <script type="text/javascript">
        var loansJSON = <%= new  System.Web.Script.Serialization.JavaScriptSerializer().Serialize(loansJSON) %>;
    </script>
    <div class="row" id="loan">
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

                    </tr>
                </thead>
                <tbody data-bind="foreach: loans">
                    <tr>
                        <td data-bind="text: $data.machineName"></td>
                        <td data-bind="text: $data.machineSerialNumber"></td>
                        <td data-bind="text: $data.machineModel"></td>
                    </tr>
                </tbody>
            </table>
        </div>

    </div>
</asp:Content>
