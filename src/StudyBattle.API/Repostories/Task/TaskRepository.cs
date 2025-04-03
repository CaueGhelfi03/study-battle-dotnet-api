using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using StudyBattle.API.Repostories.Generic;
using System.Reflection.Metadata.Ecma335;
using TaskSystem.Core.Domain.Models.Task;
using TaskSystem.Repostories.Interfaces.TaskRepository;

namespace StudyBattle.API.Repostories.Task
{
    public class TaskRepository : GenericRepository<Guid,TaskEntity>, ITaskRepository
    {

        public TaskRepository(TaskSystemDBContext dbContext) : base(dbContext) 
        {
        }

        public async Task<ICollection<TaskEntity>> GetTasksByChallengeIdAsync(Guid challengeId)
        {
            return await _context.Tasks.Where(x => x.ChallengeId == challengeId).ToListAsync();
        }

        public async Task<ICollection<TaskEntity>> GetTasksByUserIdAsync(Guid userId)
        {
            return await _context.Tasks.Where(x => x.UserId == userId).ToListAsync();
        }



    }
}
