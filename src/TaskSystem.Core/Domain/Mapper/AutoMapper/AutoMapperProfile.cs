using AutoMapper;
using TaskSystem.Core.Domain.DTOs.ChallengeDTO;
using TaskSystem.Core.Domain.Entities.Challenge;
using TaskSystem.Core.Domain.DTOs.TaskDTO;
using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Domain.Models.Task;
using TaskSystem.Core.Domain.Models.User;
using TaskSystem.Core.Domain.Entities.UserChallengeProgress;
using TaskSystem.Core.Domain.DTOs.ChallengeUserDTO;
using TaskSystem.Core.Domain.Entities.UserTaskCompletion;
using TaskSystem.Core.Domain.DTOs.UserTaskCompletationDTO;
using TaskSystem.Core.Domain.DTOs.UserTaskDTO;

namespace TaskSystem.Core.Domain.Mapper.User
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {

            #region Generic

            #endregion

            #region User

            CreateMap<UserEntity, UserResponseDTO>().ReverseMap();
            CreateMap<UserEntity, UserCreateDTO>().ReverseMap();
            CreateMap<UserEntity, UserUpdateDTO>().ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UserCreateDTO, UserEntity>().ReverseMap();
            CreateMap<UserEntity, UserBasicDTO>().ReverseMap();

            #endregion

            #region Task

            CreateMap<TaskResponseDTO, TaskEntity>().ReverseMap()
                .ForMember(dest => dest.ChallengeId, opt => opt.MapFrom(src=> src.ChallengeId));
            CreateMap<TaskCreateDTO, TaskEntity>().ReverseMap();

            #endregion

            #region Challenge

            CreateMap<ChallengeResponseDTO, ChallengeEntity>().ReverseMap();
            CreateMap<ChallengeCreateDTO, ChallengeEntity>().ReverseMap();
            CreateMap<ChallengeUpdateDTO, ChallengeEntity>().ReverseMap();
            CreateMap<ChallengeTaskResponseDTO, ChallengeEntity>().ReverseMap()
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));
            CreateMap<ChallengeUserResponseDTO, ChallengeEntity>().ReverseMap();

            #endregion

            #region ChallengeUser

            CreateMap<UserProgressResponseDTO, ChallengeUserProgressEntity>().ReverseMap();

            CreateMap<ChallengeUserResponseDTO, ChallengeUserProgressEntity>().ReverseMap()
                .ForPath(src => src.Challenge.Id, opt => opt.MapFrom(dest => dest.ChallengeId));
            CreateMap<ChallengeUserCreateDTO, ChallengeUserProgressEntity>().ReverseMap();
            CreateMap<ChallengeUserUpdateDTO, ChallengeUserProgressEntity>().ReverseMap();

            CreateMap<ChallengeResponseDTO, ChallengeUserResponseDTO>().ReverseMap();
            CreateMap<UserProgressResponseDTO, UserProgressResponseDTO>().ReverseMap();
            CreateMap<UserProgressResponseDTO, ChallengeUserResponseDTO>().ReverseMap();



            #endregion

            #region UserTask

            CreateMap<UserTaskResponseDTO, UserTaskCompletionEntity>().ReverseMap();
            CreateMap<UserCreateDTO, UserTaskCompletionEntity>().ReverseMap();
            CreateMap<UserUpdateDTO, UserTaskCompletionEntity>().ReverseMap();
            CreateMap<UserAllTasksDTO, UserTaskCompletionEntity>().ReverseMap();

            #endregion
        }
    }
}
