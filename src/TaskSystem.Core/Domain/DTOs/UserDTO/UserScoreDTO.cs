namespace TaskSystem.Core.Domain.DTOs.UserDTO
{
    public record UserScoreDTO
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int TotalScore { get; set; }
    }
}
