
using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using StudyBattle.api.Repostories.Generic;
using StudyBattle.api.Repostories.Interfaces.GenericRepository;
using StudyBattle.api.Services.Challenge;
using StudyBattle.api.Services.Generic;
using StudyBattle.api.Services.Interfaces.Challenge;
using StudyBattle.api.Services.Interfaces.Generic;
using TaskSystem.Domain.Mapper.User;
using TaskSystem.Domain.Models.Task;
using TaskSystem.Repostories.Interfaces.UserRepository;
using TaskSystem.Repostories.UserRepository;
using TaskSystem.Services.Common;
using TaskSystem.Services.Interfaces.ICommon;
using TaskSystem.Services.Interfaces.User;
using TaskSystem.Services.UserService;

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
            builder.Services.AddScoped(typeof(GenericService<,,,>));

            #region Services
            builder.Services.AddDbContext<TaskSystemDBContext>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IChallengeService, ChallengeService>();
            builder.Services.AddTransient<ICommonService, CommonService>();
            builder.Services.AddTransient(typeof(IGenericService<,,,>), typeof(GenericService<,,,>));
            #endregion


            #region Repositories


            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

           

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
