using AutoMapper;
using TaskSystem.Domain.DTOs.TaskDTO;
using TaskSystem.Domain.DTOs.UserDTO;
using TaskSystem.Domain.Models.Task;
using TaskSystem.Domain.Models.User;

namespace TaskSystem.Domain.Mapper.User
{
    public class AutoMapperUserProfile : Profile
    {

        public AutoMapperUserProfile() {

            #region User

            CreateMap<UserEntity, UserResponseDTO>().ReverseMap();

            #endregion

            #region Task

            CreateMap<TaskEntity, TaskResponseDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Challenge, opt => opt.MapFrom(src => src.Challenge));



            #endregion

            #region Challenge

            #endregion
        }

    }
}
