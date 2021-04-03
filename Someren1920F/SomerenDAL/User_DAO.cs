using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class User_DAO : Base
    {
        public List<User> GetAllUsers()
        {
            SqlCommand cmd = new SqlCommand("SELECT userId, username, password, roleId " +
                                            "FROM dbo.Users", conn);

            OpenConnection();

            SqlDataReader reader = cmd.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                User user = ReadUser(reader);
                users.Add(user);
            }
            CloseConnection();
            reader.Close();

            return users;
        }

        public User GetUserByLoginInfo(string username, string password)
        {
            SqlCommand cmd = new SqlCommand("SELECT userId, username, password, roleId " +
                                            "FROM [Users] " +
                                            "WHERE username=@username " +
                                            "AND password=@password", conn);

            OpenConnection();
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataReader reader = cmd.ExecuteReader();

            User user = null;
            if (reader.Read())
            {
                user = ReadUser(reader);
            }
            reader.Close();
            CloseConnection();

            return user;
        }

        public bool ValidateLoginInfo(string username, string password)
        {
            List<User> users = GetAllUsers();

            foreach (User user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return true;
                }
            }

            return false;
        }

        private User ReadUser(SqlDataReader reader)
        {
            User user = new User()
            {
                UserID = (int)reader["userId"],
                Username = (string)reader["username"],
                Password = (string)reader["password"],
                roleId = (int)reader["roleId"]
            };
            return user;
        }

        //public List<string> GetAllUsernames()
        //{

        //    SqlCommand cmd = new SqlCommand("SELECT username " +
        //                                    "FROM [Users] ", conn);

        //    OpenConnection();
        //    SqlDataReader reader = cmd.ExecuteReader();

        //    List<string> usernames = new List<string>();
        //    User user = null;
        //    while (reader.Read())
        //    {
        //        user = ReadUser(reader);
        //        user.Username = (string)reader["username"];
        //        usernames.Add(user.Username);
        //    }

        //    return usernames;
        //}

        //private List<User> ReadTables(DataTable dataTable)
        //{
        //    List<User> users = new List<User>();

        //    foreach (DataRow dr in dataTable.Rows)
        //    {
        //        User user = new User()
        //        {
        //            UserID = (int)dr["userId"],
        //            Username = (string)dr["username"],
        //            Password = (string)dr["password"],
        //        };
        //        users.Add(user);
        //    }
        //    return users;
        //}


    }
}
