using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeafoodWpf.BUSINESS.Services
{
    public interface IUserService
    {
        bool IsExist (string username, string password);
    }
}
