using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using TaskSystem.Core.Domain.Models.User;

namespace TaskSystem.Repostories.Interfaces.UserRepository
{
    public interface IUserRepository : IGenericRepository<Guid, UserEntity>
    {
        Task<bool> ExistsEmailAsync(string email);
        Task<UserEntity> GetByEmail(string email);
    }
}
