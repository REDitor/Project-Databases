using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenLogic;
using System.Security.Cryptography;
using PasswordEncryption;



namespace SomerenLogic
{
    public class User_Service
    {
        User_DAO userDao = new User_DAO();

        public bool UserExists(string username, string password)
        {
            User user = userDao.GetUserByUsername(username);
 
            PasswordWithSaltHasher hasher = new PasswordWithSaltHasher();

            HashWithSaltResult input = null;
            if (user != null)
            {
                input = hasher.SaltedHashInput(password, user.Salt);
            }
            else
            {
                throw new Exception("User not found!\nPlease check your input...");
            }
            
            if (input.Digest != user.Password)
            {
                throw new Exception("Username/Password incorrect!");
            }

            return true;
        }

        public User GetUserByUserName(string username)
        {
            User user = userDao.GetUserByUsername(username);
            return user;
        }

        public bool RegisterUser(User user)
        {
            PasswordWithSaltHasher hasher = new PasswordWithSaltHasher();
            HashWithSaltResult hashedpassword = hasher.HashWithSalt(user.Password, 64);
            user.Password = hashedpassword.Digest;
            user.Salt = hashedpassword.Salt;

            return userDao.RegisterUser(user);
        }
    }
}
