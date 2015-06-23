using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using XtremeBlog.Model;

namespace XtremeBlog.DAL
{
    public class ComentDbGateway
    {
        static string conStr = ConfigurationManager.ConnectionStrings["XtremeBlog"].ConnectionString;
        public void Save(Coment aComent)
        {
            
            SqlConnection sqlConnection = new SqlConnection(conStr);
            string query = "INSERT INTO tbl_coment(description,date_time,post_id,user_id) VALUES('" + aComent.Description + "','" + aComent.DateTime + "','" + aComent.PostId + "','"+aComent.UseId+"')";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Coment> GetAllComentByPostId(int postId)
        {
            SqlConnection sqlConnection = new SqlConnection(conStr);
            string query = "SELECT *FROM tbl_coment WHERE post_id= '" + postId + "'";
            SqlCommand aSqlCommand = new SqlCommand(query,sqlConnection);
            sqlConnection.Open();
            SqlDataReader aSqlDataReader = aSqlCommand.ExecuteReader();
            List<Coment> coments = new List<Coment>();
            while (aSqlDataReader.Read())
            {
                Coment aComent = new Coment();
                aComent.Id = Convert.ToInt32(aSqlDataReader["Id"]);
                aComent.DateTime = aSqlDataReader["date_time"].ToString();
                aComent.Description = aSqlDataReader["description"].ToString();
                aComent.PostId = Convert.ToInt32(aSqlDataReader["post_id"]);
                aComent.UseId = Convert.ToInt32(aSqlDataReader["user_id"]);
                coments.Add(aComent);
            }
            aSqlDataReader.Close();
            sqlConnection.Close();
            return coments;
        }

        public Coment GetNofComment(int postId)
        {
            throw new NotImplementedException();
        }
    }
}