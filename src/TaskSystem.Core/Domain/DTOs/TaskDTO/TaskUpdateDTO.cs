using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSystem.Core.Domain.Enums.TaskComplexity;

namespace TaskSystem.Core.Domain.DTOs.TaskDTO
{
    public record TaskUpdateDTO
    {
        public int Order {  get; set; }
        public TaskComplexityEnum Complexity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
