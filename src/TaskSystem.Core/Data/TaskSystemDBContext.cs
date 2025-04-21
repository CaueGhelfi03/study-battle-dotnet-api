using Microsoft.EntityFrameworkCore;
using TaskSystem.Core.Domain.Entities.Challenge;
using TaskSystem.Core.Domain.Entities.UserChallengeProgress;
using TaskSystem.Core.Domain.Entities.UserTaskCompletion;
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
        public DbSet<UserTaskCompletionEntity> UserTaskCompletions { get; set; }
        public DbSet<ChallengeUserProgressEntity> ChallengeUserProgress {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region User Relationships

            modelBuilder.Entity<UserEntity>()
                .HasMany(u => u.ChallengeUserProgress)
                .WithOne(cp => cp.User)
                .HasForeignKey(cp => cp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserEntity>()
                .HasMany(u => u.UserTaskCompletions)
                .WithOne(tc => tc.User)
                .HasForeignKey(tc => tc.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Challenge Relationships

            modelBuilder.Entity<ChallengeEntity>()
                .HasMany(c => c.Tasks)
                .WithOne(t => t.Challenge)
                .HasForeignKey(t => t.ChallengeId)
                .OnDelete(DeleteBehavior.Cascade);
            

            modelBuilder.Entity<ChallengeEntity>()
                .HasMany(c => c.ChallengeUserProgress)
                .WithOne(up => up.Challenge)
                .HasForeignKey(up => up.ChallengeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChallengeEntity>()
                .Property(x => x.status)
                .HasConversion<string>();

            modelBuilder.Entity<ChallengeEntity>()
                .Property(x => x.ChallengeComplexity)
                .HasConversion<string>();

            #endregion

            #region Task RelationShip

            modelBuilder.Entity<TaskEntity>()
                .HasMany(t => t.UserTaskCompletions)
                .WithOne(utc => utc.Task)
                .HasForeignKey(utc => utc.TaskId);

            #endregion

            modelBuilder.Entity<UserTaskCompletionEntity>()
                .Property(x => x.Status)
                .HasConversion<string>();

            modelBuilder.Entity<TaskEntity>()
                .Property(x => x.Complexity)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
