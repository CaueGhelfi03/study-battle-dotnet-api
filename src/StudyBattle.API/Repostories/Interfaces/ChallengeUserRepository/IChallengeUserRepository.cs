using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using TaskSystem.Core.Domain.Entities.UserChallengeProgress;

namespace StudyBattle.API.Repostories.Interfaces.ChallengeUserRepository
{
    public interface IChallengeUserRepository : IGenericRepository<Guid,ChallengeUserProgressEntity>
    {
        public Task<ICollection<ChallengeUserProgressEntity>> GetUserProgressByChallengeId(Guid ChallengeId);
        public Task<ChallengeUserProgressEntity> GetUserProgressById (Guid UserId);
        public Task<ChallengeUserProgressEntity?> GetByUserAndChallengeId(Guid UserId, Guid ChallengeId);
    }
}
