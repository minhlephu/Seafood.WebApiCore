using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Seafood.CORE.MediatR.AuthenticationFunction.LoginHandler;
using Seafood.INFRASTRUCTURE.Base.Models;

namespace Seafood.API.Controllers
{
    public class AuthenticationController : ApiControllerBase<AuthenticationController>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("[controller]/login")]
        public async Task<ActionResult> Login([FromBody] LoginMediatModel loginMediatModel)
        {
            var user = await Mediator.Send(new LoginCommand(loginMediatModel));
            if (user != null)
            {
                SessionModel sessionModel = new SessionModel(user.AccessToken);
                _httpContextAccessor.HttpContext.Session.SetString("AccessTokenSession", sessionModel.ToString());

                ResponseModel.Add("user", user);
            }
            else
            {
                ResponseModel.Message = "User not found";
            }
            return Ok(ResponseModel);
        }
    }
}