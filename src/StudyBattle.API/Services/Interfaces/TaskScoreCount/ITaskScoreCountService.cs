using TaskSystem.Core.Domain.Enums.TaskComplexity;
using TaskSystem.Core.Domain.Enums.WeekStreak;

namespace StudyBattle.API.Services.Interfaces.TaskScoreCount
{
    public interface ITaskScoreCountService
    {
        public int GetScore(TaskComplexityEnum complexity, int streak);

    }
}
