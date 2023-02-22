using Microsoft.EntityFrameworkCore;
using TodoAppBe.Database;
using TodoAppBe.Domain;
using TodoAppBe.DTO;
using TodoAppBe.Entities;
using TodoAppBe.Exceptions;
using TodoAppBe.Services.Interfaces;

namespace TodoAppBe.Services;

public class TaskService : ITaskService
{
    private ApplicationContext _context;

        public TaskService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<TTaskDto> CreateAsync(
            Guid PublicId,
            TTaskModel model,
            CancellationToken ct = default)
        {

            var task = model.ToDomain();
            task.PublicId = Guid.NewGuid();

        task.Title = model.Title;
        task.Description = model.Description;
        task.Priority = model.Priority;

        await _context.Tasks.AddAsync(task, ct);
            await _context.SaveChangesAsync(ct);
            return task.ToDto();
        }

        public Task<TTaskDto> CreateAsync(Guid Id, string Title, string Description, string Priority, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(
                Guid publicId,
                CancellationToken ct = default)
            {
                var task = await _context.Tasks
                    .SingleOrDefaultAsync(x => x.PublicId == publicId, ct);
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync(ct);
            }

            public async Task<TTaskDto> GetAsync(
                Guid publicId,
                CancellationToken ct = default)
            {
                var task = await _context.Tasks
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.PublicId == publicId, ct);
                if (task == null)
                {
                throw new NotFoundException("Task not found ({ID})".Replace("{ID}", ""+publicId));
                }

                return task.ToDto();
            }

            public async Task<TTaskDto> UpdateAsync(
                Guid publicId,
                TTaskModel model,
                CancellationToken ct = default)
            {
                var task = await _context.Tasks
                    .SingleOrDefaultAsync(x => x.PublicId == publicId, ct);
                if (task == null)
                {
                    throw new NotFoundException("Task not found ({ID})".Replace("{ID}", ""+publicId));
                }

                task.Description = model.Description;
                task.Priority = model.Priority;

                _context.Tasks.Update(task);
                await _context.SaveChangesAsync(ct);
                return task.ToDto();
            }

            public Task<TTaskDto> UpdateAsync(Guid Id, string Description, string Priority, CancellationToken ct = default)
            {
                throw new NotImplementedException();
            }
}