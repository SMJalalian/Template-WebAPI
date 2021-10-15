using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyProject.Domain.Identity;

namespace MyProject.Services.DomainServices.Identity
{
    public class CustomSignInManager : SignInManager<User>
    {
        public CustomSignInManager(
            UserManager<User> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<User> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<User>> logger,
            IAuthenticationSchemeProvider schemeProvider,
            IUserConfirmation<User> confirmation
            )
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemeProvider,confirmation)
        {

        }
    }
}
