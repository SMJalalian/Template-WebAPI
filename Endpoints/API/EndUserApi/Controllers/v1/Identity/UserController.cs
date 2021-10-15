using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Services.DomainServices.Identity;
using MyProject.Services.DomainServices.Messaging;
using MyProject.Services.DomainServices.Token;
using MyProject.Services.DTOs.Identity;
using MyProject.Shared.API;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject.EndUserApi.Controllers.v1.Identity
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/{Culture}/[controller]")]
    public class UserController : Controller
    {
        private readonly CustomUserManager _userManager;
        private readonly IWebToken _webToken;

        public UserController(CustomUserManager userManager,
            EmailManager emailManager,
            IWebToken webToken,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _webToken = webToken;
        }

        //**************************** [AllowAnonymous] ***************************

        [HttpPost("[Action]")]
        [AllowAnonymous]
        public async Task<ApiResult> Register([FromForm] UserDtoCreate dto, CancellationToken cancellationToken)
        {
            return await _userManager.CustomRegisterAsync(dto, cancellationToken);
        }

        //***************************** [Authorized] ******************************



    }
}
