<%@ Page Title="Login" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="XtremeBlog.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">
    <body>
  <section class="container">
    <div class="login">
      <h1>Login Here</h1>
      <form id="login" runat="server">
        <p><asp:TextBox ID="nameTextBox" runat="server" placeholder="UserName or Email"></asp:TextBox></p>
         <p><asp:TextBox ID="passwordTextBox" runat="server" placeholder="Password" type="password"></asp:TextBox></p>
          <p class="remember_me">
           
          <asp:Label ID="accountLabel" runat="server" Text=""></asp:Label>
        </p>
         <p class="submit"><asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click"></asp:Button></p>
      </form>
        <p class="remember_me">
          
          <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
        </p>
    </div>
  </section>
</body>
</asp:Content>
