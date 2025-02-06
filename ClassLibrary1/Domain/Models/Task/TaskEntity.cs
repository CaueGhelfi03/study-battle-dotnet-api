using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskSystem.Domain.Enums.Priority;
using TaskSystem.Domain.Enums.Status;

namespace TaskSystem.Domain.Models.Task
{
    [Table("Tasks")]
    public class TaskEntity
    {
        [Key]
        [Column("task_id")]
        public Guid Id { get; set; } = new Guid();

        [Column("task_name")]
        [Required]
        public string TaskName { get; set; }

        [Column("task_description")]
        public string Description { get; set; }

        [Column("task_createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow ;

        [Column("task_status")]
        public Enums.Status.TaskStatus Status { get; set; } = Enums.Status.TaskStatus.Pending;


        [Column("task_priority")]
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;


    }
}
