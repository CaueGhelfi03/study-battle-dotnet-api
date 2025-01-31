using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using TaskSystem.Domain.DTOs.UserDTO;
using TaskSystem.Domain.Mapper.User;
using TaskSystem.Domain.Models.User;
using TaskSystem.Repostories.Interfaces.UserRepository;

namespace TaskSystem.Repostories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContext _dbContext;

        public UserRepository(TaskSystemDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        
        public async Task<bool> ExistsEmailAsync(string email)
        {
            var userSearched =  await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (userSearched is not null) throw new ArgumentException("There is already a user with this email");

            return false;
        }
        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<UserEntity> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<UserEntity> AddUserAsync(UserEntity user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<UserEntity> UpdateUserAsync(Guid id, UserEntity user)
        {
            UserEntity userById = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

                user.Name = userById.Name;
                user.Email = userById.Email;
                _dbContext.Users.Update(userById);
                return userById;
        }
        public async Task<bool> DeleteUserAsync(Guid id)
        {
            UserEntity userById = await GetByIdAsync(id);
                _dbContext.Users.Remove(userById);
                await _dbContext.SaveChangesAsync();
                return true;
        }
    }
}
