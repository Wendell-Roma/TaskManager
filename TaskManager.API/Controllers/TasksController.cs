using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManager.Core.Entities;
using TaskManager.Core.Enums;
using TaskManager.Core.Interfaces;

namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _taskRepository;

    public TasksController(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    private int GetUserId() =>
        int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _taskRepository.GetAllByUserIdAsync(GetUserId());
        return Ok(tasks);
    }

    [HttpPost]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TaskRequest request)
    {
    var task = new TaskItem
    {
        Title = request.Title,
        Description = request.Description,
        Priority = request.Priority,
        DueDate = request.DueDate.HasValue ? request.DueDate.Value.ToUniversalTime() : null,
        CreatedAt = DateTime.UtcNow,
        UserId = GetUserId()
    };

    await _taskRepository.CreateAsync(task);
    return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TaskRequest request)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        if (task is null || task.UserId != GetUserId())
            return NotFound();

        task.Title = request.Title;
        task.Description = request.Description;
        task.Priority = request.Priority;
        task.DueDate = request.DueDate;
        task.IsCompleted = request.IsCompleted;

        await _taskRepository.UpdateAsync(task);
        return Ok(task);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        if (task is null || task.UserId != GetUserId())
            return NotFound();

        await _taskRepository.DeleteAsync(id);
        return NoContent();
    }
}

public record TaskRequest(
    string Title,
    string Description,
    TaskPriority Priority,
    DateTime? DueDate,
    bool IsCompleted = false
);