using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyProject.Domain.Identity;
using MyProject.Services.DomainServices.Messaging;
using MyProject.Services.DTOs.Identity;
using MyProject.Services.DTOs.Messaging;
using MyProject.Shared.API;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject.Services.DomainServices.Identity
{
    public class CustomUserManager : UserManager<User>
    {
        private readonly EmailManager _emailManager;

        public CustomUserManager(
            IUserStore<User> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<User>> logger,
            EmailManager customEmailManager)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _emailManager = customEmailManager;
        }

        //******************* UnAuthorized Access ***********************

        public async Task<ApiResult> CustomConfirmEmailAsync(string userId, string code, CancellationToken cancellationToken)
        {
            try
            {
                var user = await FindByIdAsync(userId);
                if (user == null)
                    return new ApiResult(false, HttpStatusCode.NotFound, $"Unable to load user with ID '{userId}'.");

                code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
                var result = await ConfirmEmailAsync(user, code);
                if (result.Succeeded)
                    return new ApiResult(true, HttpStatusCode.OK, "Thank you for confirming your email.");
                else
                    return new ApiResult(false, HttpStatusCode.OK, "Error on confirming your email.");
            }
            catch (Exception)
            {
                throw ApiResult.ThrowServerError();
            }

        }

        public async Task<ApiResult> CustomForgotPasswordAsync(string userEmail, CancellationToken cancellationToken)
        {
            try
            {
                if (userEmail != null)
                {
                    var user = await FindByEmailAsync(userEmail);

                    if (user == null)
                        return new ApiResult(false, HttpStatusCode.NotFound, "Unable to find user information.");
                    else if (!(await IsEmailConfirmedAsync(user)))
                        return new ApiResult(false, HttpStatusCode.Conflict, "User account has not been confirmed.");

                    var code = await GeneratePasswordResetTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = "https://Api.Barad.com/api/v1/en-US/User/ResetPassword?code=" + code;

                    EmailDto sendEmailDto = new()
                    {
                        SenderName = "Password Recovery",
                        Subject = "Reset your account password",
                        RecieverEmail = userEmail,
                        Body = $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>."
                    };

                    _emailManager.SendEmail(sendEmailDto, cancellationToken);
                    return new ApiResult(true, HttpStatusCode.OK, "User created a new account with password.");
                }
                else
                {
                    return new ApiResult(false, HttpStatusCode.BadRequest, "Email address files is empty");
                }
            }
            catch (Exception)
            {
                throw ApiResult.ThrowServerError();
            }
        }

        public async Task<ApiResult> CustomResetPasswordAsync(UserDtoResetPassword dto, CancellationToken cancellationToken)
        {
            try
            {
                var user = await FindByEmailAsync(dto.Email);
                if (user == null)
                {
                    return new ApiResult(false, HttpStatusCode.NotFound, "Unable to load user.");
                }

                var result = await ResetPasswordAsync(user, dto.Code, dto.Password);
                if (result.Succeeded)
                {
                    return new ApiResult(true, HttpStatusCode.OK, "Password has been reset successfully.");
                }
                else
                {
                    string msg = "";
                    foreach (var error in result.Errors)
                    {
                        msg = error.Description + "\n";
                    }
                    return new ApiResult(false, HttpStatusCode.Conflict, msg);
                }
            }
            catch (Exception)
            {
                throw ApiResult.ThrowServerError();
            }
        }

        public async Task<ApiResult> CustomRegisterAsync(UserDtoCreate dto, CancellationToken cancellationToken)
        {
            try
            {
                User user = new() { UserName = dto.Email, Email = dto.Email };

                var result = await CreateAsync(user, dto.Password);

                if (result.Succeeded)
                {
                    await AddToRoleAsync(user, "User");

                    var createdUser = await FindByEmailAsync(dto.Email);
                    var code = await GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    var callbackUrl = "https://Api.Barad.com/api/v1/en-US/User/ConfirmEmail?userId=" + createdUser.Id + "&code=" + code;
                    EmailDto sendEmailDto = new()
                    {
                        SenderName = "Confirm Registration",
                        Subject = "Please confirm your account",
                        RecieverEmail = dto.Email,
                        Body = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>."
                    };

                    _emailManager.SendEmail(sendEmailDto, cancellationToken);
                    return new ApiResult(true, HttpStatusCode.OK, "User created as a new account with password.");
                }
                else
                {
                    string msg = "";
                    foreach (var error in result.Errors)
                    {
                        msg = error.Description + "\n";
                    }
                    return new ApiResult(false, HttpStatusCode.Conflict, msg);
                }
            }
            catch (Exception)
            {
                throw ApiResult.ThrowServerError();
            }
        }

        //******************* Authorized Access ***********************

        public virtual async Task<ApiResult> CustomAssignRoleAsync(UserDtoAssignRole dto, CancellationToken cancellationToken)
        {
            try
            {
                var user = await FindByIdAsync(dto.UserId.ToString());
                var result = await AddToRoleAsync(user, dto.RoleName);
                if (result.Succeeded)
                    return ApiResult.OkCreate("Role added to user successfully.");
                else
                {
                    string msg = "";
                    foreach (var error in result.Errors)
                    {
                        msg = error.Description + "\n";
                    }
                    return new ApiResult(false, HttpStatusCode.Conflict, msg);
                }
            }
            catch (Exception)
            {
                throw ApiResult.ThrowServerError();
            }
        }

        public async Task<ApiResult> CustomChangePasswordAsync(UserDtoChangePassword dto, string email, CancellationToken cancellationToken)
        {
            try
            {
                var user = await FindByEmailAsync(email);
                if (user == null)
                {
                    return new ApiResult(false, HttpStatusCode.NotFound, "Unable to find user information.");
                }

                var addPasswordResult = await ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
                if (!addPasswordResult.Succeeded)
                {
                    string msg = "";
                    foreach (var error in addPasswordResult.Errors)
                    {
                        msg = error.Description + "\n";
                    }
                    return new ApiResult(false, HttpStatusCode.Conflict, msg);
                }
                return new ApiResult(true, HttpStatusCode.OK, "Password updated successfully.");
            }
            catch (Exception)
            {
                throw ApiResult.ThrowServerError();
            }
        }
    }
}
