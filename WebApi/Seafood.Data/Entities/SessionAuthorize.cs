using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Data.Entities
{
    public class SessionAuthorize : BaseEntity
    {
        public string Username { get; set; }
        public string IpRequest { get; set; }
        public string SessionId { get; set; }
        public string Session { get; set; }
    }
}
