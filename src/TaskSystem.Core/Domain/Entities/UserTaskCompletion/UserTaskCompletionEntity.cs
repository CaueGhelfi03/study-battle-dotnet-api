using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSystem.Core.Domain.Entities.Challenge;
using TaskSystem.Core.Domain.Entities.UserChallengeProgress;
using TaskSystem.Core.Domain.Enums.Status;
using TaskSystem.Core.Domain.Models.Task;
using TaskSystem.Core.Domain.Models.User;

namespace TaskSystem.Core.Domain.Entities.UserTaskCompletion
{
    [Table("UserTaskCompletion")]
    public class UserTaskCompletionEntity
    {
        [Key]
        [Column("completion_id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("completion_date")]
        public DateTime CompletionDate { get; set; } = DateTime.UtcNow;

        [Column("completion_score")] 
        public int Score { get; set; }

        [Column("status")]
        public StatusEnum Status { get; set; } = StatusEnum.Completed;

        [Column("user_id")]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual UserEntity User { get; set; }

        [Column("task_id")]
        public Guid TaskId { get; set; }

        [ForeignKey(nameof(TaskId))]
        public virtual TaskEntity Task { get; set; }
    }
}
