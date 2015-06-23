<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="XtremeBlog.UI.Details" %>

<%@ Import Namespace="XtremeBlog" %>
<%@ Import Namespace="XtremeBlog.BLL" %>
<%@ Import Namespace="XtremeBlog.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">
    <%  ArticlePost anArticlePost = new ArticlePost();
        PostManager aPostManager = new PostManager();
        int postId = int.Parse(Request.QueryString["PostId"]);
        List<ArticlePost> posts = aPostManager.GetPostById(postId);
        ComentManager aComentManager = new ComentManager();
        List<Coment> coments = aComentManager.GetAllComentByPostId(postId);
       
    %>
    <div id="content-inner">
        <% foreach (ArticlePost post in posts)
           {
               User aUser = new User();
               UserManager aUserManager = new UserManager();
               User user = aUserManager.GetAllUserById(post.UserId);
                        
        %>
         <div class="content-full">
            <h2><%=post.Title %></h2>
            <h2>Writted By: <%=user.Name %></h2>
            <h3 class="dateline">Posted on: <%=post.DateTime %></h3>
            <p class="intro"><%=post.Content %>
            <p class="end-story-links"></p>
          </div>
       
        <%    
             }
        %>
       

         <div class="content">
            <h4>Write your Comment:<asp:Label ID="msg" runat="server"></asp:Label></h4>
            <form role="form" runat="server">
                <div class="form-group">
                    <asp:TextBox ID="commentTextBox" runat="server" Height="96px" Width="700px"></asp:TextBox>
                    <asp:Button ID="commentButton" runat="server" Text="Comment" OnClick="commentButton_Click" />
                </div>
            </form>

        </div>
        <br />
        <br />
        <hr />
        <% foreach (Coment coment in coments)
           {
               User aUser = new User();
               UserManager aUserManager = new UserManager();
               User user = aUserManager.GetAllUserById(coment.UseId);
        %>
        <div class="content">
            <a class="pull-left" href="#">

                <img class="media-object" src="../images/comment.jpg" alt="" width="64px" height="64px">
            </a>
            <div class="content">
                <h2>Author:<%=user.Name %></h2>
                <h3 class="dateline">Posted on:<%=coment.DateTime %></h3>
                <p class="intro"><%= coment.Description %></p>
                <p class="end-story-links"></p>
            </div>
        </div>

        <%
                   } %>
        <hr />

    </div>
</asp:Content>
