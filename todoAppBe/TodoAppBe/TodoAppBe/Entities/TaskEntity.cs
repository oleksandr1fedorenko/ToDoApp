using System.ComponentModel.DataAnnotations;
using TodoAppBe.DTO;

namespace TodoAppBe.Entities;

public class TaskEntity
{
    [Key] public int Id { get; set; }

    public string Description { get; set; }

    public string Title { get; set; }
    public string Priority { get; set; }

    public TaskDto toDto()
    {
        return new TaskDto()
        {
            Id = this.Id,
            Title = this.Title,
            Description = this.Description,
            Priority = this.Priority
            
        };
    }
}