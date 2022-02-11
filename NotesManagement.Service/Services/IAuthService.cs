using NotesManagement.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace NotesManagement.Service.Services
{
    public interface IAuthService
    {
        TokenResult BuildToken(JwtTokenInfo request);
        TokenResult BuildRefreshToken(string token);
    }
}
