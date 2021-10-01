using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.Shared.API;
using MyProject.WebFramework.Controllers;

namespace MyProject.EndUserApi.Controllers.v1
{
    [ApiVersion("1")]
    public class TestController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public ApiResult Get()
        {
            return true;
        }
    }
}