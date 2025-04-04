using Microsoft.EntityFrameworkCore;
using TaskSystem.Core.Domain.Entities.Challenge;
using TaskSystem.Core.Domain.Entities.Ranking;
using TaskSystem.Core.Domain.Entities.Score;
using TaskSystem.Core.Domain.Entities.UserChallengeProgress;
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
        public DbSet<UserProgressEntity> UserChallengeProgress { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserEntity>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<UserEntity>()
                .HasMany(u => u.UserProgress)
                .WithOne(up => up.User)
                .HasForeignKey(UserProgress => UserProgress.UserId);

            modelBuilder.Entity<ChallengeEntity>()
                .HasMany(c => c.UserProgress)
                .WithOne(up => up.Challenge)
                .HasForeignKey(UserProgress => UserProgress.UserId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
