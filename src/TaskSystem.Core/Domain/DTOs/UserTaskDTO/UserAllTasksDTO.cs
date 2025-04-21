using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Domain.DTOs.UserTaskCompletationDTO;

namespace TaskSystem.Core.Domain.DTOs.UserTaskDTO
{
    public record UserAllTasksDTO
    {
        public UserBasicDTO? UserBasicDTO { get; set; }
        public ICollection<UserTaskResponseDTO> TasksCompletation { get; set; }
    }
}
