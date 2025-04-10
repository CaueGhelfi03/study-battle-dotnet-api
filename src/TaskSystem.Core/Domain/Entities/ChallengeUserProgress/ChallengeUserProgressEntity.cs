using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSystem.Core.Domain.Entities.Challenge;
using TaskSystem.Core.Domain.Models.User;

namespace TaskSystem.Core.Domain.Entities.UserChallengeProgress
{
    [Table("ChallengeUserProgressEntity")]
    public class ChallengeUserProgressEntity
    {
        [Key]
        [Column("progress_id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("streak_count")]
        public int StreakCount { get; set; } = 0;

        [Column("last_active_date")]
        public DateTime? LastActiveDate { get; set; }

        [Column("progress_total_score")]
        public int TotalScore { get; set; } = 0;

        [Column("user_id")]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual UserEntity User { get; set; }

        [Column("challenge_id")]
        public Guid ChallengeId { get; set; }

        [ForeignKey(nameof(ChallengeId))]
        public virtual ChallengeEntity Challenge { get; set; }
    }
}
