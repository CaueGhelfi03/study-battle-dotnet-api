using StudyBattle.core.Domain.Entities.Challenge;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskSystem.Domain.Enums.Status;
using TaskSystem.Domain.Models.User;

namespace TaskSystem.Domain.Models.Task
{
    [Table("Tasks")]
    public class TaskEntity
    {
        [Key]
        [Column("task_id")]
        public Guid Id { get; set; } = new Guid();

        [Column("challenge_id")]
        public Guid ChallengeId { get; set; }

        [ForeignKey(nameof(ChallengeId))]
        public virtual ChallengeEntity Challenge { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual UserEntity User { get; set; }

        [Column("task_name")]
        [Required]
        public string TaskName { get; set; }

        [Column("task_description")]
        public string Description { get; set; }

        [Column("task_createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow ;

        [Column("task_status")]
        public Enums.Status.StatusEnum Status { get; set; } = Enums.Status.StatusEnum.Pending;

        public TaskEntity()
        {
        }


    }
}
