namespace todo_backend.applicationCore.Entities;

public class TaskDto
{
    public class taskDto
    {
        public Guid TaskId { get; set; }
        public int TaskPriority { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; internal set; }
    }
}