using AspNetCoreHero.ToastNotification.Abstractions;
using Business.FileHelper;
using Business.Service;
using Common.Base.ResponseModel;
using Common.Base.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Logging;
using Newtonsoft.Json;

namespace SeafoodMVC.Controllers
{
    public class BaseController : Controller
    {
        private readonly IProvider _provider;
        private readonly INotyfService _notyf;
        private readonly IFileLogger _fileLogger;
        private readonly IConfiguration _configuration;
        protected IProvider Provider => _provider ?? HttpContext.RequestServices.GetService<IProvider>();
        protected INotyfService NotyfService => _notyf ?? HttpContext.RequestServices.GetService<INotyfService>();
        protected IFileLogger FileLogger => _fileLogger ?? HttpContext.RequestServices.GetService<IFileLogger>();
        protected IConfiguration Configuration => _configuration ?? HttpContext.RequestServices.GetService<IConfiguration>();

        public UserResponseModel GetCurrentUser()
        {
            string sessionString = HttpContext.Session.GetString("User");
            UserResponseModel userParse = JsonConvert.DeserializeObject<UserResponseModel>(sessionString);
            return userParse;
        }
    }
}
