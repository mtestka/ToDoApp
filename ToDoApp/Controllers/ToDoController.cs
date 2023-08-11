using System;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Entities.Models;
using ToDoApp.ExceptionsTD;
using ToDoApp.Services;

namespace ToDoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;
        private readonly IToDoTaskService _toDoTaskService;

        public ToDoController(ILogger<ToDoController> logger, IToDoTaskService toDoTaskService)
        {
            _logger = logger;
            _toDoTaskService = toDoTaskService;
        }

        [HttpGet]
        public async Task<IEnumerable<ToDoTask>> Get()
        {
            try
            {
                return await _toDoTaskService.GetAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Exception occurred: {ex.Message}");
                throw;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ToDoTask>> Get(int id)
        {
            try
            {
                return await _toDoTaskService.GetAsync(id);
            }
            catch (NotFoundException ex)
            {
                _logger.LogError($"NotFoundException occurred: {ex.Message}");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm]ToDoTask toDoTask)
        {
            try
            {
                await _toDoTaskService.Add(toDoTask);
                
                return Ok();
            }
            catch (NotFoundException ex)
            {
                _logger.LogError($"NotFoundException occurred: {ex.Message}");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred: {ex.Message}");
                throw;
            }
        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> Add([FromForm] ToDoTask toDoTask, int id)
        {
            try
            {
                await _toDoTaskService.Add(toDoTask);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                _logger.LogError($"NotFoundException occurred: {ex.Message}");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred: {ex.Message}");
                throw;
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _toDoTaskService.Remove(id);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                _logger.LogError($"NotFoundException occurred: {ex.Message}");
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred: {ex.Message}");
                throw;
            }
        }
    }
}

