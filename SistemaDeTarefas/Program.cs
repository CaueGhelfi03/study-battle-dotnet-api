
using SistemaDeTarefas.Data;
using TaskSystem.Domain.Mapper.User;
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
            builder.Services.AddAutoMapper(typeof(AutoMapperUserProfile));

            #region Services
            builder.Services.AddDbContext<TaskSystemDBContext>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<ICommonService, CommonService>();
            #endregion


            #region Repositories


            builder.Services.AddTransient<IUserRepository, UserRepository>();

           

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
