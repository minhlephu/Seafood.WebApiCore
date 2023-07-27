using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FileHelper
{
    public interface IFileLogger
    {
        public bool GenerateFileLog(string content, string reason);
    }
}
