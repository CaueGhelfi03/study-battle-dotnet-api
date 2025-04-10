using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSystem.Core.Domain.DTOs.ChallengeUserDTO;
using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Domain.Entities.UserChallengeProgress;
using TaskSystem.Core.Domain.Enums.Status;

namespace TaskSystem.Core.Domain.DTOs.ChallengeDTO
{
    public record class ChallengeUsersResponseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationDays { get; set; }
        public StatusEnum Status { get; set; }
        public ICollection<ChallengeUserProgressDTO> Users { get; set; }
    }
}
