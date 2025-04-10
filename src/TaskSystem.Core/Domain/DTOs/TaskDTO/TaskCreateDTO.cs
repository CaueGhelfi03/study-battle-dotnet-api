
using TaskSystem.Core.Domain.Enums.Status;
using TaskSystem.Core.Domain.Enums.TaskComplexity;

namespace TaskSystem.Core.Domain.DTOs.TaskDTO
{
    public record TaskCreateDTO
    {
        public string TaskName { get; set; }
        public string Description { get; set; }
        public TaskComplexityEnum Complexity { get; set; } = TaskComplexityEnum.Easy;
        public StatusEnum Status {  get; set; }
        public DateTime CreatedAt { get; set; } =  DateTime.UtcNow;
    }
}
