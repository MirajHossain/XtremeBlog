using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using XtremeBlog.Model;

namespace XtremeBlog.DAL
{
    public class UserDbGateway
    {
        string conStr = ConfigurationManager.ConnectionStrings["XtremeBlog"].ConnectionString;
        SqlConnection aSqlConnection;
        User aUser = new User();
        public UserDbGateway()
        {
            aSqlConnection = new SqlConnection(conStr);
        }

        private SqlCommand aSqlCommand;
        public int SaveUser(User aUser)
        {
           SqlConnection aSqlConnection = new SqlConnection(conStr);
          // string query = "INSERT INTO tbl_users VALUES('" + aUser.Name + "','" + aUser.Email + "','" + aUser.Password + "')";
            string query = "INSERT INTO tbl_users (name, email, password) VALUES (@name,@email,@password)";
            aSqlCommand = new SqlCommand(query,aSqlConnection);
            aSqlCommand.Parameters.AddWithValue("@name", aUser.Name);
            aSqlCommand.Parameters.AddWithValue("@email", aUser.Email);
            aSqlCommand.Parameters.AddWithValue("@password", aUser.Password);
            aSqlCommand.CommandType= CommandType.Text;
            
            aSqlConnection.Open();
            int affectedRows= aSqlCommand.ExecuteNonQuery();
            aSqlConnection.Close();
            return affectedRows;

        }

        public List<User> GetAllUser()
        {
            string query = "SELECT *FROM tbl_users";
            aSqlCommand = new SqlCommand(query,aSqlConnection);
            aSqlConnection.Open();
            SqlDataReader aSqlDataReader = aSqlCommand.ExecuteReader();
            List<User> users = new List<User>();
            while (aSqlDataReader.Read())
            {
                aUser = new User();
                aUser.UserId = int.Parse(aSqlDataReader["user_id"].ToString());
                aUser.Name = aSqlDataReader["name"].ToString();
                aUser.Email = aSqlDataReader["email"].ToString();
                aUser.Password = aSqlDataReader["password"].ToString();
                users.Add(aUser);
            }
            aSqlDataReader.Close();
            aSqlConnection.Close();
            return users;

        }

        public User GetAllUserById(int UserId)
        {

            string query = "SELECT * FROM tbl_users WHERE user_id='" + UserId + "'";
            SqlCommand sqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            User user = new User();
            while (sqlDataReader.Read())
            {
                user.UserId = int.Parse(sqlDataReader["user_id"].ToString());
                user.Name = sqlDataReader["name"].ToString();
                user.Email = sqlDataReader["email"].ToString();
                user.Password = sqlDataReader["password"].ToString();
               
            }
            aSqlConnection.Close();
            return user;
        }

       
    }
}