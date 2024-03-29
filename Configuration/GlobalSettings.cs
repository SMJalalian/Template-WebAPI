﻿namespace MyProject.Configuration
{
    public class GlobalSettings
    {

        public string LocalizationAPIServer { get; set; }


        public SQLSettings SQLSettings { get; set; }
        public SwaggerSettings SwaggerSettings { get; set; }
        public MailSettings MailSettings { get; set; }
        public JwtSettings JwtSettings { get; set; }

    }
}
