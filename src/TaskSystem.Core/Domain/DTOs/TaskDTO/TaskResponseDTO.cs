
using TaskSystem.Core.Domain.DTOs.ChallengeDTO;

namespace TaskSystem.Core.Domain.DTOs.TaskDTO
{
    public record TaskResponseDTO
    {
        public ChallengeResponseDTO Challenge { get; set; }
        public Guid Id{ get; set; }
        public Guid UserId { get; set; }
        public string Username{ get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Enums.Status.StatusEnum Status { get; set; }
        


    }
}
