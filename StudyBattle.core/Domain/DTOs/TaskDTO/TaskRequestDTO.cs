using TaskSystem.Domain.Enums.Priority;

namespace TaskSystem.Domain.DTOs.TaskDTO
{
    public class TaskRequestDTO
    {
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } =  DateTime.UtcNow;

        public Enums.Status.TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
    }
}
