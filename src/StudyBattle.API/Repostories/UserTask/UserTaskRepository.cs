using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using StudyBattle.API.Repostories.Generic;
using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using StudyBattle.API.Repostories.Interfaces.UserTaskRepository;
using TaskSystem.Core.Domain.Entities.UserTaskCompletion;
using TaskSystem.Core.Domain.Models.User;

namespace StudyBattle.API.Repostories.UserTaskCompletation
{
    public class UserTaskRepository : GenericRepository<Guid, UserTaskCompletionEntity>, IUserTaskRepository
    {
        public UserTaskRepository(TaskSystemDBContext context) : base(context) { }

        public async Task<List<UserTaskCompletionEntity>> GetAllTaskCompletationByUser(Guid UserId)
        {
            return await _context.UserTaskCompletions
                .Include(u => u.User)
                .Include(u => u.Task)
                .Where(u => u.UserId == UserId)
                .ToListAsync();                
        }
    }
}
