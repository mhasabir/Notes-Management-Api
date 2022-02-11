using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotesManagement.Entity.Models;
using NotesManagement.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<JwtTokenInfo> _logger;

        //private readonly CareAppContext _careAppContext;
        public AuthorizationController(IAuthService authService, ILogger<JwtTokenInfo> logger)
        {
            this._authService = authService;
            this._logger = logger;
        }

        //POST : /token
        [HttpPost("~/token"), AllowAnonymous]
        public IActionResult Token(JwtTokenInfo request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var response = _authService.BuildToken(request);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        //POST : /RefreshToken
        [HttpPost("~/refresh_token"), AllowAnonymous]
        public IActionResult RefreshToken(JwtTokenInfo request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var response = _authService.BuildRefreshToken(request.Refreshtoken);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
