<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="XtremeBlog.Home"%>
<%@ Import Namespace="XtremeBlog" %>
<%@ Import Namespace="XtremeBlog.BLL" %>
<%@ Import Namespace="XtremeBlog.Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH1" runat="server">
    <% 
       UserPostViewManager aUserPostViewManager =new UserPostViewManager();
      
       List<UserPostView> userPost = aUserPostViewManager.FindAllUserPost();
      
      
    %>
   <div id="content-inner">
       <% foreach (UserPostView post in userPost)
              
              {
                  if (post.PostStatus == "Published") 

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
                          int endpoint = parameterValue.Count()/2;
                          if (endpoint >= 150)
                          {
                              endpoint = 150;
                          }
                          parameterValue = parameterValue.Substring(0, endpoint) + "..";
                      %>
                    <p class="intro"><%= parameterValue %></p>
                    <%ComentManager aComentManager = new ComentManager();
                      List<Coment> coments = aComentManager.GetAllComentByPostId(post.PostId);
                    %>
                    <p class="end-story-links"><a href="#"><%= coments.Count%> Comments</a> | <a href="Details.aspx?postId=<%= post.PostId %>">Read on...</a></p>
                    
            
           </div>
           
  
                <%
              }
          }
      %>
       
    <div style="overflow: hidden;">
        <asp:Repeater ID="rptPaging" runat="server">
            <ItemTemplate>
                    <asp:LinkButton ID="btnPage"
        style="padding:8px; margin:2px; background:#ffa100; border:solid 1px #666; font:8pt tahoma;"
    CommandName="Page" CommandArgument="<%# Container.DataItem %>"
        runat="server" ForeColor="White" Font-Bold="True"><%# Container.DataItem %>
                    </asp:LinkButton>
           </ItemTemplate>
        </asp:Repeater>
   </div> 
    </div>
     
</asp:Content>

