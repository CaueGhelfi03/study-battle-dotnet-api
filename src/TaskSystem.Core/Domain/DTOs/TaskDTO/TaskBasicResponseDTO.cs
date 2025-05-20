using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSystem.Core.Domain.Enums.TaskComplexity;

namespace TaskSystem.Core.Domain.DTOs.TaskDTO
{
    public record TaskBasicResponseDTO
    {
        public string TaskName { get; set; }
        public Enums.Status.StatusEnum Status { get; set; }
        public TaskComplexityEnum Complexity { get; set; }
        public int Order { get; set; }


    }
}
