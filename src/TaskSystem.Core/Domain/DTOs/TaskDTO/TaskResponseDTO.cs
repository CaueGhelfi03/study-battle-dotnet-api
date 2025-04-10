
using TaskSystem.Core.Domain.DTOs.ChallengeDTO;
using TaskSystem.Core.Domain.Enums.TaskComplexity;

namespace TaskSystem.Core.Domain.DTOs.TaskDTO
{
    public record TaskResponseDTO
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Enums.Status.StatusEnum Status { get; set; }
        public TaskComplexityEnum Complexity { get; set; }
    }
}
