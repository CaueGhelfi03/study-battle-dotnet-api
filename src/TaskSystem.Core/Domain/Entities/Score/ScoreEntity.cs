using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskSystem.Core.Domain.Models.User;

namespace TaskSystem.Core.Domain.Entities.Score
{
    [Table("Score")]
    public class ScoreEntity
    {
        [Key]
        public Guid Id { get; set; }
        UserEntity User { get; set; }
        int Points { get; set; } = 0;
    }
}
