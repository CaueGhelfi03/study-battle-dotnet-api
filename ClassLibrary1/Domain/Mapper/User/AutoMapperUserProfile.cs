using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TaskSystem.Domain.DTOs.UserDTO;
using TaskSystem.Domain.Models.User;

namespace TaskSystem.Domain.Mapper.User
{
    public class AutoMapperUserProfile : Profile
    {

        public AutoMapperUserProfile() {

            CreateMap<UserEntity, UserResponseDTO>().ReverseMap();
        }

    }
}
