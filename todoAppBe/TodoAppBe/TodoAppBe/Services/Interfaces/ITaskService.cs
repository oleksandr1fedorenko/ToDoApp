using TodoAppBe.DTO;
using TodoAppBe.Model;

namespace TodoAppBe.Services.Interfaces;

public interface ITaskService
{
    Task<List<TaskDto>> GetAllAsync();
    Task<bool> CreateAsync(TaskModel taskModel);
    Task DeleteAsync(int id);
    Task<bool> UpdateAsync( int taskId,TaskDto taskDto);
    Task<TaskDto> GetAsync(int taskId);
}