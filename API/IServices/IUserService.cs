using API.DTOs;
using API.DTOs.User;
using API.DTOs.UserType;
using API.Entities;
using API.Filters;
using System;
using System.Threading.Tasks;

namespace API.IServices
{
    public interface IUserService : IDisposable
    {
        Task<User> Authenticate(string email, string password);

        Task<GetUserDTO> CreateUser(CreateUserDTO DTO);
        Task<bool> DeleteUser(int id);
        Task<GetUserDTO> UpdatePassword(int id, UpdatePasswordDTO DTO);
        Task<GetUserDTO> UpdateUser(int id, UpdateUserDTO DTO);

        //Task<GetUserProfileDTO> UserProfileUpdate(int id, UpdateUserProfileDTO DTO);
        Task<PaginatedList<GetUserDTO>> GetAllUsers(UserFilter filter);
        Task<GetUserDTO> GetUserById(int id);
        Task<GetUserDTO> GetUserTypeByUserId(int id);
        Task<PaginatedList<GetUserTypeDTO>> GetAllUserType(UserTypeFilter filter);
        Task<GetUserDTO> UpdateUserByUserName(string userName);
    }
}
