using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UnluCo.ECommerce.Authentication;
using UnluCo.ECommerce.Entities;

namespace UnluCo.ECommerce.Authorization
{
    public class TokenGenarator
    {
        private readonly IConfiguration _configuration;
        public TokenGenarator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateToken(AppUser user,IList<string> userRoles)
        {
            DateTime exp = DateTime.Now.AddMinutes(15);
            Token token = new Token
            {
                Expiration = exp
            };

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),

            };
            foreach (var role in userRoles)
            {
                if (role is not null)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, Convert.ToString(role)!));
                }
               
            }

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer:_configuration["Jwt:Issuer"],
                audience:_configuration["Jwt:Audience"],
                expires:exp,notBefore:DateTime.Now,
                signingCredentials:credentials,
                claims:authClaims
            );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var accessToken = tokenHandler.WriteToken(securityToken);
            token.AccessToken = accessToken;
            token.RefreshToken = Guid.NewGuid().ToString();
            return token;
        }
    }
}

