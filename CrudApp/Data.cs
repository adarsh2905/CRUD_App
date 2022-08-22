using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CrudApp
{
    public class Data
    {
        public static int CreateUser(string userName, int userAge, SqlConnection sqlConnection)
        {
            string insertQuery = "INSERT INTO DETAILS(user_Name, user_Age) VALUES('" + userName + "'," + userAge + "); select SCOPE_IDENTITY();";
            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
            int id = Convert.ToInt32(insertCommand.ExecuteScalar());
            return id;
           
        }

        public static List<User> RetrieveUser(SqlConnection sqlConnection)
        {
            List<User> users = new List<User>();
            string displayQuery = "SELECT * FROM Details";
            SqlCommand displayCommand = new SqlCommand(displayQuery, sqlConnection);
            SqlDataReader dataReader = displayCommand.ExecuteReader();
            while (dataReader.Read())
            {
                users.Add(new User
                {
                    UserId = Convert.ToInt32(dataReader["user_id"]),
                    UserName = dataReader["user_name"].ToString(),
                    UserAge = Convert.ToInt32(dataReader["user_age"])
                }) ;
            }
            dataReader.Close();
            return users;
        }

        public static bool UpdateUser(int age, int id, SqlConnection sqlConnection)
        {
            string updateQuery = "UPDATE Details SET user_age = " + age + "WHERE user_id = " + id + "";
            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
            int updatedId = updateCommand.ExecuteNonQuery();
            bool updated = false;
            if (updatedId > 0)
                updated = true;
            return updated;
        }

        public static bool DeleteUser(int id, SqlConnection sqlConnection)
        {
            string deleteQuery = "DELETE FROM DETAILS WHERE user_id = " + id;
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
            int deletedId = deleteCommand.ExecuteNonQuery();
            bool deleted = false;
            if (deletedId > 0)
                deleted = true;
            return deleted;
        }
    }
}
