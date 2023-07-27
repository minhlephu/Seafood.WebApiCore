using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace Seafood.API.Middlewares
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;

        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IHttpContextAccessor httpContextAccessor)
        {
            await _next(context);

            // Lấy địa chỉ IP và User Agent
            string ipAddress = context.Connection.RemoteIpAddress.ToString();
            string userAgent = context.Request.Headers["User-Agent"];

            // Tạo đối tượng chứa thông tin
            var requestInfo = new
            {
                InfoRequest = new
                {
                    Method = context.Request.Method,
                    Host = context.Request.Host,
                    IpAddress = ipAddress,
                    UserAgent = userAgent
                }
            };

            // Chuyển đổi đối tượng thành chuỗi JSON
            string requestInfoJson = JsonConvert.SerializeObject(requestInfo);

            // Thiết lập phần thân của phản hồi
            context.Response.ContentType = "application/json";

            //string responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
            //context.Response.Body = new MemoryStream(Encoding.UTF8.GetBytes(requestInfoJson.ToString() + responseBody));

            await context.Response.WriteAsync(requestInfoJson);
        }
    }
}
