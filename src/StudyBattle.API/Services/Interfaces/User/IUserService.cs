using StudyBattle.API.Services.Interfaces.Generic;
using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Domain.Models.User;

namespace StudyBattle.API.Interfaces.User
{
    public interface  IUserService : IGenericService<UserEntity,UserCreateDTO,UserUpdateDTO,UserResponseDTO>
    {
        Task<UserResponseDTO> AddUserAsync(UserCreateDTO user);
        Task<bool> ExistsEmailAsync(string email);
    }
}

