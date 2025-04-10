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

        public async Task<ChallengeEntity> CreateChallengeAsync(ChallengeEntity challenge)
        {
            if (challenge == null) throw new ArgumentNullException(nameof(challenge));
            try
            {
                var newChallenge = await _context.AddAsync(challenge);
                await _context.SaveChangesAsync();
                return newChallenge.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

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

        public async Task<ICollection<ChallengeEntity>> GetChallengeWithUserProgressAsync(Guid Id)
        {
            return await _context.Challenges
                .Where(c => c.status != TaskSystem.Core.Domain.Enums.Status.StatusEnum.Completed && c.End_Date.Date != DateTime.Today)
                .Include(c => c.ChallengeUserProgress)
                .ToListAsync();
        }

        public async Task<ChallengeEntity> GetChallengeWithTasksById(Guid Id)
        {
            return await _context.Challenges
                .Include(c => c.Tasks)
                .FirstOrDefaultAsync(c => c.Id == Id);
        }
    }
}
