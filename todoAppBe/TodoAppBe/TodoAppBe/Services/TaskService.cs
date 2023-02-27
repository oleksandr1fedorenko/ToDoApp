using Microsoft.EntityFrameworkCore;
using TodoAppBe.Database;
using TodoAppBe.DTO;
using TodoAppBe.Entities;
using TodoAppBe.Exceptions;
using TodoAppBe.Model;
using TodoAppBe.Services.Interfaces;

namespace TodoAppBe.Services;

public class TaskService : ITaskService
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
            throw new NotFoundException("Tasks not found");
        }

        var tasks = items.Select(x => x.toDto()).ToList();

        return tasks;
    }

    public async Task<bool> CreateAsync(TaskModel taskModel)
    {
        
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

    public async Task<bool> UpdateAsync(int taskId,TaskDto taskDto)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id== taskId);

        if (task == null)
        {
            throw new NotFoundException("Empty");
        }

        if (await _context.Tasks.AnyAsync(x => x.Title == taskDto.Title && x.Id != taskId))
        {
            throw new Exception("Already exist !");
        }

        task.Title = taskDto.Title;
        task.Description = taskDto.Description;
        task.Priority = taskDto.Priority;


        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<TaskDto> GetAsync(int taskId)
    {
        var task = await _context.Tasks.AsNoTracking().SingleOrDefaultAsync(x => x.Id == taskId);
        if (task == null)
        {
            throw new NotFoundException($"Product with ID: {taskId} doesn't exist");
        }

        return task.toDto();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);

        if (item == null)
        {
            throw new NotFoundException("Task not found");
        }

        _context.Tasks.Remove(item);
        await _context.SaveChangesAsync();
    }
}