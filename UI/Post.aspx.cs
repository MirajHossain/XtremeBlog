using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XtremeBlog.BLL;
using XtremeBlog.DAL;
using XtremeBlog.Model;

namespace XtremeBlog
{
    public partial class Post : System.Web.UI.Page
    {
        ArticlePost anArticlePost = new ArticlePost();
        PostManager aPostManager = new PostManager();
        UserManager aUserManager = new UserManager();
        private int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null || Session["Email"] != null)
            {
                userId = Convert.ToInt32(Session["UserId"]);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (titleTextBox.Text == string.Empty || Request.Form["txtImagename1"] == string.Empty)
            {
                msgLabel.Text = "All fields are required";
            }
            else
            {
                anArticlePost.Title = titleTextBox.Text;
                anArticlePost.DateTime = DateTime.Now.ToString();
                anArticlePost.Content = Request.Form["txtImagename1"];
                anArticlePost.ViewCounter = 0;
                anArticlePost.UserId = userId;
                anArticlePost.PostStatus = "Saved";
                string msg = aPostManager.Save(anArticlePost);
                msgLabel.Text = msg;
                ClearText();
            }
           
        }

        protected void publishButton_Click(object sender, EventArgs e)
        {
            if (titleTextBox.Text == string.Empty || Request.Form["txtImagename1"] == string.Empty)
            {
                msgLabel.Text = "All fields are required";
            }
            else
            {
                anArticlePost.Title = titleTextBox.Text;
                anArticlePost.DateTime = DateTime.Now.ToString();
                anArticlePost.Content = Request.Form["txtImagename1"];
                anArticlePost.ViewCounter = 0;
                anArticlePost.UserId = userId;
                anArticlePost.PostStatus = "Published";
                string msg = aPostManager.SavePublish(anArticlePost);
                msgLabel.Text = msg;
                ClearText();
            }
           
           
        }

        protected void ClearText()
        {
            titleTextBox.Text = string.Empty;
        }
    }
}