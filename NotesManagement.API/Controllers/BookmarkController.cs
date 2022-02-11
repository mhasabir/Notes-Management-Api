using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotesManagement.Entity.Models;
using NotesManagement.Service.Services;
using NotesManagement.Utility.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace NotesManagement.API.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly IBookmarkService _bookmarkService;
        private readonly ILogger<Bookmark> _logger;

        public BookmarkController(
            IBookmarkService bookmarkService,
            Microsoft.Extensions.Logging.ILogger<Bookmark> logger)
        {
            this._bookmarkService = bookmarkService;
            this._logger = logger;
        }
        // GET: api/Bookmark
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _bookmarkService.GetAll(userId);
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
        // GET: api/Bookmark/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _bookmarkService.GetDataById(userId, id);
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
        // POST: api/Bookmark
        [HttpPost]
        public IActionResult Post([FromBody] Bookmark bookmark)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                bookmark.UserId = User.GetUserIdFromClaimIdentity();
                var response = _bookmarkService.Create(bookmark);
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
        // PUT: api/Bookmark
        [HttpPut]
        public IActionResult Put([FromBody] Bookmark bookmark)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _bookmarkService.Update(userId, bookmark);
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
        // DELETE: api/Bookmark/1
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                int userId = User.GetUserIdFromClaimIdentity();
                var response = _bookmarkService.Delete(userId, id);
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
