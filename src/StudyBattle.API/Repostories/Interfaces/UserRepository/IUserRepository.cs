using TaskSystem.Core.Domain.Models.User;

namespace TaskSystem.Repostories.Interfaces.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetAllAsync();
        Task<UserEntity> GetByIdAsync(Guid id);
        Task<UserEntity> AddUserAsync(UserEntity user);
        Task<UserEntity> UpdateUserAsync(Guid id, UserEntity user);
        Task<bool?> DeleteUserAsync(Guid id);
        Task<bool> ExistsEmailAsync(string email);

    }
}
