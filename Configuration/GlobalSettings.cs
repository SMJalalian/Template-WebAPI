using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Configuration
{
    public class GlobalSettings
    {

        public string LocalizationAPIServer { get; set; }

        public SQLSettings SQLSettings { get; set; }
        public SwaggerSettings SwaggerSettings { get; set; }


    }
}
