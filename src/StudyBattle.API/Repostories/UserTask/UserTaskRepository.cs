using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using StudyBattle.API.Repostories.Generic;
using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using StudyBattle.API.Repostories.Interfaces.UserTaskRepository;
using TaskSystem.Core.Domain.Entities.UserTaskCompletion;

namespace StudyBattle.API.Repostories.UserTaskCompletation
{
    public class UserTaskRepository : GenericRepository<Guid, UserTaskCompletionEntity>, IUserTaskRepository
    {
        public UserTaskRepository(TaskSystemDBContext context) : base(context) { }

        public async Task<ICollection<UserTaskCompletionEntity>> GetAllTaskCompletationByUser(Guid UserId)
        {
           var user = await _context.Users.FindAsync(UserId);
            if (user == null) throw new Exception("User not found");

            return await _context.UserTaskCompletions
                .Include(u => u.User.UserTaskCompletions)
                .Where(userTask => userTask.UserId == UserId)
                .ToListAsync();
        }
    }
}
