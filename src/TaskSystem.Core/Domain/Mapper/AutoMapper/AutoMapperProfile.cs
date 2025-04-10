using AutoMapper;
using TaskSystem.Core.Domain.DTOs.ChallengeDTO;
using TaskSystem.Core.Domain.Entities.Challenge;
using TaskSystem.Core.Domain.DTOs.TaskDTO;
using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Domain.Models.Task;
using TaskSystem.Core.Domain.Models.User;

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

            CreateMap<TaskEntity, TaskResponseDTO>().ReverseMap();
            CreateMap<TaskEntity, TaskCreateDTO>().ReverseMap();


            #endregion

            #region Challenge

            CreateMap<ChallengeEntity, ChallengeResponseDTO>().ReverseMap();
            CreateMap<ChallengeCreateDTO, ChallengeEntity>().ReverseMap();
            CreateMap<ChallengeUpdateDTO, ChallengeEntity>().ReverseMap();
            CreateMap<ChallengeTaskResponseDTO, ChallengeEntity>().ReverseMap()
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));
                

            #endregion
        }
    }
}
