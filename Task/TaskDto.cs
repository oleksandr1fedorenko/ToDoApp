using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Task
{
    public class TaskDto
    {
        public Guid TaskId { get; set; }
        public int TaskPriority { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; internal set; }
    }
}