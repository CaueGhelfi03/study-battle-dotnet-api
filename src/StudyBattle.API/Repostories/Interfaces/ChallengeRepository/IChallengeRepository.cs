using TaskSystem.Core.Domain.Entities.Challenge;

namespace StudyBattle.API.Repostories.Interfaces.ChallengeRepository
{
    public interface IChallengeRepository
    {
        Task<ChallengeEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<ChallengeEntity>> GetAllAsync();
        Task<ChallengeEntity> CreateAsync(ChallengeEntity entity);
        Task<ChallengeEntity> UpdateAsync(Guid id, ChallengeEntity entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
