using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class User_Service
    {
        User_DAO userDao = new User_DAO();

        public User GetUserByLoginInfo(string username, string password)
        {
            if (!userDao.ValidateLoginInfo(username, password))
            {
                throw new Exception("Username/Password incorrect!");
            }

            return userDao.GetUserByLoginInfo(username, password);
        }
    }
}
