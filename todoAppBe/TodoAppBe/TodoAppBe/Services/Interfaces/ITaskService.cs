using TodoAppBe.DTO;

namespace TodoAppBe.Services.Interfaces;

public interface ITaskService
{
    Task<TTaskDto> GetAsync(Guid Id, CancellationToken ct = default);
    Task<TTaskDto> CreateAsync(Guid Id, string Title, string Description, string Priority, CancellationToken ct = default);
    Task<TTaskDto> UpdateAsync(Guid Id, string Description, string Priority, CancellationToken ct = default);
    Task DeleteAsync(Guid Id, CancellationToken ct = default);
}