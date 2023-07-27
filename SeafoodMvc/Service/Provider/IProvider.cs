using Common.Base.ResponseModel;
using Common.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface IProvider : IDisposable
    {
        Task<ResponseBase> GetAsync(string uri, string token = "");
        Task<ResponseBase> PostAsync(string uri, dynamic body, string token = "");
        Task<ResponseBase> PutAsync(string uriApi, dynamic body, string token = "");
        Task<ResponseBase> DeleteAsync(string uriApi, string token = "");
        Task<ResponseBase> PatchAsync(Uri uri);

        void SetCurrentUser(string value);
        UserResponseModel GetCurrentUser();
        SessionModel GetCurrentSession();
    }
}
