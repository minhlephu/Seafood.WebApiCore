using Newtonsoft.Json;
using Seafood.ARCHITECTURE.Constants;
using Seafood.INFRASTRUCTURE.Base.Models;

namespace Seafood.API.Middlewares
{
    public class SessionMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IHttpContextAccessor httpContextAccessor)
        {
            // Sau khi tìm hiểu và xử dụng { region TestSession } thì rút ra là session đã tự cấu hình refresh session rồi nên cái middleware này không cần thiết. trong backend web bằng ExpressJs refresh Session phải tự cấu hình, tham khảo project ProductionMove

            //if (httpContextAccessor.HttpContext.User.Identities.Any())
            //{
            //    if (httpContextAccessor.HttpContext.Session.GetString("AccessTokenSession") != null)
            //    {
            //        var session = JsonConvert.DeserializeObject<SessionModel>(httpContextAccessor.HttpContext.Session.GetString("AccessTokenSession"));
            //        if (session != null)
            //        {
            //            if (session.ExpireTime - DateTime.Now < TimeSpan.FromSeconds(ArchitectureContants.SESSION_EXPIRE_SECOND))
            //            {
            //                session.ExpireTime = DateTime.Now.AddSeconds(ArchitectureContants.SESSION_EXPIRE_SECOND);
            //                httpContextAccessor.HttpContext.Session.SetString("AccessTokenSession", session.ToString());
            //            }
            //        }
            //    }
            //}
            await _next(context);
        }
    }
}