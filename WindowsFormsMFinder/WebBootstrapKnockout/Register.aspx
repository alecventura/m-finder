<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebBootstrapKnockout.Register" MasterPageFile="~/Layout/Layout.Master" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="col-xs-4 col-xs-offset-4" style="margin-top: 100px;">
            <h2 style="text-align: center;">SIGIN</h2>

            <asp:TextBox ID="username" runat="server" Width="100%" CssClass="margin-top15" PlaceHolder="Username" />
            <br />
            <asp:TextBox ID="password" runat="server" Width="100%" CssClass="margin-top15" PlaceHolder="Password" />
            <br />
            <asp:TextBox ID="repeatPw" runat="server" Width="100%" CssClass="margin-top15" PlaceHolder="Repeat Password" />
            <br />
            <asp:Button ID="registerButton" Text="Register" OnClick="onRegisterClicked" runat="server" CssClass="btn btn-primary btn-block margin-top15" />
        </div>

    </div>

</asp:Content>
