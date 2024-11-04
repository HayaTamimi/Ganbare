using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ganbare.src.Entity;
using ganbare.src.Repository;
using ganbare.src.Utils;
using static ganbare.src.DTO.UserDTO;

namespace ganbare.src.Services.user
{
    public class UserService : IUserService
    {
        protected readonly UserRepository _userRepo;
        protected readonly IMapper _mapper;
        protected readonly IConfiguration _config;

        public UserService(UserRepository userRepo, IMapper mapper, IConfiguration config)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _config = config;
        }

        public async Task<List<UserReadDto>> GetAllAsync()
        {
            var userList = await _userRepo.GetAllAsync();
            return _mapper.Map<List<User>, List<UserReadDto>>(userList);
        }

        public async Task<UserReadDto> GetByIdAsync(Guid id)
        {
            var foundUser = await _userRepo.GetByIdAsync(id);
            if (foundUser == null)
            {
                throw CustomException.NotFound($"There is no user with ID {id}.");
            }
            return _mapper.Map<User, UserReadDto>(foundUser);
        }

        public async Task<bool> DeleteOneAsync(Guid id)
        {
            var foundUser = await _userRepo.GetByIdAsync(id);
            if (foundUser == null)
            {
                throw CustomException.NotFound($"There is no user with ID {id}.");
            }
            try
            {
                bool isDeleted = await _userRepo.DeleteOneAsync(foundUser);
                return isDeleted;
            }
            catch (Exception ex)
            {
                throw CustomException.InternalError(
                    $"An error occurred while deleting the user with ID {id}: {ex.Message}"
                );
            }
        }

        public async Task<bool> UpdateOneAsync(Guid id, UserUpdateDto updateDto)
        {
            var foundUser = await _userRepo.GetByIdAsync(id);

            if (foundUser == null)
            {
                throw CustomException.NotFound($"There is no user with the ID {id} to update.");
            }

            _mapper.Map(updateDto, foundUser);
            return await _userRepo.UpdateOneAsync(foundUser);
        }

        public async Task<UserReadDto> CreateOneAsync(UserCreateDto createDto)
        {
            Password.HashPassword(createDto.Password, out string hashedPassword, out byte[] salt);

            var user = _mapper.Map<UserCreateDto, User>(createDto);
            user.Password = hashedPassword;
            user.Salt = salt;

            var savedUser = await _userRepo.CreateOneAsync(user);
            return _mapper.Map<User, UserReadDto>(savedUser);
        }
        public async Task<UserReadDto> CreateAdminAsync(UserCreateDto createDto)
        {
            Password.HashPassword(createDto.Password, out string hashedPassword, out byte[] salt);
            var user = _mapper.Map<UserCreateDto, User>(createDto);
            user.Password = hashedPassword;
            user.Salt = salt;
            //user.Role = Role.Admin;
            var savedUser = await _userRepo.CreateOneAsync(user);
            return _mapper.Map<User, UserReadDto>(savedUser);
        }

        public async Task<bool> UpdateAdminAsync(Guid userId)
        {
            var foundUser = await _userRepo.GetByIdAsync(userId);
            if (foundUser == null)
            {
                return false;
            }


            await _userRepo.UpdateOneAsync(foundUser);
            return true;

        }
        public async Task<UserReadDto> FindByEmailAsync(string email)
        {
            var foundUser = await _userRepo.FindByEmailAsync(email);
            if (foundUser == null)
            {
                throw CustomException.NotFound($"User with {email} is not found");
            }
            return _mapper.Map<User, UserReadDto>(foundUser);

        }
        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _userRepo.EmailExistsAsync(email);
        }

        //public static bool VerifyPassword(string plainPassword, byte[] salt, string hashedPassword)

        public async Task<string> SignInAsync(UserSigninDto createDto)
        {
            bool isMatched = false;
            //var foundUser = await _userRepo.FindByEmailAsync(createDto.Email);
            List<User> userList = await _userRepo.GetAllAsync();
            var foundUser = userList.FirstOrDefault(u => u.Email == createDto.Email);
            if (foundUser != null)
            {
                isMatched = Password.VerifyPassword(
                    createDto.Password,
                    foundUser.Salt,
                    foundUser.Password
                );

                if (isMatched)
                {
                    var token = new Token(_config);
                    return token.GnerateToken(foundUser);
                }
                throw CustomException.UnAuthorized(
                    $"Password for user with email {foundUser.Email} does not match!"
                );
            }
            else
            {
                throw CustomException.NotFound($"User with email {createDto.Email} not found.");
            }
        }
    }
}