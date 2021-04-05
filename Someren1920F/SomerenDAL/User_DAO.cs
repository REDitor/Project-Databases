using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordEncryption;

namespace SomerenDAL
{
    public class User_DAO : Base
    {
        public List<User> GetAllUsers()
        {
            SqlCommand cmd = new SqlCommand("SELECT userId, username, password, roleId, salt " +
                                            "FROM [Users]", conn);

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
            SqlCommand cmd = new SqlCommand("SELECT userId, username, password, roleId, salt " +
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

        public User GetUserByUsername(string username)
        {
            SqlCommand cmd = new SqlCommand("SELECT userId, username, password, roleId, salt " +
                                            "FROM [Users] " +
                                            "Where username = @username", conn);

            OpenConnection();
            cmd.Parameters.AddWithValue("@username", username);
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

        private User ReadUser(SqlDataReader reader)
        {
            User user = new User()
            {
                UserID = (int)reader["userId"],
                Username = (string)reader["username"],
                Password = (string)reader["password"],
                roleId = (int)reader["roleId"],
                Salt = (string)reader["salt"]
            };
            return user;
        }

        public bool RegisterUser(User user)
        {

            SqlCommand cmd = new SqlCommand("INSERT INTO Users(userName, password, roleID, salt)" +
                "VALUES(@username, @password, @roleID, @salt)", conn);

            OpenConnection();
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@roleID", user.roleId);
            cmd.Parameters.AddWithValue("@salt", user.Salt);

            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                return true;
            }
            CloseConnection();

            return false;
        }
    }
}
