using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ganbare.src.DTO.UserDTO;

namespace ganbare.src.Services.user
{
    public interface IUserService
    {
        Task<UserReadDto> CreateOneAsync(UserCreateDto createDto);
        Task<List<UserReadDto>> GetAllAsync();
        Task<UserReadDto> GetByIdAsync(Guid id);
        Task<bool> DeleteOneAsync(Guid id);
        Task<bool> UpdateOneAsync(Guid id, UserUpdateDto updateDto);
        Task<string> SignInAsync(UserSigninDto userSigninDto);
        Task<UserReadDto> CreateAdminAsync(UserCreateDto createDto);
        Task<bool> UpdateAdminAsync(Guid id);
        Task<UserReadDto> FindByEmailAsync(string email);
        Task<bool> EmailExistsAsync(string email);



    }
}