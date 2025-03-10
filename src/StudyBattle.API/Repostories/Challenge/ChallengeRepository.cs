using SistemaDeTarefas.Data;
using StudyBattle.API.Repostories.Interfaces.ChallengeRepository;
using TaskSystem.Core.Domain.Entities.Challenge;

namespace StudyBattle.API.Repostories.Challenge
{
    public class ChallengeRepository : IChallengeRepository
    {
        private readonly TaskSystemDBContext _dbContext;

        public ChallengeRepository(TaskSystemDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public Task<ChallengeEntity> CreateAsync(ChallengeEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ChallengeEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ChallengeEntity> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ChallengeEntity> UpdateAsync(Guid id, ChallengeEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
