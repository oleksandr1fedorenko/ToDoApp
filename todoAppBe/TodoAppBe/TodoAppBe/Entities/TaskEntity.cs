using System.ComponentModel.DataAnnotations;

namespace TodoAppBe.Entities;

public class TaskEntity
{
    [Key] public int Id { get; set; }

    public string Description { get; set; }

    public string Title { get; set; }
    public string Priority { get; set; }
}