<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebBootstrapKnockout.Login" MasterPageFile="~/Layout/Layout.Master" %>


<asp:Content ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="col-xs-4 col-xs-offset-4" style="margin-top: 100px;">
            <h2 style="text-align: center;">LOGIN</h2>

            <asp:TextBox ID="username" runat="server" Width="100%" CssClass="margin-top15" PlaceHolder="Username" />
            <br />
            <asp:TextBox ID="password" runat="server" Width="100%" CssClass="margin-top15" PlaceHolder="Password" />
            <br />
            <asp:Button ID="loginButton" Text="Login" OnClick="onLoginClicked" runat="server" CssClass="btn btn-primary btn-block margin-top15" />
            <br />
            <asp:LinkButton runat="server" OnClick="onGoToRegistrationClicked">Don't have a account? signin here!</asp:LinkButton>
        </div>

    </div>

</asp:Content>
