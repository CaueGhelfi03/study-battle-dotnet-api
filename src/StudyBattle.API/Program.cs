
using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using StudyBattle.API.Repostories.Generic;
using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using StudyBattle.API.Services.Challenge;
using StudyBattle.API.Services.Generic;
using StudyBattle.API.Services.Interfaces.Challenge;
using StudyBattle.API.Services.Interfaces.Generic;
using TaskSystem.Core.Domain.Mapper.User;
using TaskSystem.Repostories.Interfaces.UserRepository;
using TaskSystem.Repostories.UserRepository;
using StudyBattle.API.Common;
using StudyBattle.API.Interfaces.ICommon;
using StudyBattle.API.Interfaces.User;
using StudyBattle.API.UserService;
using StudyBattle.API.Repostories.Interfaces.ChallengeRepository;
using StudyBattle.API.Repostories.Challenge;
using TaskSystem.Repostories.Interfaces.TaskRepository;
using StudyBattle.API.Repostories.Task;
using StudyBattle.API.Services.Interfaces.Task;
using StudyBattle.API.Services.Task;

namespace SistemaDeTarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddDbContext<TaskSystemDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            #region Services
            builder.Services.AddDbContext<TaskSystemDBContext>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IChallengeService, ChallengeService>();
            builder.Services.AddTransient<ITaskService, TaskService>();
            builder.Services.AddTransient<ICommonService, CommonService>();
            builder.Services.AddTransient(typeof(IGenericService<,,,,>), typeof(GenericService<,,,,>));
            #endregion


            #region Repositories

            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IChallengeRepository, ChallengeRepository>();
            builder.Services.AddTransient<ITaskRepository, TaskRepository>();
            builder.Services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));



            #endregion


            #region Configuration HTTP
            var app = builder.Build();

            // Configure the HTTP request pipeline.
                app.UseSwagger();
                app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            #endregion

            app.Run();
        }
    }
}
