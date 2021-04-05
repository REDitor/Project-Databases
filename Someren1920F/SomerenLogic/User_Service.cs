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

        public User GetUserByLoginInfo(string username, string password)
        {
            PasswordWithSaltHasher hasher = new PasswordWithSaltHasher();
            User user = userDao.GetUserByUsername(username);
            HashWithSaltResult input = hasher.SaltedHashInput(password, user.Salt);

            if (!userDao.ValidateLoginInfo(input.Digest, user.Password))
            {
                throw new Exception("Username/Password incorrect!");
            }

            return user;
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

            return userDao.RegisterUser(user);
        }
    }
}
