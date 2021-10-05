using System;
using System.IdentityModel.Tokens.Jwt;

namespace MyProject.Services.JWT
{
    public class AccessToken
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }

        public AccessToken(JwtSecurityToken securityToken, string tokenType)
        {
            access_token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            token_type = tokenType; //"Bearer"
            expires_in = (int)(securityToken.ValidTo - DateTime.UtcNow).TotalSeconds;
        }
    }
}