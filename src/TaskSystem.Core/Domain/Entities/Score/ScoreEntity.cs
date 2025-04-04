using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskSystem.Core.Domain.Models.User;

namespace TaskSystem.Core.Domain.Entities.Score
{
    [Table("Score")]
    public class ScoreEntity
    {
        [Key]
        [Column("score_id")]
        public Guid Id { get; set; }
        public UserEntity? User { get; set; }
        [Column("score_points")]
        public int Points { get; set; } = 0;
    }
}
