<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="CDA Training Web App Login!"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lb_error" runat="server" ForeColor="Red" Text="Username and password fields must be filled out" Visible="False"></asp:Label>
    </p>
<p>
    Username</p>
<p>
    <asp:TextBox ID="tb_user" runat="server" Width="200px"></asp:TextBox>
</p>
<p>
    Password</p>
<p>
    <asp:TextBox ID="tb_pass" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" Text="Login" />
</p>
<p>
    <asp:Button ID="btn_create_account" runat="server" OnClick="btn_create_account_Click" Text="Create Account" />
</p>
</asp:Content>

