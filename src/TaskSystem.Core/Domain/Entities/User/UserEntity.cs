using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskSystem.Core.Domain.Entities.Challenge;
using TaskSystem.Core.Domain.Entities.UserChallengeProgress;
using TaskSystem.Core.Domain.Models.Task;

namespace TaskSystem.Core.Domain.Models.User
{
    [Table("User")]
    public class UserEntity
    {
        [Column("user_id")]
        [Key]
        public Guid Id { get; set; } = new Guid();

        [Column("user_name")]
        [Required]
        public string Name { get; set; }

        [Column("user_email")]
        [Required]
        public string Email { get; set; }

        [Column("user_password")]
        [Required]
        public string UserPassword {  get; set; }

        [Column("user_createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<UserProgressEntity> UserProgress = new HashSet<UserProgressEntity>();
        public ICollection<TaskEntity> Tasks = [];
    }
}
