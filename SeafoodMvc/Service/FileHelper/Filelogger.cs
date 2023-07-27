using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Business.FileHelper
{
    public class Filelogger : IFileLogger
    {
        public bool GenerateFileLog(string content, string reasonPath)
        {
            bool check = false;

            lock(this)
            {
                DateTime time = DateTime.Now;
                var filePath = AppDomain.CurrentDomain.BaseDirectory + string.Format(@"{0}\{1}\{2}\{3}\{4}", "Log", time.Year, time.Month, time.Day, time.ToString("yyyy.MM.dd.HH.mm.ss") + "_" + reasonPath + ".txt");

                // Tạo thư mục nếu như thư mục chưa tồn tại
                var folder = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                // Tạo file nếu như file chưa tồn tại
                if (!File.Exists(filePath))
                    using (var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite)) fs.Close();
                
                string logContent = time.ToString() + " by " + reasonPath + "\n" + content + "\n\n\n";

                // Thực hiện ghi file
                using (var sw = new StreamWriter(filePath, true, Encoding.UTF8))
                {
                    sw.WriteLine(logContent);
                    check = true;
                }
            }

            return check;
        }
    }
}
