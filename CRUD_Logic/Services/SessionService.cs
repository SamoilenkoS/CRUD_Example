using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace CRUD_Logic.Services
{
    public class SessionService : ISessionService
    {
        private string _securityKey = "Supper pupper crypto secret";

        public async Task<string> CreateAuthCookieAsync(int id)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var header = new JwtHeader(credentials);

            var payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Now.AddDays(1));
            var securityToken = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public async Task<int> GetIdFromAuthCookieAsync(string cookie)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII
                    .GetBytes(_securityKey); //TODO check is any differences with Encoding.UTF8 and unificate
                tokenHandler.ValidateToken(cookie, new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out var validationToken);

                var result = (JwtSecurityToken) validationToken;

                return int.Parse(result.Issuer);
            }
            catch (Exception)
            {
                // ignored
            }

            return -1;
        }
    }
}
