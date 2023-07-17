using Domains.DTOs;
using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryServices.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> SignIn(SignInRequest request);

        Task<UserResponse> SignUp(SignUpRequest request);

        Task<User> GetUserToContext(Guid id);

        Task<UserResponse> GetUserById(Guid id);

        Task DeleteUser(Guid id);

        Task<bool> ExistsUserById(Guid id);

        Task<bool> ExistsUserByUsername(string username);

        Task<bool> ExistsUserByEmail(string email);
    }
}
