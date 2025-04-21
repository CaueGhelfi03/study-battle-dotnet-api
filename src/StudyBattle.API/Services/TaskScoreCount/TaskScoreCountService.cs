using StudyBattle.API.Services.Interfaces.TaskScoreCount;
using TaskSystem.Core.Domain.Enums.TaskComplexity;
using TaskSystem.Core.Domain.Enums.WeekStreak;
using System.Threading.Tasks;

namespace StudyBattle.API.Services.TaskScoreCount
{
    public class TaskScoreCountService : ITaskScoreCountService
    {
        public int GetScore(TaskComplexityEnum complexity, int streak)
        {
            var baseScore = (int)complexity;
            var streakMultiplier = (double)(int)streak / 100; 

            var finalScore = (int)(baseScore * streakMultiplier); 

            return finalScore;
        }
    }
}
