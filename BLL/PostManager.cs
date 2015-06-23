using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using XtremeBlog.DAL;
using XtremeBlog.Model;

namespace XtremeBlog.BLL
{
    public class PostManager
    {
        PostDbGateway aPostDbGateway = new PostDbGateway();
        public string Save(ArticlePost anArticlePost)
        {
           
           int insert= aPostDbGateway.Save(anArticlePost);
            if (insert > 0)
            {
                return "Article Saved to MyPost";
            }
            else
            {
                return "Article not saved please try Again";
            }

        }

        public List<ArticlePost> FindArticle()
        {
            return aPostDbGateway.FindArticle();
        }

        public List<ArticlePost> GetPostById(int postId)
        {
            return aPostDbGateway.GetPostById(postId);
        }


        public void MostView(int postId)
        {
            aPostDbGateway.MostView(postId);
        }

        public List<ArticlePost> MostViewArticle()
        {
           return aPostDbGateway.MostViewArticle();
        }

        public string SavePublish(ArticlePost anArticlePost)
        {
           int insert= aPostDbGateway.SavePublish(anArticlePost);
            if (insert > 0)
            {
                return "Article published Successfully!";
            }
            else
            {
                return "Not published";
            }
        }

        public string UpdatePost(int publishId)
        {
            int change= aPostDbGateway.UpdatePost(publishId);
            if (change>0)
            {
                return "Published Article Succesfully!";
            }
            else
            {
                return "fail to Publish Article";
            }
        }
    }
}