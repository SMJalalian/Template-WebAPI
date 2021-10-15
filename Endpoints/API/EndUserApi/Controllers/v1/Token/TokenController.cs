using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.Domain.Token.JWT;
using MyProject.Services.DomainServices.Identity;
using MyProject.Services.DomainServices.Token;
using MyProject.Shared.Exceptions;
using MyProject.WebFramework.Controllers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject.EndUserApi.Controllers.v1.Token
{
    public class TokenController : BaseController
    {
        private readonly IWebToken webToken;
        private readonly CustomSignInManager SignInManager;
        private readonly CustomUserManager UserManager;

        public TokenController(IWebToken jwtService,
            CustomSignInManager signInManager, CustomUserManager userManager)
        {
            webToken = jwtService;
            SignInManager = signInManager;
            UserManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public virtual async Task<IActionResult> GetToken([FromForm] TokenRequest tokenRequest, CancellationToken cancellationToken)
        {
            if (!tokenRequest.grant_type.Equals("password", StringComparison.OrdinalIgnoreCase))
                throw new Exception("OAuth flow is not password.");

            var user = await UserManager.FindByEmailAsync(tokenRequest.username);
            if (user == null)
                throw new BadRequestException("Token_Get_LoginFail");

            var result = await SignInManager.CheckPasswordSignInAsync(user, tokenRequest.password, true);
            if (!result.Succeeded)
                throw new BadRequestException("Token_Get_LoginFail");

            var jwt = await webToken.GenerateAsync(user);
            return new JsonResult(jwt);
        }

    }
}