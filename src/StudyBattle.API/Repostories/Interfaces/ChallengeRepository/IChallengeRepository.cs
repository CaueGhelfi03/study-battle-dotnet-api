using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using TaskSystem.Core.Domain.DTOs.ChallengeDTO;
using TaskSystem.Core.Domain.Entities.Challenge;

namespace StudyBattle.API.Repostories.Interfaces.ChallengeRepository
{
    public interface IChallengeRepository : IGenericRepository<Guid,ChallengeEntity>
    {

    }
}
