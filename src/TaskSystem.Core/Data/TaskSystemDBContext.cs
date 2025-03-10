using Microsoft.EntityFrameworkCore;
using TaskSystem.Core.Domain.Entities.Challenge;
using TaskSystem.Core.Domain.Entities.Ranking;
using TaskSystem.Core.Domain.Entities.Score;
using TaskSystem.Core.Domain.Models.Task;
using TaskSystem.Core.Domain.Models.User;

namespace SistemaDeTarefas.Data
{
    public class TaskSystemDBContext : DbContext
    {
        public TaskSystemDBContext(DbContextOptions<TaskSystemDBContext> options) : base(options)
        {   
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<ChallengeEntity> Challenges { get; set; }
        public DbSet<RankingEntity> Rankings { get; set; }
        public DbSet<ScoreEntity> Scores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
