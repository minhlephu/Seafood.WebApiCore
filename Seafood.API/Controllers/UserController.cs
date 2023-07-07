using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seafood.CORE.MediatR.UserFuction.AddUserHandler;
using Seafood.CORE.MediatR.UserFuction.DeleteUserHandler;
using Seafood.CORE.MediatR.UserFuction.GetUserHandler;
using Seafood.CORE.MediatR.UserFuction.Model;
using Seafood.CORE.MediatR.UserFuction.UpdateHandler;
using Seafood.INFRASTRUCTURE.Base.Attributes;

namespace Seafood.API.Controllers
{
    public class UserController : ApiControllerBase<UserController>
    {
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

        [HttpPut]
        [Route("[controller]/update")]
        public async Task<ActionResult> Update(string id, [FromBody] UserMediatModel userMediatModel)
        {
            UserMediatUpdateModel userMediatUpdateModel = new UserMediatUpdateModel()
            {
                Id = Guid.Parse(id),
                Username = userMediatModel.Username,
                Password = userMediatModel.Password,
                Role = userMediatModel.Role,
            };
            var user = await Mediator.Send(new UpdateUserCommand(userMediatUpdateModel));
            if (user != null)
            {
                ResponseModel.Add("userUpdated", user);
            }
            else
            {
                ResponseModel.Message = "Update user fail";
            }
            return StatusCode(ResponseModel.Code, ResponseModel);
        }

        [HttpDelete]
        [Route("[controller]/delete")]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await Mediator.Send(new DeleteUserCommand() { Id = Guid.Parse(id) });
            if (user != null)
            {
                ResponseModel.Add("userDeleted", user);
            }
            else
            {
                ResponseModel.Message = "Delete user fail";
            }
            return StatusCode(ResponseModel.Code, ResponseModel);
        }
    }
}
