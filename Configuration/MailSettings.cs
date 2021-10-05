using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Configuration
{
    public class MailSettings
    {
        public string ServerDNSName { get; set; }
        public string SmtpPort { get; set; }
        public string SenderName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
