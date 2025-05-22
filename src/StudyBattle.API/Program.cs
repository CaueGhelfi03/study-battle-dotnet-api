
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
using StudyBattle.API.Repostories.Interfaces.ChallengeUserRepository;
using StudyBattle.API.Repostories.ChallengeUserProgress;
using StudyBattle.API.Services.Interfaces.ChallengeUser;
using StudyBattle.API.Services.ChallengeUserProgress;
using StudyBattle.API.Repostories.Interfaces.UserTaskRepository;
using StudyBattle.API.Services.UserTaskCompletation;
using StudyBattle.API.Services.Interfaces.UserTaskCompletation;
using StudyBattle.API.Repostories.UserTaskCompletation;
using AutoMapper;
using StudyBattle.API.Services.Interfaces.TaskScoreCount;
using StudyBattle.API.Services.TaskScoreCount;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using StudyBattle.API.Services.Interfaces.IAuthService;
using StudyBattle.API.Services.Authentication;

namespace SistemaDeTarefas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddDbContext<TaskSystemDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            #region Services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserTaskService, UserTaskService>();
            services.AddScoped<IChallengeService, ChallengeService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IChallengeUserService, ChallengeUserService>();
            services.AddSingleton<ICommonService, CommonService>();
            services.AddSingleton<ITaskScoreCountService, TaskScoreCountService>();
            services.AddTransient(typeof(IGenericService<,,,,>), typeof(GenericService<,,,,>));

            #endregion

            #region Authentication

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            #endregion

            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTaskRepository, UserTaskRepository>();
            services.AddScoped<IChallengeRepository, ChallengeRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IChallengeUserRepository, ChallengeUserRepository>();
            services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

            #endregion


            #region Configuration HTTP

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseAuthentication();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            #endregion

            app.Run();
        }
    }
}
