using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using TodoAppBe.DTO;
using TodoAppBe.Entities;
using TodoAppBe.Services.Interfaces;

namespace TodoAppBe.Controllers
// {
//     [Route("[controller]")]
//     public class Task : Controller
//     {
//         private readonly ILogger<Task> _logger;

//         public Task(ILogger<Task> logger)
//         {
//             _logger = logger;
//         }

//         public IActionResult Index()
//         {
//             return View();
//         }

//         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//         public IActionResult Error()
//         {
//             return View("Error!");
//         }
//     }
// }

{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public const string GetProductRouteName = "gettask";

        [HttpGet("{task1}", Name = GetProductRouteName)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TTaskDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            summary: "Create task",
            description: "",
            OperationId = "CreateTask",
            Tags = new[] { "Product API" })]
        public async Task<IActionResult> GetProductAsync(
            [Required, FromRoute(Name = "task1")] Guid? Id, string Title, string Description, string Priority,
            CancellationToken ct)
        {
            TTaskDto taskDto = await _taskService.GetAsync(Id.Value, ct);
            return Ok(taskDto);
        }

        [HttpPut("{task2}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TTaskDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [SwaggerOperation(
            summary: "Update task",
            description: "Update",
            OperationId = "UpdateTask",
            Tags = new[] { "Task Management" })]
        public async Task<IActionResult> UpdateProductAsync(
            [Required, FromRoute(Name = "task2")] Guid? Id, string Description, string Priority,
            [Bind, FromBody] TTaskModel model,
            CancellationToken ct)
        {
            TTaskDto ttaskDto = await _taskService.UpdateAsync(Id.Value, model.Description, model.Priority, ct);
            // Guid Id, string Description, string Priority, CancellationToken ct = default)
            return Ok(ttaskDto);
        }

        [HttpDelete("{task_name}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            summary: "Delete",
            description: "Delete",
            OperationId = "DeleteTask",
            Tags = new[] { "Task Management" })]
        public async Task<IActionResult> DeleteProductAsync(
            [Required, FromRoute(Name = "task_name")] Guid? Id,
            CancellationToken ct)
        {
            await _taskService.DeleteAsync(Id.Value, ct);
            return NoContent();
        }
    }
}