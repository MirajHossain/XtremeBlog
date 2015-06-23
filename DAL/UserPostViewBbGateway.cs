using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using XtremeBlog.Model;

namespace XtremeBlog.DAL
{
    public class UserPostViewBbGateway
    {
        static string conStr = ConfigurationManager.ConnectionStrings["XtremeBlog"].ConnectionString;
        public List<UserPostView> FindAllUerPost()
        {
            SqlConnection aSqlConnection = new SqlConnection(conStr);
            string query = "SELECT *FROM UserPostView WHERE post_status='Published' ORDER BY post_id DESC ";
            SqlCommand aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlConnection.Open();
            SqlDataReader aSqlDataReader = aSqlCommand.ExecuteReader();
            List<UserPostView> userPost = new List<UserPostView>();
            while (aSqlDataReader.Read())
            {
                UserPostView aUserPostView = new UserPostView();
                aUserPostView.PostId = Convert.ToInt32(aSqlDataReader["Post_id"]);
                aUserPostView.UserId = int.Parse(aSqlDataReader["user_id"].ToString());
                aUserPostView.Name = aSqlDataReader["name"].ToString();
                aUserPostView.Title = aSqlDataReader["title"].ToString();
                aUserPostView.DateTime = aSqlDataReader["date_time"].ToString();
                aUserPostView.Content = aSqlDataReader["content"].ToString();
                aUserPostView.PostStatus = aSqlDataReader["post_status"].ToString();
                userPost.Add(aUserPostView);
            }
            aSqlDataReader.Close();
            aSqlConnection.Close();
            return  userPost;
        }

        public List<UserPostView> FindUerPostById(int userId)
        {
            SqlConnection aSqlConnection = new SqlConnection(conStr);
            string query = "SELECT *FROM UserPostView WHERE user_id='" + userId + "'";
            SqlCommand aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlConnection.Open();
            SqlDataReader aSqlDataReader = aSqlCommand.ExecuteReader();
            List<UserPostView> userPost = new List<UserPostView>();
            while (aSqlDataReader.Read())
            {
                UserPostView aUserPostView = new UserPostView();
                aUserPostView.PostId = Convert.ToInt32(aSqlDataReader["Post_id"]);
                aUserPostView.UserId = int.Parse(aSqlDataReader["user_id"].ToString());
                aUserPostView.Name = aSqlDataReader["name"].ToString();
                aUserPostView.Title = aSqlDataReader["title"].ToString();
                aUserPostView.DateTime = aSqlDataReader["date_time"].ToString();
                aUserPostView.Content = aSqlDataReader["content"].ToString();
                aUserPostView.PostStatus = aSqlDataReader["post_status"].ToString();
                userPost.Add(aUserPostView);
            }
            aSqlDataReader.Close();
            aSqlConnection.Close();
            return userPost;
        }
    }
}