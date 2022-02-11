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
    public class ReminderController : ControllerBase
    {
        private readonly IReminderService _reminderService;
        private readonly ILogger<Reminder> _logger;

        public ReminderController(
            IReminderService reminderService,
            Microsoft.Extensions.Logging.ILogger<Reminder> logger)
        {
            this._reminderService = reminderService;
            this._logger = logger;
        }
        // GET: api/Reminder
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _reminderService.GetAll(userId);
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
        // GET: api/Reminder/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _reminderService.GetDataById(userId, id);
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
        // POST: api/Reminder
        [HttpPost]
        public IActionResult Post([FromBody] Reminder reminder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                reminder.UserId = User.GetUserIdFromClaimIdentity();
                var response = _reminderService.Create(reminder);
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
        // PUT: api/Reminder
        [HttpPut]
        public IActionResult Put([FromBody] Reminder reminder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _reminderService.Update(userId, reminder);
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
        // DELETE: api/Reminder/1
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _reminderService.Delete(userId, id);
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
