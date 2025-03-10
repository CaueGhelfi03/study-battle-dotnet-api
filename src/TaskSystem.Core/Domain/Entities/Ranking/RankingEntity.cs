using TaskSystem.Core.Domain.Entities.Challenge;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using TaskSystem.Core.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using TaskSystem.Core.Domain.Entities.Score;

namespace TaskSystem.Core.Domain.Entities.Ranking
{
    [Table("Ranking")]
    public class RankingEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = new Guid();

        [Column("ranking_challengeId")]
        public Guid ChallengeId { get; set; }

        [ForeignKey(nameof(ChallengeEntity.Id))]
        public ChallengeEntity Challenge { get; set; }
        [Column("ranking_createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("ranking_updatedAt")]
        public DateTime UpdatedAt { get; set; }
        ICollection<ScoreEntity> Scores { get; set; } = [];
    }
}
