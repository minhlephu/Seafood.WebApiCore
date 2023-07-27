using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeafoodApp.Base;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Reflection;
using System.Globalization;
using Common.Base.ViewModel;
using Microsoft.CodeAnalysis.CSharp;
using SeafoodMVC.Controllers;
using Business.Service;
using Common.Base.ResponseModel;
using System.Security.Cryptography.Xml;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.Build.Logging;

namespace SeafoodApp.Controllers
{
    public class UserController : BaseController
    {
        private readonly HttpClient _client;

        public UserController()
        {
            _client = new HttpClient();
            //_client.BaseAddress = new Uri(ApplicationConstant.API_URL_BASE);
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<UserModel> userModels = new List<UserModel>();

            try
            {
                HttpResponseMessage httpResponseMessage = _client.GetAsync(Configuration.GetSection("ApiUrlBase").Value + ApplicationConstant.API_USER_GETALL).Result;

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string responseString = httpResponseMessage.Content.ReadAsStringAsync().Result;

                    // Chuyển đổi từ JSON sang đối tượng dynamic
                    dynamic jsonObj = JsonConvert.DeserializeObject(responseString);

                    // Lấy danh sách listUser từ đối tượng dynamic
                    List<dynamic> userList = jsonObj.data.listUser.ToObject<List<dynamic>>();

                    // Chuyển đổi danh sách dynamic thành danh sách UserModel
                    foreach (dynamic user in userList)
                    {
                        //var Id = Guid.Parse(user.id.Value);
                        //var Username = user.username.Value;
                        //var PasswordHash = user.passwordHash.Value;
                        //var Salt = user.salt.Value != null ? (int)user.salt.Value : 11;
                        //var DisplayName = user.displayName.Value;
                        //var Avarta = user.avarta.Value;
                        //var Birthday = user.birthday.Value;
                        //var Sex = user.salt.Value != null ? (int)user.sex.Value : 1;
                        //var Mobile = user.mobile.Value;
                        //var Email = user.email.Value;
                        //var Company = user.company.Value;
                        //var Role = user.role.Value;
                        //var IsAdminUser = user.isAdminUser.Value;
                        //var IsLocked = user.isLocked.Value;
                        //var Session = user.session.Value;
                        //var SessionId = user.sessionId.Value;
                        //var IsDeleted = user.isDeleted.Value;
                        //var DeletedAt = user.deletedAt.Value != null ? user.deletedAt.Value : (DateTime?)null;
                        //var DeletedBy = user.deletedBy.Value;
                        //var CreatedAt = user.createdAt.Value != null ? user.createdAt.Value : (DateTime?)null;
                        //var CreatedBy = user.createdBy.Value;
                        //var UpdatedAt = user.updatedAt.Value != null ? user.updatedAt.Value : (DateTime?)null;
                        //var UpdatedBy = user.updatedBy.Value;

                        UserModel userModel = new UserModel
                        {
                            Id = Guid.Parse(user.id.Value),
                            Username = user.username.Value,
                            Salt = user.salt.Value != null ? (int)user.salt.Value : 11,
                            DisplayName = user.displayName.Value,
                            Avarta = user.avarta.Value,
                            Birthday = user.birthday.Value,
                            Sex = user.salt.Value != null ? (int)user.sex.Value : 1,
                            Mobile = user.mobile.Value,
                            Email = user.email.Value,
                            Company = user.company.Value,
                            Role = user.role.Value,
                            IsAdminUser = user.isAdminUser.Value,
                            IsLocked = user.isLocked.Value,
                            Session = user.session.Value,
                            SessionId = user.sessionId.Value,
                            IsDeleted = user.isDeleted.Value,
                            DeletedAt = user.deletedAt.Value != null ? user.deletedAt.Value : (DateTime?)null,
                            DeletedBy = user.deletedBy.Value,
                            CreatedAt = user.createdAt.Value != null ? user.createdAt.Value : (DateTime?)null,
                            CreatedBy = user.createdBy.Value,
                            UpdatedAt = user.updatedAt.Value != null ? user.updatedAt.Value : (DateTime?)null,
                            UpdatedBy = user.updatedBy.Value
                        };

                        userModels.Add(userModel);
                    }

                    //JObject dataJson = JObject.Parse(responseString);
                    //var temp = dataJson["data"];
                    //var temp1 = temp["listUser"];
                    //var temp2 = temp1.ToList();

                    //users = JsonConvert.DeserializeObject<List<UserModel>>(data, new JsonSerializerOptions
                    //{
                    //    PropertyNameCaseInsensitive = true
                    //}); ;
                    //users = System.Text.Json.JsonSerializer.Deserialize<List<UserModel>>(responseString, new JsonSerializerOptions
                    //{
                    //    PropertyNameCaseInsensitive = true
                    //});
                }
            }
            catch (Exception ex)
            {
                FileLogger.GenerateFileLog(ex.Message, GetType().FullName);
            }

            return View(userModels);
        }
        public async Task<ActionResult> Create()
        {
            return PartialView("_CreateModal", new UserModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserCreateModel model)
        {
            try
            {
                var currentUser = Provider.GetCurrentUser();
                var body = new
                {
                    Username = model.Username,
                    Password = model.Password,
                    Role = model.Role,
                    Sex = model.Sex,
                    Mobile = model.Mobile,
                };

                var result = await Provider.PostAsync(ApplicationConstant.API_USER_CREATEUSER, body, currentUser.AccessToken);
                if (result.StatusCode != 200)
                {
                    NotyfService.Error(result.Message);
                }
            }
            catch (Exception ex)
            {
                NotyfService.Error("Create fail");
                FileLogger.GenerateFileLog(ex.Message, GetType().FullName);
            }

            return RedirectToAction("Index");
        }

        //public async Task<ActionResult> Edit(string id)
        //{
        //    try
        //    {
        //        var currentUser = _provider.GetCurrentUser();
        //        var result = await _provider.GetAsync(ApplicationConstant.API_USER_GETUSERBYID + string.Format($"id={id}"), currentUser.AccessToken);
        //        if (result != null && result.Data != null)
        //        {
        //            UserResponseModel model = null;
        //            try
        //            {
        //                model = JsonConvert.DeserializeObject<UserResponseModel>(result.Data["user"].ToString());
        //            }
        //            catch (Exception)
        //            {

        //            }

        //            if (model != null)
        //            {
        //                return PartialView("_EditModal", model);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        _notyf.Error("Edit fail");
        //    }
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public async Task<ActionResult> Edit(UserResponseModel model)
        {
            try
            {
                if (model.Id != null)
                {
                    var currentUser = Provider.GetCurrentUser();
                    var body = new
                    {
                        Username = model.Username,
                        Role = model.Role,
                        Sex = model.Sex,
                        Mobile = model.Mobile,
                    };
                    var result = await Provider.PutAsync(ApplicationConstant.API_USER_UPDATEUSER + string.Format($"?id={model.Id}"), body, currentUser.AccessToken);
                    if (result.StatusCode != 200)
                    {
                        NotyfService.Error(result.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                NotyfService.Error("Edit fail");
                FileLogger.GenerateFileLog(ex.Message, GetType().FullName);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(UserModel model)
        {
            try
            {
                var currentUser = Provider.GetCurrentUser();
                var result = await Provider.DeleteAsync(ApplicationConstant.API_USER_DELETEUSER + string.Format($"?id={model.Id}"), currentUser.AccessToken);
                if (result.StatusCode != 200)
                {
                    NotyfService.Error("Delete fail");
                }
                else
                {
                    NotyfService.Success("Delete success");
                }
            }
            catch (Exception ex)
            {
                NotyfService.Error("Delete fail");
                FileLogger.GenerateFileLog(ex.Message, GetType().FullName);
            }

            return RedirectToAction("Index");
        }
    }
}
