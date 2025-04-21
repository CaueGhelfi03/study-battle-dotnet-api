using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSystem.Core.Domain.Enums.Status;

namespace TaskSystem.Core.Domain.DTOs.UserTaskCompletationDTO
{
    public record UserTaskCreateDTO
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }
        public int Score { get; set; }
    }
}
