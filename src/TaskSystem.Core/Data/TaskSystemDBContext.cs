using Microsoft.EntityFrameworkCore;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
