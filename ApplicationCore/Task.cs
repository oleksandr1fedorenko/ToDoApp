using System.ComponentModel.DataAnnotations;
using ToDoApp.Task;

namespace ToDoApp.ApplicationCore
{
    public class Task
    {
        [Key]
        public Guid TaskId { get; set; }

        [Required]
        public int TaskPriority { get; set; }

        [Required, StringLength(20)]
        public string TaskName { get; set; }

        [Required, StringLength(200)]
        public string TaskDescription { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

        public TaskDto ToDto()
        {
            return new TaskDto
            {
                TaskId = TaskId,
                TaskPriority = TaskPriority,
                TaskName = TaskName,
                TaskDescription = TaskDescription
            };
        }
    }
}