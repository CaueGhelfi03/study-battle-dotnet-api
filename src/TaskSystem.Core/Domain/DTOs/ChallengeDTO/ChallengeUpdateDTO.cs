namespace TaskSystem.Core.Domain.DTOs.ChallengeDTO
{
    public record ChallengeUpdateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }

    }
}
