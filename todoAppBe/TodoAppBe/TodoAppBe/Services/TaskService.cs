using Microsoft.EntityFrameworkCore;
using TodoAppBe.Database;
using TodoAppBe.DTO;
using TodoAppBe.Entities;
using TodoAppBe.Model;
using TodoAppBe.Services.Interfaces;

namespace TodoAppBe.Services;

public class TaskService:ITaskService
{
    private readonly ApplicationContext _context;

    public TaskService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<TaskDto>> GetAllAsync()
    {
        var items = await _context.Tasks.AsNoTracking().ToListAsync();

        if (items == null)
        {
            throw new Exception("Tasks not found");
        }

        var tasks = items.Select(x => x.toDto()).ToList();

        return tasks;
    }

    public async Task<bool> CreateAsync(TaskModel taskModel)
    {
        if (await _context.Tasks.AnyAsync(x => x.Title == taskModel.Title))
        {
            throw new Exception($"Product with name {taskModel.Title} already exists");
        }

        var task = new TaskEntity
        {
            Priority = taskModel.Priority,
            Title = taskModel.Title,
            Description = taskModel.Description
        };

        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

        if (item == null)
        {
            throw new Exception("Task not found");
        }

        _context.Tasks.Remove(item);
        await _context.SaveChangesAsync();
    }
}