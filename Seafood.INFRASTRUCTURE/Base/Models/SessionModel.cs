using Newtonsoft.Json;
using Seafood.ARCHITECTURE.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Seafood.INFRASTRUCTURE.Base.Models
{
    public class SessionModel
    {
        public string AccessToken { get; set; }
        public DateTime ExpireTime { get; set; }

        public SessionModel()
        {
            AccessToken = "";
            ExpireTime = DateTime.Now.AddSeconds(ArchitectureContants.SESSION_EXPIRE_SECOND);
        }
        public SessionModel(string accessToken)
        {
            AccessToken = accessToken;
            ExpireTime = DateTime.Now.AddSeconds(ArchitectureContants.SESSION_EXPIRE_SECOND);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
