using TaskSystem.Core.Domain.Enums.Status;
using TaskSystem.Core.Domain.Enums.TaskComplexity;

namespace TaskSystem.Core.Domain.DTOs.ChallengeDTO
{
    public record ChallengeCreateDTO
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationDays { get; set; }
        public string Subject { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public StatusEnum status { get; set; }
        public TaskComplexityEnum ChallengeComplexity { get; set; } = TaskComplexityEnum.Easy;
    }
}
