using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSystem.Core.Domain.Enums.Status;

namespace TaskSystem.Core.Domain.DTOs.ChallengeUserDTO
{
    public record ChallengeUserProgressDTO
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int TotalScore { get; set; }
        public StatusEnum ProgressStatus { get; set; }
    }

}

