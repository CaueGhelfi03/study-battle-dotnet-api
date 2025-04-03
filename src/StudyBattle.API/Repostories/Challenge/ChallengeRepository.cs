using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using StudyBattle.API.Repostories.Generic;
using StudyBattle.API.Repostories.Interfaces.ChallengeRepository;
using TaskSystem.Core.Domain.DTOs.ChallengeDTO;
using TaskSystem.Core.Domain.Entities.Challenge;

namespace StudyBattle.API.Repostories.Challenge
{
    public class ChallengeRepository : GenericRepository<Guid,ChallengeEntity>, IChallengeRepository
    {
        public ChallengeRepository(TaskSystemDBContext dBContext) : base(dBContext)
        {
        }

        public async Task<ChallengeEntity> CreateAsync(ChallengeEntity entity)
        {
            return await base.CreateAsync(entity);
        }

        public async Task<bool?> DeleteAsync(Guid id)
        {
            return await base.DeleteAsync(id);
        }

        public async Task<IEnumerable<ChallengeEntity>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }

        public async Task<ChallengeEntity> GetByIdAsync(Guid id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<ChallengeEntity> UpdateAsync(Guid id, ChallengeEntity entity)
        {
            return await base.UpdateAsync(id, entity);
        }
    }
}
