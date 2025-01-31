using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using TaskSystem.Domain.DTOs.UserDTO;
using TaskSystem.Domain.Mapper.User;
using TaskSystem.Domain.Models.User;
using TaskSystem.Repostories.Interfaces.UserRepository;
using TaskSystem.Repostories.UserRepository;
using TaskSystem.Services.Interfaces.ICommon;
using TaskSystem.Services.Interfaces.User;

namespace TaskSystem.Services.UserService
{
    public class UserService(IUserRepository _userRepository, IMapper mapper, ICommonService common) : IUserService
    {
        public async Task<UserResponseDTO> AddUserAsync(UserRequestDTO user)
        {
            try
            {
                if(user == null)
                {
                    throw new ArgumentException("User data cannot be null");
                }

                var emailValidation = common.IsValidEmail(user.Email);

                string hashedPassword = common.PasswordEncoder(user.UserPassword);

                var newUser = new UserRequestDTO
                {
                    Email = user.Email,
                    UserPassword = hashedPassword,
                    Name = user.Name
                };

                bool existsEmail = await _userRepository.ExistsEmailAsync(newUser.Email);

                if (!existsEmail){

                    var mappedUser = mapper.Map<UserEntity>(newUser);

                    var createdUser = await _userRepository.AddUserAsync(mappedUser);

                    var mappedUserDTO = mapper.Map<UserResponseDTO>(mappedUser);

                    return mappedUserDTO;
                }
                throw new Exception("An error ocurred while trying to create a new user.");
            }
            catch (Exception ex)
            {
                throw new BadHttpRequestException(ex.Message);
            }

        }
        public async Task<UserResponseDTO> UpdateUserAsync(UserRequestDTO user,Guid Id)
        {
            try
            {
                var userSearched = await _userRepository.GetByIdAsync(Id) ?? throw new DirectoryNotFoundException($"The user with id {Id} was not found");
                
                
                var userEntity = mapper.Map<UserEntity?>(userSearched);
                var updatedUser = await _userRepository.UpdateUserAsync(Id, userEntity);
                var mappedUser = mapper.Map<UserResponseDTO?>(updatedUser);
                
                return mappedUser;
               
            }catch(DirectoryNotFoundException ex)
            {
                throw new Exception($"Error retrieving user: {ex.Message}", ex);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<UserResponseDTO> GetByIdAsync(Guid Id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(Id) ?? throw new DirectoryNotFoundException($"The user with id {Id} was not found");
                var mappedUser = mapper.Map<UserResponseDTO>(user);

                return mappedUser;
            }
            catch (Exception ex)
            {
                throw new (ex.Message);
            }
        }
        public async Task<IEnumerable<UserResponseDTO>> GetAllAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                var mappedUsers = mapper.Map<IEnumerable<UserResponseDTO>>(users);
                return mappedUsers;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteUserAsync(Guid Id)
        {
            try
            {

                var user = await _userRepository.GetByIdAsync(Id) ?? throw new DirectoryNotFoundException($"The user with id {Id} was not found");
                await _userRepository.DeleteUserAsync(Id);
                return true;
               
            }catch (Exception ex) { 
                throw new Exception(ex.Message);
            }

        }
    }
}
