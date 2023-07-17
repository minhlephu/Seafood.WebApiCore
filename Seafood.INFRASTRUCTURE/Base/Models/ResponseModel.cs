using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.INFRASTRUCTURE.Base.Models
{
    public class ResponseModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, object> Data { get; set; }

        public ResponseModel()
        {
            Success = true;
            StatusCode = 200;
            Message = string.Empty;
            Data = new Dictionary<string, object>();
        }

        public void Add(string key, object value)
        {
            if (value != null)
            {
                Data.Add(key, value);
            }
        }
    }
}
