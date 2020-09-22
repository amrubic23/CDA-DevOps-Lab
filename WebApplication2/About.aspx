<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication2.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
    Create an account:</p>
<p>
    <asp:Label ID="lb_error" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    </p>
<p>
    Username</p>
<p>
    <asp:TextBox ID="tb_user" runat="server" Width="200px"></asp:TextBox>
</p>
<p>
    Password</p>
<p>
    <asp:TextBox ID="tb_pass1" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
</p>
<p>
    Re-enter Password</p>
<p>
    <asp:TextBox ID="tb_pass2" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btn_new_account" runat="server" OnClick="btn_new_account_Click" Text="Create Account" />
</p>
</asp:Content>
