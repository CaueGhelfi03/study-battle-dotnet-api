using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSystem.Core.Domain.DTOs.ChallengeDTO;
using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Domain.Enums.Status;

namespace TaskSystem.Core.Domain.DTOs.ChallengeUserDTO
{
    public record ChallengeUserCreateDTO
    {
        public Guid ChallengeId { get; set; }
        public Guid UserId { get; set; }
    }

}

