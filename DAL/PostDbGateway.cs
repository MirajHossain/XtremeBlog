using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using XtremeBlog.BLL;
using XtremeBlog.Model;

namespace XtremeBlog.DAL
{
    public class PostDbGateway
    {
        static string conStr = ConfigurationManager.ConnectionStrings["XtremeBlog"].ConnectionString;
    
        public int Save(ArticlePost anArticlePost)
        {
            SqlConnection aSqlConnection = new SqlConnection(conStr);
            string query = "INSERT INTO tbl_post (title,date_time,content,viewCounter, user_id, post_status) VALUES (@title,@date_time,@content,@viewCounter,@user_id,@post_status)";
            SqlCommand aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlCommand.Parameters.AddWithValue("@title", anArticlePost.Title);
            aSqlCommand.Parameters.AddWithValue("@date_time", anArticlePost.DateTime);
            aSqlCommand.Parameters.AddWithValue("@content", anArticlePost.Content);
            aSqlCommand.Parameters.AddWithValue("@viewCounter", anArticlePost.ViewCounter);
            aSqlCommand.Parameters.AddWithValue("@user_id", anArticlePost.UserId);
            aSqlCommand.Parameters.AddWithValue("@post_status", anArticlePost.PostStatus);
            aSqlCommand.CommandType = CommandType.Text;
            aSqlConnection.Open();
            int affectedRows= aSqlCommand.ExecuteNonQuery();
            aSqlConnection.Close();
            return affectedRows;
        }

        public List<ArticlePost> FindArticle()
        {
            SqlConnection aSqlConnection = new SqlConnection(conStr);
            string query = "SELECT *FROM UserPostView";
            SqlCommand aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlConnection.Open();
            SqlDataReader aSqlDataReader = aSqlCommand.ExecuteReader();
            List<ArticlePost> posts = new List<ArticlePost>();
            while (aSqlDataReader.Read())
            {
                ArticlePost anArticlePost = new ArticlePost();
                anArticlePost.PostId = int.Parse(aSqlDataReader["post_id"].ToString());
                anArticlePost.Title = aSqlDataReader["title"].ToString();
                anArticlePost.DateTime = aSqlDataReader["date_time"].ToString();
                anArticlePost.Content = aSqlDataReader["content"].ToString();
                anArticlePost.PostStatus = aSqlDataReader["post_status"].ToString();
                posts.Add(anArticlePost);
            }
            aSqlDataReader.Close();
            aSqlConnection.Close();
            return posts;
        }

  
        public List<ArticlePost> GetPostById(int postId)
        {
            
            SqlConnection aSqlConnection = new SqlConnection(conStr);
            string query = "SELECT *FROM tbl_post  Where Post_id= '" + postId + "'";
            SqlCommand aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlConnection.Open();
            SqlDataReader aSqlDataReader = aSqlCommand.ExecuteReader();
            List<ArticlePost> posts = new List<ArticlePost>();
            while (aSqlDataReader.Read())
            {
                ArticlePost anArticlePost = new ArticlePost();
                anArticlePost.PostId = Convert.ToInt32(aSqlDataReader["Post_id"]);
                anArticlePost.Title = aSqlDataReader["title"].ToString();
                anArticlePost.DateTime = aSqlDataReader["date_time"].ToString();
                anArticlePost.Content = aSqlDataReader["content"].ToString();
                anArticlePost.UserId = Convert.ToInt32(aSqlDataReader["user_id"]);
                anArticlePost.PostStatus = aSqlDataReader["post_status"].ToString();
                posts.Add(anArticlePost);
               
            }
            aSqlDataReader.Close();
            aSqlConnection.Close();
            return posts;
        }
        
        public void MostView(int postId)
        {
            
            
            SqlConnection aSqlConnection = new SqlConnection(conStr);
            string query = "UPDATE tbl_post SET viewCounter=viewCounter+1 WHERE post_id = '" + postId + "'";
            SqlCommand aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlConnection.Open();
            int affectedRows = aSqlCommand.ExecuteNonQuery();
            aSqlConnection.Close();
            
        }

        public List<ArticlePost> MostViewArticle()
        {
            SqlConnection aSqlConnection = new SqlConnection(conStr);
            string query = "SELECT top 5 * FROM tbl_post ORDER BY viewCounter DESC ";
            SqlCommand aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlConnection.Open();
            SqlDataReader aSqlDataReader = aSqlCommand.ExecuteReader();
            List<ArticlePost> mostView = new List<ArticlePost>();
            while (aSqlDataReader.Read())
            {
                ArticlePost anArticlePost = new ArticlePost();
                anArticlePost.PostId = int.Parse(aSqlDataReader["post_id"].ToString());
                anArticlePost.Title = aSqlDataReader["title"].ToString();
                anArticlePost.PostStatus = aSqlDataReader["post_status"].ToString();
                mostView.Add(anArticlePost);

            }
            aSqlDataReader.Close();
            aSqlConnection.Close();
            return mostView;
        }

        public int SavePublish(ArticlePost anArticlePost)
        {
            SqlConnection aSqlConnection = new SqlConnection(conStr);
            string query = "INSERT INTO tbl_post (title,date_time,content,viewCounter,user_id,post_status) VALUES (@title,@date_time,@content,@viewCounter,@user_id,@post_status)";
            SqlCommand aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlCommand.Parameters.AddWithValue("@title", anArticlePost.Title);
            aSqlCommand.Parameters.AddWithValue("@date_time", anArticlePost.DateTime);
            aSqlCommand.Parameters.AddWithValue("@content", anArticlePost.Content);
            aSqlCommand.Parameters.AddWithValue("@viewCounter", anArticlePost.ViewCounter );
            aSqlCommand.Parameters.AddWithValue("@user_id", anArticlePost.UserId);
            aSqlCommand.Parameters.AddWithValue("@post_status", anArticlePost.PostStatus);
            aSqlCommand.CommandType = CommandType.Text;
            aSqlConnection.Open();
            int affectedRows = aSqlCommand.ExecuteNonQuery();
            aSqlConnection.Close();
            return affectedRows;
        }

        public int UpdatePost(int publishId)
        {
            SqlConnection aSqlConnection = new SqlConnection(conStr);
            string query = "UPDATE tbl_post SET post_status='Published' WHERE post_id = '" + publishId + "'";
            SqlCommand aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlConnection.Open();
            int affectedRows = aSqlCommand.ExecuteNonQuery();
            aSqlConnection.Close();
            return affectedRows;

        }
    }
}