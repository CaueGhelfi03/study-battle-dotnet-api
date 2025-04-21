using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSystem.Core.Domain.Enums.Status;

namespace TaskSystem.Core.Domain.DTOs.UserTaskCompletationDTO
{
    public record UserTaskUpdateDTO
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
        public int Score { get; set; }
        public StatusEnum Status { get; set; }
    }
}
