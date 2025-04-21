using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSystem.Core.Domain.DTOs.ChallengeDTO;
using TaskSystem.Core.Domain.Enums.Status;
using TaskSystem.Core.Domain.Enums.TaskComplexity;

namespace TaskSystem.Core.Domain.DTOs.ChallengeUserDTO
{
    public record ChallengeUserResponseDTO
    {
        public ChallengeResponseDTO Challenge { get; set; }
        public ICollection<UserProgressResponseDTO> UserProgress { get; set; }
    }
}
