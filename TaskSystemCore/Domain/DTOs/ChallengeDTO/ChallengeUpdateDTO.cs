using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBattle.core.Domain.DTOs.ChallengeDTO
{
    public record ChallengeUpdateDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }

    }
}
