using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryServices.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> FindAll();

        Task<User> Save(User user);

        Task<User> FindById(Guid id);

        Task<User> FindByUsername(string username);

        Task Delete(Guid id);

        Task<bool> ExistsById(Guid id);

        Task<bool> ExistsByUsername(string username);

        Task<bool> ExistsByEmail(string email);
    }
}
