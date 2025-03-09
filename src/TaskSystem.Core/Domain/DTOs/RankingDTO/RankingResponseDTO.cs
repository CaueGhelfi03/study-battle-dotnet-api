using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSystem.Core.Domain.DTOs.RankingDTO
{
    public record RankingResponseDTO
    {
        public Guid ChallengeId { get; set; }
        public string ChallengeName { get; set; }
        public List<RankingUserResponseDTO> Users { get; set; }
    }
}
