using TaskSystem.Domain.Models.Task;

namespace TaskSystem.Domain.DTOs.UserDTO
{
    public record UserResponseDTO
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<TaskEntity> Tasks { get; set; }

    }
}
