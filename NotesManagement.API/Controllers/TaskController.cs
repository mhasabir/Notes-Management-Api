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
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly ILogger<Todo> _logger;

        public TodoController(
            ITodoService todoService,
            Microsoft.Extensions.Logging.ILogger<Todo> logger)
        {
            this._todoService = todoService;
            this._logger = logger;
        }
        // GET: api/Todo
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _todoService.GetAll(userId);
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
        // GET: api/Todo/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _todoService.GetDataById(userId, id);
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
        // POST: api/Todo
        [HttpPost]
        public IActionResult Post([FromBody] Todo todo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                todo.UserId = User.GetUserIdFromClaimIdentity();
                var response = _todoService.Create(todo);
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
        // PUT: api/Todo
        [HttpPut]
        public IActionResult Put([FromBody] Todo todo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _todoService.Update(userId, todo);
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
        // DELETE: api/Todo/1
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _todoService.Delete(userId, id);
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
