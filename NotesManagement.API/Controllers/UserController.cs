using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotesManagement.Entity.Models;
using NotesManagement.Service.Services;
using NotesManagement.Utility.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;


namespace NotesManagement.API.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<User> _logger;

        public UserController(
            IUserService userService,
            Microsoft.Extensions.Logging.ILogger<User> logger)
        {
            this._userService = userService;
            this._logger = logger;
        }
        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var response = _userService.GetAll();
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
        // GET: api/User/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _userService.GetDataById(userId);
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
        // POST: api/User
        [HttpPost, AllowAnonymous]
        public IActionResult Signup([FromBody] UserRegistration userRegistration)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var response = _userService.Create(userRegistration);
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
        // PUT: api/User
        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _userService.Update(userId, user);
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
