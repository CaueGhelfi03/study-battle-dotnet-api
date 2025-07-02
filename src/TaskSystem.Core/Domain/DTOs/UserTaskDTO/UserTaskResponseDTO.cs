using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSystem.Core.Domain.DTOs.TaskDTO;
using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Domain.Enums.Status;

namespace TaskSystem.Core.Domain.DTOs.UserTaskCompletationDTO
{
    public record UserTaskResponseDTO
    {
        public TaskBasicResponseDTO Task{ get; set; }
        public Guid IdUserTask { get; set; }
        public StatusEnum Status { get; set; }
        public int Score { get; set; }
    }
}
