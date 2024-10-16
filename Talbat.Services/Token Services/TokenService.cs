using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Talbat.Core.Entites.identity;
using Talbat.Core.Serivces;

namespace Talbat.Services.Services
{
    public class TokenService : ITokenServices
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> GetToken(Appuser user, UserManager<Appuser> userManager)
        {
            //private claims user Defined]
            var authclaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.GivenName,user.DisplayName),
                   new Claim(ClaimTypes.Email,user.Email),
                };
            var userrole = await userManager.GetRolesAsync(user);
            foreach (var role in userrole)

                authclaims.Add(new Claim(ClaimTypes.Role, role));//....

            var authkey =new SymmetricSecurityKey (Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            var Token = new JwtSecurityToken(
                issuer: _configuration["jwt:ValidIssure"],
                audience: _configuration["jwt:ValidAduince"],
                expires: DateTime.Now.AddDays(double.Parse(_configuration["jwt:Duration"])),
               claims:authclaims,
               signingCredentials:new SigningCredentials(authkey,SecurityAlgorithms.HmacSha256Signature)


                );

            return new JwtSecurityTokenHandler().WriteToken(Token);


        }
        
    }
}