using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seafood.CORE.MediatR.UserFuction.AddUserHandler;
using Seafood.CORE.MediatR.UserFuction.DeleteUserHandler;
using Seafood.CORE.MediatR.UserFuction.GetUserByIdHanlder;
using Seafood.CORE.MediatR.UserFuction.GetUserHandler;
using Seafood.CORE.MediatR.UserFuction.Model;
using Seafood.CORE.MediatR.UserFuction.UpdateHandler;
using Seafood.INFRASTRUCTURE.Base.Attributes;

namespace Seafood.API.Controllers
{
    public class UserController : ApiControllerBase<UserController>
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        #region TestSession

        [HttpGet]
        [Route("testSession/tmp")]
        public async Task<ActionResult> Tmp()
        {
            return Ok("okokok " + DateTime.Now.ToString());
        }
        [HttpGet]
        [Route("testSession/tmp/get")]
        public async Task<ActionResult> TmpGet()
        {
            var tmp = new
            {
                SessionId = _contextAccessor.HttpContext.Session.Id.ToString(),
                SessionModel = _contextAccessor.HttpContext.Session.GetString("AccessTokenSession"),
                SessionTmp = _contextAccessor.HttpContext.Session.GetString("tmp"),
                Now = DateTime.Now.ToString(),
            };
            return Ok(tmp);
        }
        [HttpGet]
        [Route("testSession/tmp/set")]
        public async Task<ActionResult> TmpSet()
        {
            _contextAccessor.HttpContext.Session.SetString("tmp", DateTime.Now.AddSeconds(10).ToString());
            return Ok("Set ok " + DateTime.Now.ToString());
        }

        #endregion

        [HttpGet]
        [Route("[controller]/getall")]
        public async Task<ActionResult> GetAll()
        {
            var listUser = await Mediator.Send(new GetAllUserQuery());
            if (listUser != null)
            {
                ResponseModel.Add("listUser", listUser);
            }
            return StatusCode(ResponseModel.StatusCode, ResponseModel);
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<ActionResult> GetById([FromQuery] string id)
        {
            var user = await Mediator.Send(new GetUserByIdCommand(id));
            if (user != null)
            {
                ResponseModel.Add("user", user);
            }
            return StatusCode(ResponseModel.StatusCode, ResponseModel);
        }

        //[Authorize]
        [SessionAuthorize]
        //[RequiresClaim("Role", "superadmin")]
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
            return StatusCode(ResponseModel.StatusCode, ResponseModel);
        }

        [Authorize]
        [HttpPut]
        [Route("[controller]/update")]
        public async Task<ActionResult> Update(string id, [FromBody] UserMediatVM userMediatVM)
        {
            UserMediatUpdateModel userMediatUpdateModel = new UserMediatUpdateModel()
            {
                Id = Guid.Parse(id),
                Username = userMediatVM.Username,
                Role = userMediatVM.Role,
                Sex = userMediatVM.Sex,
                Mobile = userMediatVM.Mobile,
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
            return StatusCode(ResponseModel.StatusCode, ResponseModel);
        }

        [Authorize]
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
            return StatusCode(ResponseModel.StatusCode, ResponseModel);
        }
    }
}
