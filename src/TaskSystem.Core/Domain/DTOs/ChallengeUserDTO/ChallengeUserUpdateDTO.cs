using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSystem.Core.Domain.DTOs.ChallengeUserDTO
{
    public record ChallengeUserUpdateDTO
    {
        public int StreakCount { get; set; }
        public DateTime? LastActiveDate { get; set; }
        public int TotalScore { get; set; } = 0;
    }
}
