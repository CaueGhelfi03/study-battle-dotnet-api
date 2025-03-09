using AutoMapper;
using StudyBattle.core.Domain.DTOs.ChallengeDTO;
using StudyBattle.core.Domain.Entities.Challenge;
using TaskSystem.core.Domain.DTOs.ChallengeDTO;
using TaskSystem.Domain.DTOs.TaskDTO;
using TaskSystem.Domain.DTOs.UserDTO;
using TaskSystem.Domain.Models.Task;
using TaskSystem.Domain.Models.User;

namespace TaskSystem.Domain.Mapper.User
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile() {

            #region Generic

            #endregion

            #region User

            CreateMap<UserEntity, UserResponseDTO>().ReverseMap();
            CreateMap<UserCreateDTO, UserEntity>().ReverseMap();



            #endregion

            #region Task

            CreateMap<TaskEntity, TaskResponseDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Challenge, opt => opt.MapFrom(src => src.Challenge));



            #endregion

            #region Challenge

            CreateMap<ChallengeEntity, ChallengeResponseDTO>().ReverseMap();
            CreateMap<ChallengeCreateDTO, ChallengeEntity>().ReverseMap();
            CreateMap<ChallengeUpdateDTO, ChallengeEntity>().ReverseMap();

            #endregion
        }

    }
}
