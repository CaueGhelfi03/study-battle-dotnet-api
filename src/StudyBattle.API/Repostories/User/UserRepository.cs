using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using StudyBattle.API.Repostories.Generic;
using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using System.Runtime.CompilerServices;
using TaskSystem.Core.Domain.Models.User;
using TaskSystem.Repostories.Interfaces.UserRepository;

namespace TaskSystem.Repostories.UserRepository
{
    public class UserRepository : GenericRepository<Guid, UserEntity>, IUserRepository 
    {

        public UserRepository(TaskSystemDBContext dBContext) : base(dBContext)
        {
        }
        public async Task<bool> ExistsEmailAsync(string email)
        {
            var userSearched = await base._entities.FirstOrDefaultAsync(x => x.Email == email);
            if (userSearched is not null) throw new ArgumentException("There is already a user with this email");

            return false;
        }

        public async Task<UserEntity> GetByEmail(string email)
        {
            var user = await base._entities.FirstOrDefaultAsync(x => x.Email.Equals(email));

            return user;

        }
    }
}
