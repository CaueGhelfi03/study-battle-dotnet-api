
using TaskSystem.core.Domain.DTOs.ChallengeDTO;

namespace TaskSystem.Domain.DTOs.TaskDTO
{
    public class TaskResponseDTO
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
