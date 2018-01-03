using Sino.OnlineMarket.Repositories.ViewModel;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using Sino.OnlineMarket.Webhost.Auth;
using System.Linq;

namespace Sino.OnlineMarket.Repositories.Repository
{
    public class TokenRepository
    {

        /// <summary>
        /// 生成Token值
        /// </summary>
        /// <param name="user"></param>
        /// <param name="expires"></param>
        /// <returns></returns>
        public  string GenerateToken(Users user, DateTime expire,string audience)
        {
            var handler = new JwtSecurityTokenHandler();
            var claims = new[]
            {
               new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())

            };
            ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(user.UserName, "TokenAuth"), claims);

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "TestIssuer",
                Audience = audience,
                SigningCredentials = TokenAuthOption.SigningCredentials,
                Subject = identity,
                Expires = expire
            });
            return handler.WriteToken(securityToken);
        }

      
    }
}
