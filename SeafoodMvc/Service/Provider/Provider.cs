using Common.Base.ResponseModel;
using Common.Base.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using SeafoodApp.Base;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Business.FileHelper;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Business.Service
{
    public class Provider : IProvider
    {
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IFileLogger _fileLogger;
        private readonly IConfiguration _configuration;

        public Provider(IHttpContextAccessor httpContextAccessor, IFileLogger fileLogger, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;

            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Local,
                NullValueHandling = NullValueHandling.Ignore
            };
            _serializerSettings.Converters.Add(new StringEnumConverter());
            _fileLogger = fileLogger;
            _configuration = configuration;
        }

        public Task<ResponseBase> DeleteAsync(Uri uri)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public async Task<ResponseBase> GetAsync(string uri, string token = "")
        {
            try
            {
                Uri uriApi = new Uri(_configuration.GetSection("ApiUrlBase").Value + uri);
                using (HttpClient _httpClient = new HttpClient())
                {
                    //_httpClient.BaseAddress = new Uri(ApplicationConstant.API_URL_BASE);
                    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var jsonResult = await _httpClient.GetAsync($@"{uriApi}").Result.Content.ReadAsStringAsync();
                    if (jsonResult != null && _serializerSettings != null)
                    {
                        return JsonConvert.DeserializeObject<ResponseBase>(jsonResult, _serializerSettings);
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                _fileLogger.GenerateFileLog(ex.Message, GetType().FullName);
                return null;
            }
        }

        public Task<ResponseBase> PatchAsync(Uri uri)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseBase> PostAsync(string uri, dynamic body, string token="")
        {
            try
            {
                Uri uriApi = new Uri(_configuration.GetSection("ApiUrlBase").Value + uri);


                using (HttpClient _httpClient = new HttpClient())
                {
                    //_httpClient.BaseAddress = new Uri("http://10.1.34.98:1234/");
                    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}"); var bodyString = JsonConvert.SerializeObject(body);
                    var content = new StringContent(bodyString, Encoding.UTF8, "application/json");
                    var jsonResult = _httpClient.PostAsync($@"{uriApi}", content).Result.Content.ReadAsStringAsync().Result;

                    if (jsonResult != null && _serializerSettings != null)
                    {
                        var tmp = JsonConvert.DeserializeObject<ResponseBase>(jsonResult, _serializerSettings);
                        return tmp;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                _fileLogger.GenerateFileLog(ex.Message, GetType().FullName);
                return null;
            }
        }

        public async Task<ResponseBase> PutAsync(string uriApi, dynamic body, string token = "")
        {
            try
            {
                Uri uri = new Uri(_configuration.GetSection("ApiUrlBase").Value + uriApi);

                using (HttpClient _httpClient = new HttpClient())
                {
                    //_httpClient.BaseAddress = new Uri(ApplicationConstant.API_URL_BASE);
                    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var bodyString = JsonConvert.SerializeObject(body);
                    var content = new StringContent(bodyString, Encoding.UTF8, "application/json");
                    var jsonResult = _httpClient.PutAsync($@"{uri}", content).Result.Content.ReadAsStringAsync().Result;

                    if (jsonResult != null && _serializerSettings != null)
                    {
                        return JsonConvert.DeserializeObject<ResponseBase>(jsonResult, _serializerSettings);
                    }
                    else
                    {
                        return null;
                    }

                }


            }
            catch (Exception ex)
            {
                _fileLogger.GenerateFileLog(ex.Message, GetType().FullName);
                return null;
            }
        }
        public async Task<ResponseBase> DeleteAsync(string uriApi, string token = "")
        {
            try
            {
                Uri uri = new Uri(_configuration.GetSection("ApiUrlBase").Value + uriApi);

                using (HttpClient _httpClient = new HttpClient())
                {
                    //_httpClient.BaseAddress = new Uri(ApplicationConstant.API_URL_BASE);
                    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    var jsonResult = _httpClient.DeleteAsync($@"{uri}").Result.Content.ReadAsStringAsync().Result;

                    if (jsonResult != null && _serializerSettings != null)
                    {
                        return JsonConvert.DeserializeObject<ResponseBase>(jsonResult, _serializerSettings);
                    }
                    else
                    {
                        return null;
                    }
                }


            }
            catch (Exception ex)
            {
                _fileLogger.GenerateFileLog(ex.Message, GetType().FullName);
                return null;
            }
        }
        public void SetCurrentUser(string value)
        {
            _httpContextAccessor.HttpContext.Session.SetString("User", value);
            _httpContextAccessor.HttpContext.Session.SetString("SessionTime", DateTime.Now.ToString());
        }

        public UserResponseModel GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext.Session.GetString("User");
            if (user != null)
            {
                return JsonConvert.DeserializeObject<UserResponseModel>(user);
            }

            return null;
        }

        public SessionModel GetCurrentSession()
        {
            var session = new SessionModel();
            var user = _httpContextAccessor.HttpContext.Session.GetString("User");
            if (user != null)
            {
                session.User = JsonConvert.DeserializeObject<UserResponseModel>(user);
            }
            var sessionTime = _httpContextAccessor.HttpContext.Session.GetString("SessionTime");
            if (sessionTime != null)
            {
                session.Time = JsonConvert.DeserializeObject<DateTime>(sessionTime);
            }

            return session;
        }
    }
}
