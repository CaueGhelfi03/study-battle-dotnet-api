
namespace TaskSystem.Domain.DTOs.TaskDTO
{
    public record TaskRequestDTO
    {
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } =  DateTime.UtcNow;

        public Enums.Status.StatusEnum Status { get; set; }
    }
}
