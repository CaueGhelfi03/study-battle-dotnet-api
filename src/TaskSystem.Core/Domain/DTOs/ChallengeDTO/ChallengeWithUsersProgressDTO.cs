using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSystem.Core.Domain.DTOs.ChallengeUserDTO;
using TaskSystem.Core.Domain.Enums.Status;
using TaskSystem.Core.Domain.Enums.TaskComplexity;

namespace TaskSystem.Core.Domain.DTOs.ChallengeDTO
{
    public record ChallengeWithUsersProgressDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationDays { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public StatusEnum Status { get; set; }
        public TaskComplexityEnum ChallengeComplexity { get; set; }
        public ICollection<UserProgressResponseDTO> UserProgress { get; set; }

    }
}
