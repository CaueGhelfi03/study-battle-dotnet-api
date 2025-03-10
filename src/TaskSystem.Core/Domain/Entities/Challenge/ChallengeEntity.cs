using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskSystem.Core.Domain.Enums.Status;
using TaskSystem.Core.Domain.Models.User;

namespace TaskSystem.Core.Domain.Entities.Challenge
{
    [Table("Challenge")]
    public class ChallengeEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; } = new Guid();

        [Column("challenge_name")]
        public string Name { get; set; }

        [Column("challenge_description")]
        public string Description { get; set; }

        [Column("challenge_duration")]
        public int DurationDays { get; set; }

        [Column("challenge_createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("challenge_start")]
        public DateTime Start_Date { get; set; }

        [Column("challenge_end")]
        public DateTime End_Date { get; set; }

        [Column("challenge_status")]
        public StatusEnum status { get; set; }

        public ICollection<UserEntity>? Users { get; set; } = [];

    }
}
