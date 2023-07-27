using Common.Base.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Base.ViewModel
{
    public class SessionModel
    {
        public UserResponseModel User { get; set; }
        public DateTime Time { get; set; }
    }
}
