<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="MyPost.aspx.cs" Inherits="XtremeBlog.MyPost" %>

<%@ Import Namespace="XtremeBlog.BLL" %>
<%@ Import Namespace="XtremeBlog.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">
    <% 
        int userId = Convert.ToInt32(Session["UserId"]);
        UserPostViewManager aUserPostViewManager = new UserPostViewManager();
        List<UserPostView> userPost = aUserPostViewManager.FindUserPostById(userId);

      
    %>
    <div id="content-inner">

        <% foreach (UserPostView post in userPost)
           {
               if (post.PostStatus == "Saved")
               { %>
        <div class="content-left">

            <%
                   string source = post.Content;
                   var reg = new Regex("src=(?:\"|\')?(?<imgSrc>[^>]*[^/].(?:jpg|bmp|gif|png))(?:\"|\')?");
                   var match = reg.Match(source);
                   if (match.Success)
                   {
                       var encod = match.Groups["imgSrc"].Value;
            %>
            <img src="<%=encod %>" alt="" style="width: 200px" height="170" />
            <%
                      }
                      else
                      {
            %>
            <img class="img-responsive" src="../images/default_blog_large.png" alt="" width="200" height="200" />
            <% 
                        }    
            %>
        </div>
        <div class="content-right">


            <h1 class="title"><%= post.Title %></h1>
            <h2>Author:<%= post.Name %></h2>
            <h3 class="dateline">Posted on:<%= post.DateTime %></h3>
            <%
                      string parameterValue = Regex.Replace(post.Content, @"<[^>]*>", String.Empty);
                      int endpoint = parameterValue.Count() / 2;
                      if (endpoint >= 150)
                      {
                          endpoint = 150;
                      }
                      parameterValue = parameterValue.Substring(0, endpoint) + "..";
            %>
            <p class="intro"><%= parameterValue %></p>

             
            <a href="Publish.aspx?postId=<%= post.PostId %>"><input type="submit" value="Publish" runat="server" /></a>
             

            <p class="end-story-links"></p>


        </div>


        <%
               }
           }
        %>
    </div>
</asp:Content>
