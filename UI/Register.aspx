<%@ Page Title="Register" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="XtremeBlog.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">

    <section class="container">
        <div class="login">
            <h1>Register Here</h1>
            <form id="login" runat="server">
                <p>
                    <asp:TextBox ID="nameTextBox" runat="server" placeholder="User Name" Text='<%# Bind("Name") %>'></asp:TextBox>
                </p>
                <p>
                    <asp:TextBox ID="emailTextBox" runat="server" placeholder="Email"></asp:TextBox>
                </p>
                <p>
                    <asp:TextBox ID="passwordTextBox" runat="server" placeholder="Password"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
                </p>

                <p class="submit">
                    <asp:Button ID="registerButton" runat="server" Text="Register" OnClick="registerButton_Click"></asp:Button>
                </p>
            </form>
        </div>
    </section>

</asp:Content>
