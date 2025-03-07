using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSystem.Domain.Enums.Status;

namespace TaskSystem.core.Domain.DTOs.ChallengeDTO
{
    public record ChallengeResponseDTO
    {
        public Guid Id { get; set; }
        public string ChallengeName { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
    }
}
