using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryServices.Interfaces
{
    public interface IUserRepository : GenericRepository<User>
    {        

        Task<User> GetByUsername(string username);        

        Task<bool> ExistsByUsername(string username);

        Task<bool> ExistsByEmail(string email);
    }
}
