using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XtremeBlog.BLL;
using XtremeBlog.Model;

namespace XtremeBlog.UI
{
    public partial class Details : System.Web.UI.Page
    {
        ArticlePost articlePost = new ArticlePost();
        PostManager aPostManager = new PostManager();
        UserManager aUserManager = new UserManager();
        private int userId;
        private int postId;
        protected void Page_Load(object sender, EventArgs e)
        {
            postId = int.Parse(Request.QueryString["postId"]);
            List<ArticlePost> posts = aPostManager.GetPostById(postId);
            foreach (ArticlePost post in posts)
            {
                userId = post.UserId;
            }
            aPostManager.MostView(postId);
        }

        protected void commentButton_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null || Session["Email"] != null)
            { 
              
            Coment aComent = new Coment();
            ComentManager aComentManager = new ComentManager();
            aComent.Description = commentTextBox.Text;
            aComent.DateTime = DateTime.Now.ToString();
            aComent.PostId = postId;
            aComent.UseId = userId;
            aComentManager.Save(aComent);
            aUserManager.GetAllUserById(aComent.UseId);
            }
            else
            {
               
                msg.Text = "By Login first please!";
                 
            }

        }
    }
}