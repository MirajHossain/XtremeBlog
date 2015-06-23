<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="Publish.aspx.cs" Inherits="XtremeBlog.Publish" %>
<%@ Import Namespace="XtremeBlog.BLL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">
    <% 
        int publishId = int.Parse(Request.QueryString["postId"]);
        PostManager aPostManager = new PostManager();
        string msg= aPostManager.UpdatePost(publishId);
        Response.Write(msg);
     %>
     
</asp:Content>
