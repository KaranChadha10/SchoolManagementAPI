using API.DTOs;
using API.DTOs.User;
using API.DTOs.UserType;
using API.Entities;
using API.Filters;
using API.IRepositories;
using API.IServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;
namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserTypeRepository _userTypeRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUserTypeRepository userTypeRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _userTypeRepository = userTypeRepository;
            _mapper = mapper;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _userRepository.Dispose();
            }
        }

        public async Task<User> Authenticate(string email, string password)
        {
            try
            {

                var user = await _userRepository.GetAll().Include(x => x.UserType).Where(e => e.IsVerified == true).Where(e => e.IsActive == true).FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());

                if (user != null && !BC.Verify(password, user.Password))
                {
                    if (user != null)
                    {
                        var User = await _userRepository.GetById(user.Id);
                        _userRepository.Update(User);
                        await _userRepository.SaveChangesAsync();
                        
                    }
                    return user;
                }
                else if (user == null || !BC.Verify(password, user.Password))
                {
                    return null;
                }
                else
                {
                    var User = await _userRepository.GetById(user.Id);
                    if (User != null)
                    {
                        _userRepository.Update(User);
                        await _userRepository.SaveChangesAsync();
                    }
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GetUserDTO> CreateUser(CreateUserDTO DTO)
        {
            var usserExist = _userRepository.GetAll().Where(e => e.Email == DTO.Email);
            if (usserExist.Count() == 0)
            {
                var created = _userRepository.Add(_mapper.Map<User>(DTO));
                created.Password = BC.HashPassword(DTO.Password);
                await _userRepository.SaveChangesAsync();
                return _mapper.Map<GetUserDTO>(created);
            }
            return null;
        }

        public async Task<bool> DeleteUser(int id)
        {
            await _userRepository.Delete(id);
            return await _userRepository.SaveChangesAsync() > 0;
        }

        
        public async Task<PaginatedList<GetUserDTO>> GetAllUsers(UserFilter filter)
        {
            filter ??= new UserFilter();
            var users = _userRepository
                .GetAll().Include(x => x.UserType);
                //.Where(x=> x.UserType_Id != 0)
                //.WhereIf(filter.UserTypeId != null, x => x.UserTypeId == filter.UserTypeId)
                //.WhereIf(!string.IsNullOrEmpty(filter.Email), x => EF.Functions.Like(x.Email, $"%{filter.Email}%"));
            //.OrderByDescending(x=> x.Id);


            return await _mapper.ProjectTo<GetUserDTO>(users).ToPaginatedListAsync(filter.CurrentPage, filter.PageSize);
        }

        public async Task<PaginatedList<GetUserTypeDTO>> GetAllUserType(UserTypeFilter filter)
        {
            filter ??= new UserTypeFilter();
            var users = _userTypeRepository
                .GetAll();
                 //.WhereIf(filter.Type != null, x => x.Type == filter.Type);
            return await _mapper.ProjectTo<GetUserTypeDTO>(users).ToPaginatedListAsync(filter.CurrentPage, filter.PageSize);
        }

        public async Task<GetUserDTO> GetUserById(int id)
        {
            return _mapper.Map<GetUserDTO>(await _userRepository.GetById(id));

        }

        public async Task<GetUserDTO> GetUserTypeByUserId(int id)
        {
            var userDetail = await _userRepository.GetAll().Include(x => x.UserType).Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetUserDTO>(userDetail);
        }

        public async Task<GetUserDTO> UpdatePassword(int id, UpdatePasswordDTO DTO)
        {
            var originalUser = await _userRepository.GetById(id);
            if (originalUser == null) return null;

            originalUser.Password = BC.HashPassword(DTO.Password);
            _userRepository.Update(originalUser);
            await _userRepository.SaveChangesAsync();
            return _mapper.Map<GetUserDTO>(originalUser);
        }

        public async Task<GetUserDTO> UpdateUser(int id, UpdateUserDTO updateUserDTO)
        {
            var originalUser = await _userRepository.GetById(id);
            if (originalUser == null) return null;
            originalUser.Email = updateUserDTO.Email;
            //originalUser.Password = BC.HashPassword(updatedRole.Password);
            originalUser.FullName = updateUserDTO.FullName;
            originalUser.ModifiedAt = DateTime.UtcNow;
            originalUser.ModifiedBy = updateUserDTO.Modified_By;
            originalUser.IsActive = updateUserDTO.IsActive;
            originalUser.IsVerified = updateUserDTO.IsVerified;
            originalUser.UserTypeId = updateUserDTO.UserTypeId;
            _userRepository.Update(originalUser);
            await _userRepository.SaveChangesAsync();
            return _mapper.Map<GetUserDTO>(originalUser);
        }

        public async Task<GetUserDTO> UpdateUserByUserName(string userId)
        {
            long Id = Convert.ToInt32(userId);
            var originalUser = _userRepository.GetAll().Where(e => e.Id == Id).FirstOrDefault();
            if (originalUser == null) return null;
            originalUser.IsVerified = true;
            _userRepository.Update(originalUser);
            await _userRepository.SaveChangesAsync();
            return _mapper.Map<GetUserDTO>(originalUser);
        }
    }
}
