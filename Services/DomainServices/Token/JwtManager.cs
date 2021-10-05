using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyProject.Configuration;
using MyProject.Domain.Identity;
using MyProject.Domain.Token.JWT;
using MyProject.Services.DomainServices.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.DomainServices.Token
{
    public class JwtManager : IJwtManager
    {
        private readonly GlobalSettings _siteSettings;
        private readonly CustomUserManager _userManager;

        public JwtManager(IOptionsSnapshot<GlobalSettings> siteSettings, CustomUserManager userManager)
        {
            _userManager = userManager;
            _siteSettings = siteSettings.Value;
        }

        public async Task<AccessToken> GenerateAsync(User user)
        {
            var secretKey = Encoding.UTF8.GetBytes(_siteSettings.JwtSettings.SecretKey);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            //var encryptionkey = Encoding.UTF8.GetBytes(_siteSettings.JwtSettings.Encryptkey);
            //var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var claims = await GetClaimsAsync(user);
            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = _siteSettings.JwtSettings.Issuer,
                Audience = _siteSettings.JwtSettings.Audience,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(_siteSettings.JwtSettings.NotBeforeMinutes),
                Expires = DateTime.Now.AddMinutes(_siteSettings.JwtSettings.ExpirationMinutes),
                SigningCredentials = signingCredentials,
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateJwtSecurityToken(descriptor);

            return new AccessToken(securityToken,_siteSettings.JwtSettings.TokenType);
        }

        public string ReadToken(string jwtToken)
        {

            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtOutput = string.Empty;

            // Check Token Format
            if (!jwtHandler.CanReadToken(jwtToken)) throw new Exception("The token doesn't seem to be in a proper JWT format.");

            var token = jwtHandler.ReadJwtToken(jwtToken);

            //// Re-serialize the Token Headers to just Key and Values
            //var jwtHeader = JsonConvert.SerializeObject(token.Header.Select(h => new { h.Key, h.Value }));
            //jwtOutput = $"{{\r\n\"Header\":\r\n{JToken.Parse(jwtHeader)},";

            // Re-serialize the Token Claims to just Type and Values
            return JsonConvert.SerializeObject(token.Claims.Select(c => new { c.Type, c.Value }));
            //var jwtPayload = JsonConvert.SerializeObject(token.Claims.Select(c => new { c.Type, c.Value }));
            //jwtOutput += $"\r\n\"Payload\":\r\n{JToken.Parse(jwtPayload)}\r\n}}";
            //
            //// Output the whole thing to pretty Json object formatted.
            //return JToken.Parse(jwtOutput).ToString(Formatting.Indented);
        }

        public string GetEmailFromToken(string JwtToken)
        {
            var allClaims = ReadToken(JwtToken);
            var objects = JArray.Parse(allClaims);
            foreach (var item in objects)
            {
                if (item["Type"].ToString() == "unique_name")
                    return item["Value"].ToString();
            }
            return null;
        }
        
        //****************************************************************

        private async Task<IEnumerable<Claim>> GetClaimsAsync(User user)
        {
            var list = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString())
            };

            var claimList = await _userManager.GetClaimsAsync(user);
            foreach (var claim in claimList)
                list.Add(new Claim(claim.Type, claim.Value));

            var roleList = await _userManager.GetRolesAsync(user);
            foreach (var role in roleList)
                list.Add(new Claim(ClaimTypes.Role, role));

            return list;
        }
    }
}
