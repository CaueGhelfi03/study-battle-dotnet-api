
namespace TaskSystem.Core.Domain.DTOs.TaskDTO
{
    public record TaskCreateDTO
    {
        public Guid ChallengeId { get; set; }
        public Guid UserId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } =  DateTime.UtcNow;
        public Enums.Status.StatusEnum Status { get; set; }
    }
}
