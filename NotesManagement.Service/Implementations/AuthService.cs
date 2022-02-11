using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NotesManagement.Entity.Models;
using NotesManagement.Service.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace NotesManagement.Service.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthService(IConfiguration configuration, IUserService userService)
        {
            this._configuration = configuration;
            this._userService = userService;
        }
        public TokenResult BuildToken(JwtTokenInfo request)
        {
            TokenResult tokenResult = new TokenResult();
            var user = _userService.GetDataByEmail(request.Email);
            if (user != null)
            {
                var isValid = VerifyPassword(request.Password, user.Salt, user.PasswordHash);
                if (!isValid)
                {
                    tokenResult.StatusCode = 401;
                    tokenResult.Message = "Unauthorized";
                    return tokenResult;
                }
                else
                {
                    var token = GenerateToken(request.Email, user.UserId.ToString());
                    tokenResult.Access_token = new JwtSecurityTokenHandler().WriteToken(token);
                    tokenResult.Expiration = token.ValidTo;
                    tokenResult.StatusCode = 200;
                    tokenResult.Message = "Success";
                    return tokenResult;
                }
            }
            tokenResult.StatusCode = 404;
            tokenResult.Message = "Not Found";
            return tokenResult;
        }
        public TokenResult BuildRefreshToken(string token)
        {
            TokenResult tokenResult = new TokenResult();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt_Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var handler = new JwtSecurityTokenHandler();
            var refreshToken = handler.ReadToken(token) as JwtSecurityToken;
            var claims = refreshToken.Claims.ToList();
            var newToken = new JwtSecurityToken(_configuration["service_base"], _configuration["origins"], claims, expires: DateTime.UtcNow.AddHours(1), signingCredentials: credentials);

            tokenResult.Access_token = new JwtSecurityTokenHandler().WriteToken(newToken);
            tokenResult.Expiration = newToken.ValidTo;
            tokenResult.StatusCode = 200;
            tokenResult.Message = "Success";
            return tokenResult;
        }
        private JwtSecurityToken GenerateToken(string email, string userId, int RoleId = 0)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt_Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            IEnumerable<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email, JwtSecurityTokenHandler.JsonClaimTypeProperty),
                new Claim(JwtRegisteredClaimNames.UniqueName, email, JwtSecurityTokenHandler.JsonClaimTypeProperty),
                new Claim("UserId", userId, JwtSecurityTokenHandler.JsonClaimTypeProperty),
            };
            var token = new JwtSecurityToken(_configuration["service_base"], _configuration["origins"], claims, expires: DateTime.UtcNow.AddYears(1), signingCredentials: credentials);
            return token;
        }
        private bool VerifyPassword(string password, string salt, string passwordHash)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return (passwordHash == hashed);
        }
    }
}
