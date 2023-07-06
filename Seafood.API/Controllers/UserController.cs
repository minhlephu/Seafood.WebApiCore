using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seafood.CORE.MediatR.UserFuction.AddUserHandler;
using Seafood.CORE.MediatR.UserFuction.GetUserHandler;
using Seafood.INFRASTRUCTURE.Base.Attributes;

namespace Seafood.API.Controllers
{
    public class UserController : ApiControllerBase<UserController>
    {
        [Authorize]
        [HttpGet]
        [Route("[controller]/getall")]
        public async Task<ActionResult> GetAll()
        {
            var listUser = await Mediator.Send(new GetAllUserQuery());
            if (listUser != null)
            {
                ResponseModel.Add("total", listUser.Count());
                ResponseModel.Add("listUser", listUser);
            }
            return StatusCode(ResponseModel.Code, ResponseModel);
        }

        [Authorize]
        [RequiresClaim("Role", "superadmin")]
        [HttpPost]
        [Route("[controller]/add")]
        public async Task<ActionResult> Add([FromBody] UserMediatModel userMediatModel)
        {
            var user = await Mediator.Send(new AddUserCommand(userMediatModel));
            if (user != null)
            {
                ResponseModel.Add("userAdded", user);
            }
            else
            {
                ResponseModel.Message = "Add new user fail";
            }
            return StatusCode(ResponseModel.Code, ResponseModel);
        }
    }
}
