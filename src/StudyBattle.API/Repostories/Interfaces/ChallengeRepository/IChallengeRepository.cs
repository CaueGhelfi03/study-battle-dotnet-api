using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using TaskSystem.Core.Domain.DTOs.ChallengeDTO;
using TaskSystem.Core.Domain.Entities.Challenge;

namespace StudyBattle.API.Repostories.Interfaces.ChallengeRepository
{
    public interface IChallengeRepository : IGenericRepository<Guid,ChallengeEntity>
    {
        public Task<ICollection<ChallengeEntity>> GetChallengeWithUserProgressAsync(Guid Id);
        public Task<ChallengeEntity> CreateChallengeAsync(ChallengeEntity challenge);
        public Task<ChallengeEntity> GetChallengeWithTasksById(Guid Id);
        public Task<ICollection<ChallengeEntity>> GetAllChallengeBySubject(string subject);
    }
}
