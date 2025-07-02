﻿using AutoMapper;
using StudyBattle.API.Interfaces.ICommon;
using StudyBattle.API.Interfaces.User;
using StudyBattle.API.Repostories.Interfaces.GenericRepository;
using StudyBattle.API.Services.Generic;
using TaskSystem.Core.Domain.DTOs.UserDTO;
using TaskSystem.Core.Domain.Models.User;
using TaskSystem.Repostories.Interfaces.UserRepository;

namespace StudyBattle.API.UserService
{
    public class UserService : GenericService<Guid, UserEntity, UserCreateDTO, UserUpdateDTO, UserResponseDTO>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICommonService _commonService;

        public UserService(
            IGenericRepository<Guid, UserEntity> repository,
            IMapper mapper,
            IUserRepository userRepository,
            ICommonService commonService
        ) : base(repository, mapper)
        {
            _userRepository = userRepository;
            _commonService = commonService;
        }

        // Método específico para User
        public async Task<UserResponseDTO> AddUserAsync(UserCreateDTO user)
        {
            try
            {
                if (user is null)
                    throw new ArgumentException("User data cannot be null");

                var isValidEmail = user.ValidateEmail();

                if (!isValidEmail)
                    throw new ArgumentException("Invalid email format");

                bool emailExists = await _userRepository.ExistsEmailAsync(user.Email);

                if (emailExists)
                    throw new ArgumentException("There is already a user with this email");

                string hashedPassword = _commonService.PasswordEncoder(user.UserPassword);

                var newUser = new UserCreateDTO
                {
                    Email = user.Email,
                    UserPassword = hashedPassword,
                    Name = user.Name
                };

                return await CreateAsync(newUser);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the user.", ex);
            }
        }

        public async Task<bool> ExistsEmailAsync(string email)
        {
            return await _userRepository.ExistsEmailAsync(email);
        }

        public async Task<UserResponseDTO> GetByEmail(string email)
        {
            try
            {
                var user = await _userRepository.GetByEmail(email);

                var mappedUser = _mapper.Map<UserResponseDTO>(user);

                return mappedUser;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);

            }
        }
    }
}