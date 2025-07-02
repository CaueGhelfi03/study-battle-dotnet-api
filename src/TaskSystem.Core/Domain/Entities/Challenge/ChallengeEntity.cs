using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskSystem.Core.Domain.Entities.UserChallengeProgress;
using TaskSystem.Core.Domain.Enums.Status;
using TaskSystem.Core.Domain.Enums.TaskComplexity;
using TaskSystem.Core.Domain.Models.Task;
using TaskSystem.Core.Domain.Models.User;

namespace TaskSystem.Core.Domain.Entities.Challenge
{
    [Table("Challenge")]
    public class ChallengeEntity
    {
        [Key]
        [Required]
        [Column("challenge_id")]
        public Guid Id { get; set; } = new Guid();

        [Column("challenge_created_By")]
        public Guid CreatedBy { get; set; }

        [Column("challenge_name")]
        [Required]
        public string Name { get; set; }

        [Column("challenge_description")]
        public string Description { get; set; }

        [Column("challenge_duration")]
        [Required]
        public int DurationDays { get; set; }

        [Column("challenge_createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("challenge_start")]
        public DateTime Start_Date { get; set; }

        [Column("challenge_end")]
        public DateTime End_Date { get; set; }

        [Column("challenge_status")]
        public StatusEnum status { get; set; }

        [Column("challenge_subject")]
        [Required]
        public string Subject { get; set; }

        [Column("challenge_complexity")]
        public TaskComplexityEnum ChallengeComplexity { get; set; } = TaskComplexityEnum.Easy;

        public ICollection<TaskEntity> Tasks { get; set; } = new HashSet<TaskEntity>();
        public ICollection<ChallengeUserProgressEntity> ChallengeUserProgress { get; set; } = new HashSet<ChallengeUserProgressEntity>();

    }
}
