using StudyBattle.core.Domain.DTOs.UserDTO;

namespace StudyBattle.core.Domain.DTOs.RankingDTO
{
    public record RankingCreateDTO
    {
        public Guid IdRanking { get; set; }
        public Guid ChallengeId { get; set; }
        public string ChallengeName { get; set; }
        public DateTime CreatedAt { get; set; }
        
        // Futuramente inserir paginação: Page / PageSize / OrderBy (Desc/asc)


    }
}
