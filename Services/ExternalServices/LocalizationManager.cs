using Microsoft.Extensions.Options;
using MyProject.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using MyProject.Shared.Enums;

namespace MyProject.Services.ExternalServices
{
    public class LocalizationManager
    {
        private readonly IOptionsSnapshot<GlobalSettings> _siteSettings;

        public LocalizationManager(IOptionsSnapshot<GlobalSettings> siteSettings)
        {
            _siteSettings = siteSettings;
        }

        public string IpToContinent(string clientIp)
        {
            try
            {
                string json = (new WebClient()).DownloadString(_siteSettings.Value.LocalizationAPIServer + clientIp);
                JObject obj = JObject.Parse(json);
                string result = obj["continent"].ToString();
                return result;
            }
            catch (Exception)
            {
                return ResultStatus.Unknown.ToString();
            }
        }
        public string IpToCountry(string clientIp)
        {
            try
            {
                string json = (new WebClient()).DownloadString(_siteSettings.Value.LocalizationAPIServer + clientIp);
                JObject obj = JObject.Parse(json);
                string result = obj["name"].ToString();
                return result;
            }
            catch (Exception)
            {
                return ResultStatus.Unknown.ToString();
            }
        }
        public string IpToCulture(string clientIp)
        {
            try
            {
                string json = (new WebClient()).DownloadString(_siteSettings.Value.LocalizationAPIServer + clientIp);
                JObject obj = JObject.Parse(json);
                string result = obj["languages_official"][0].ToString() + "-" + obj["alpha2"].ToString();
                return result;
            }
            catch (Exception)
            {
                return ResultStatus.Unknown.ToString();
            }
        }
        public string IpToCountryCode(string clientIp)
        {
            try
            {
                string json = (new WebClient()).DownloadString(_siteSettings.Value.LocalizationAPIServer + clientIp);
                JObject obj = JObject.Parse(json);
                string result = obj["country_code"].ToString();
                return result;
            }
            catch (Exception)
            {
                return ResultStatus.Unknown.ToString();
            }
        }
        public string IpToCurrenyCode(string clientIp)
        {
            try
            {
                string json = (new WebClient()).DownloadString(_siteSettings.Value.LocalizationAPIServer + clientIp);
                JObject obj = JObject.Parse(json);
                string result = obj["currency_code"].ToString();
                return result;
            }
            catch (Exception)
            {
                return ResultStatus.Unknown.ToString();
            }
        }
    }
}