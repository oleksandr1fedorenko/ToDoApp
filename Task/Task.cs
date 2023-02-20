using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Task
{
    public class Task
    {

        public Guid TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskData { get; set; }
        public int TaskPriority { get; set; }

        private Task(Guid taskId,
                     string taskName,
                     string taskData,
                     int taskPriority)
        {
            TaskId = taskId;
            TaskName = taskName;
            TaskData = taskData;
            TaskPriority = taskPriority;
        }

        public void CreateTask()
        {
            Console.WriteLine("Task created");
        }

        public void DeleteTask()
        {
            Console.WriteLine("Task deleted");
        }

        public void UpdateTask()
        {
            Console.WriteLine("Task updated");
        }

    }
}