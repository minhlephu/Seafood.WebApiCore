using Domains.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryServices.Interfaces
{
    public interface IUserService
    {
        Task<SignInResponse> SignIn(SignInRequest request);

        Task<SignUpResponse> SignUp(SignUpRequest request);

        Task<UserResponse> GetUserById(Guid id);

        Task DeleteUser(Guid id);

        Task<bool> ExistsUserById(Guid id);

        Task<bool> ExistsUserByUsername(string username);

        Task<bool> ExistsUserByEmail(string email);
    }
}
