using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using StudyBattle.API.Repostories.Generic;
using StudyBattle.API.Repostories.Interfaces.ChallengeUserRepository;
using TaskSystem.Core.Domain.Entities.UserChallengeProgress;

namespace StudyBattle.API.Repostories.ChallengeUserProgress
{
    public class ChallengeUserRepository : GenericRepository<Guid, ChallengeUserProgressEntity>, IChallengeUserRepository
    {
        private readonly TaskSystemDBContext _context;
        public ChallengeUserRepository(TaskSystemDBContext context) : base(context) {

            _context = context;
        }

        public async Task<ChallengeUserProgressEntity?> GetByUserAndChallengeId(Guid UserId, Guid ChallengeId)
        {
            return await _context.ChallengeUserProgress
                .FirstOrDefaultAsync(c => c.UserId == UserId && c.ChallengeId == ChallengeId);
        }

        public async Task<ICollection<ChallengeUserProgressEntity>> GetUserProgressByChallengeId(Guid ChallengeId)
        {
            return await _context.ChallengeUserProgress
                .Include(c => c.User)
                .Where(u => u.ChallengeId == ChallengeId)
                .ToListAsync();
        }

        public async Task<ChallengeUserProgressEntity> GetUserProgressById (Guid UserId)
        {
            return await _context.ChallengeUserProgress
                .FirstAsync(c => c.User.Id == UserId);
        }
    }
}
