using TaskSystem.Core.Domain.Entities.UserChallengeProgress;
using TaskSystem.Core.Domain.Enums.Status;
using TaskSystem.Core.Domain.Enums.TaskComplexity;

namespace TaskSystem.Core.Domain.DTOs.ChallengeDTO
{
    public record ChallengeResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationDays { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public StatusEnum Status { get; set; }
        public TaskComplexityEnum ChallengeComplexity { get; set; }
    }
}
