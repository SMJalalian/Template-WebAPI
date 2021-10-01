using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Configuration
{
    public class SwaggerSettings
    {
        public string SecurityScheme { get; set; }
        public string ProductionTokenUrl { get; set; }
        public string StagingTokenUrl { get; set; }
        public string DevelopmentTokenUrl { get; set; }
    }
}
