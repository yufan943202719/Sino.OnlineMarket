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
        public  string GenerateToken(string user, DateTime expires)
        {
            var handler = new JwtSecurityTokenHandler();

            ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(user, "TokenAuth"), new[] { new Claim("EntityID", "1", ClaimValueTypes.Integer) });

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = TokenAuthOption.Issuer,
                Audience = TokenAuthOption.Audience,
                SigningCredentials = TokenAuthOption.SigningCredentials,
                Subject = identity,
                Expires = expires
            });
            return handler.WriteToken(securityToken);
        }

      
    }
}
