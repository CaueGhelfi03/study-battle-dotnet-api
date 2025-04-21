using TaskSystem.Core.Domain.Entities.Challenge;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskSystem.Core.Domain.Models.User;
using TaskSystem.Core.Domain.Enums.TaskComplexity;
using TaskSystem.Core.Domain.Entities.UserTaskCompletion;

namespace TaskSystem.Core.Domain.Models.Task
{
    [Table("Task")]
    public class TaskEntity
    {
        [Key]
        [Column("task_id")]
        public Guid Id { get; set; } = new Guid();

        [Column("task_name")]
        [Required]
        public string TaskName { get; set; }

        [Column("task_description")]
        public string? Description { get; set; }

        [Column("task_createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow ;
        [Column("task_order")]
        public int Order {  get; set; }
        [Column("task_lastCompletedAt")]
        public DateTime? LastCompletedAt {  get; set; }

        [Column("task_status")]
        public Enums.Status.StatusEnum Status { get; set; } = Enums.Status.StatusEnum.Pending;

        [Column("task_complexity")]
        public TaskComplexityEnum Complexity { get; set; }

        [Column("challenge_id")]
        public Guid ChallengeId { get; set; }

        [ForeignKey(nameof(ChallengeId))]
        public virtual ChallengeEntity Challenge { get; set; }
        public ICollection<UserTaskCompletionEntity> UserTaskCompletions { get; set; } = new HashSet<UserTaskCompletionEntity>();
    }
}
