using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodoAppBe.DTO;
using TodoAppBe.Model;
using TodoAppBe.Services.Interfaces;

namespace TodoAppBe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController:ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync()
        {
            var tasks = await _taskService.GetAllAsync();
            return Ok(tasks);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateAsync(
            [Required, FromBody, Bind] TaskModel taskModel
        )
        {
            var task = await _taskService.CreateAsync(taskModel);

            return Ok(task);
        }
        
       
        [HttpPut("{task_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(
            [Required, FromBody, Bind] TaskDto taskDto
        )
        {
            var task = await _taskService.UpdateAsync(taskDto);
            return Ok(task);
        }
        

        [HttpDelete("{task_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(
            [Required, FromRoute(Name = "task_id")]
            int taskId
        )
        {
            await _taskService.DeleteAsync(taskId);
            return NoContent();
        }
    }
}