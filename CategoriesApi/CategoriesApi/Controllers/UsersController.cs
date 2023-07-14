using CategoriesApi.Interfaces;
using CategoryServices.Interfaces;
using Domains.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CategoriesApi.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtUtil _jwtUtil;

        public UsersController(IUserService userService, IJwtUtil jwtUtil)
        {
            _userService = userService;
            _jwtUtil = jwtUtil;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            var response = await _userService.SignIn(request);
            response.Token = _jwtUtil.GenerateJwtToken(response.Id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpRequest request)
        {
            var response = await _userService.SignUp(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var response = await _userService.GetUserById(id);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(Guid id)
        {
            if(!(await _userService.ExistsUserById(id)))
            {
                return NotFound();
            }
            return Ok(new { message = "Deleted success!" });
        }
    } 
}
