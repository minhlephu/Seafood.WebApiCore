using SeafoodWpf.COMMON.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeafoodWpf.BUSINESS.Services
{
    public class UserService : IUserService
    {

        public bool IsExist(string username, string password)
        {
            //var passwordHash = DataProvider.Ins.DB.Users.Where(u => u.Username == username).FirstOrDefault()?.PasswordHash;
            //var isExist = passwordHash != null ? BCrypt.Net.BCrypt.Verify(password, passwordHash) : false;

            //return isExist;
            return true;
        }
    }
}
