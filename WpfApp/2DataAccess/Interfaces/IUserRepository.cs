using DataAccess.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccess.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUserName(string username);
    }
}
