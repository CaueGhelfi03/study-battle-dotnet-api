using AutoMapper;
using TaskSystem.Core.Domain.DTOs.TaskDTO;
using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Domain.Models.Task;
using TaskSystem.Core.Domain.Models.User;

namespace TaskSystem.Core.Domain.Mapper.User
{
    public class AutoMapperUserProfile : Profile
    {

        public AutoMapperUserProfile() {

            #region User

            CreateMap<UserEntity, UserResponseDTO>().ReverseMap();
            CreateMap<UserEntity, UserRequestDTO>().ReverseMap();
            CreateMap<UserEntity, UserUpdateDTO>().ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

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
