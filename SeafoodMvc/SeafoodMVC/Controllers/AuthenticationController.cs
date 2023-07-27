using Business.Service;
using Common.Base.ResponseModel;
using Common.Base.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Newtonsoft.Json;
using SeafoodApp.Base;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.Build.Logging;

namespace SeafoodMVC.Controllers
{
    public class AuthenticationController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Login(string username, string password)
        {
            if (username != null && password != null)
            {
                var body = new
                {
                    Username = username,
                    Password = password
                };
                var result = await Provider.PostAsync(ApplicationConstant.API_AUTHENTICATION_LOGIN, body);
                if (result != null && (result.StatusCode == 200 || result.StatusCode == 201) && result.Data.ContainsKey("user"))
                {
                    Provider.SetCurrentUser(JsonConvert.SerializeObject(result.Data["user"]));


                    return RedirectToAction("Index", "User");
                }
                else if (result != null)
                {
                    NotyfService.Error("Username and Password not found");
                }
                else
                {
                    NotyfService.Error("Can't connect to server");
                }
            }
            else
            {
                NotyfService.Warning("Username and Password must be have value!");
            }
            return RedirectToAction("Index");
        }
    }
}
