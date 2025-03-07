using StudyBattle.core.Domain.Entities.Challenge;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using TaskSystem.Domain.Models.User;

namespace StudyBattle.core.Domain.Entities.Ranking
{
    [Table("Ranking")]
    public class RankingEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = new Guid();

        [Column("ranking_challengeId")]
        public Guid ChallengeId { get; set; }

        [ForeignKey(nameof(ChallengeId))]
        public virtual ChallengeEntity Challenge { get; set; }
        [Column("ranking_createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("ranking_updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
