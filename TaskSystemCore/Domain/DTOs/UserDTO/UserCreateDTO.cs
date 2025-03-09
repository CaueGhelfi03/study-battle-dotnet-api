namespace TaskSystem.Domain.DTOs.UserDTO
{
    public record UserCreateDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }
        public string UserPassword { get; set; }
    }
}
