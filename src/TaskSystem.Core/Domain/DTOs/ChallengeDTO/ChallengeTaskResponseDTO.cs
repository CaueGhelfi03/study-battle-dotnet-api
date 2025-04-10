using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSystem.Core.Domain.DTOs.TaskDTO;
using TaskSystem.Core.Domain.Enums.Status;
using TaskSystem.Core.Domain.Enums.TaskComplexity;
using TaskSystem.Core.Domain.Models.Task;

namespace TaskSystem.Core.Domain.DTOs.ChallengeDTO
{
    public record ChallengeTaskResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationDays { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public StatusEnum Status { get; set; }
        public TaskComplexityEnum ChallengeComplexity { get; set; }
        public ICollection<TaskResponseDTO> Tasks { get; set; }

    }
}
