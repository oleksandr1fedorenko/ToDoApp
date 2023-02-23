using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        public const string GetProductRouteName = "gettask";
        
        [HttpGet("{task_id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(
            [Required, FromRoute(Name = "task_id")] int taskId,
            CancellationToken ct)
        {
            TaskDto taskDto = await _taskService.GetAsync(taskId);
            return Ok(taskDto);
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
            [Required,FromRoute(Name = "task_id")] int taskId,
            [FromBody, Bind] TaskDto taskDto
        )
        {
            var task = await _taskService.UpdateAsync(taskId,taskDto);
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