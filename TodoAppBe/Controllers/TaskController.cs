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

namespace TodoAppBe.Controllers;

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

    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TTaskDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(
        summary: "Create task",
        description: "",
        OperationId = "CreateTask",
        Tags = new[] { "Product API" })]
    public async Task<IActionResult> CreateAsync(
        [Required, FromRoute(Name = "create")] Guid? Id, string Title, string Description, string Priority,
        CancellationToken ct)
    {
        TTaskDto taskDto = await _taskService.GetAsync(Id.Value, ct);
        return Ok(taskDto);
    }

    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TTaskDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [SwaggerOperation(
        summary: "Update task",
        description: "Update",
        OperationId = "UpdateTask",
        Tags = new[] { "Task Management" })]
    public async Task<IActionResult> UpdateAsync(
        [Required, FromRoute(Name = "{update}")] Guid? Id, string Description, string Priority,
        [Bind, FromBody] TTaskModel model,
        CancellationToken ct)
    {
        TTaskDto ttaskDto = await _taskService.UpdateAsync(Id.Value, model.Description, model.Priority, ct);
        // Guid Id, string Description, string Priority, CancellationToken ct = default)
        return Ok(ttaskDto);
    }

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(
        summary: "Delete",
        description: "Delete",
        OperationId = "DeleteTask",
        Tags = new[] { "Task Management" })]
    public async Task<IActionResult> DeleteAsync(
        [Required, FromRoute(Name = "{delete}")] Guid? Id,
        CancellationToken ct)
    {
        await _taskService.DeleteAsync(Id.Value, ct);
        return NoContent();
    }
}
