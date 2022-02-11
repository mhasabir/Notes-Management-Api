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
    public class RegularNoteController : ControllerBase
    {
        private readonly IRegularNoteService _regularNoteService;
        private readonly ILogger<RegularNote> _logger;

        public RegularNoteController(
            IRegularNoteService regularNoteService,
            Microsoft.Extensions.Logging.ILogger<RegularNote> logger)
        {
            this._regularNoteService = regularNoteService;
            this._logger = logger;
        }
        // GET: api/RegularNote
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _regularNoteService.GetAll(userId);
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
        // GET: api/RegularNote/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _regularNoteService.GetDataById(userId, id);
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
        // POST: api/RegularNote
        [HttpPost]
        public IActionResult Post([FromBody] RegularNote regularNote)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                regularNote.UserId = User.GetUserIdFromClaimIdentity();
                var response = _regularNoteService.Create(regularNote);
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
        // PUT: api/RegularNote
        [HttpPut]
        public IActionResult Put([FromBody] RegularNote regularNote)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _regularNoteService.Update(userId, regularNote);
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
        // DELETE: api/RegularNote/1
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _regularNoteService.Delete(userId, id);
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
