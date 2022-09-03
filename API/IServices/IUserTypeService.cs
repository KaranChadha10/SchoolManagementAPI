using API.DTOs;
using API.DTOs.UserType;
using API.Filters;
using System.Threading.Tasks;

namespace API.IServices
{
    public interface IUserTypeService
    {
        public Task<PaginatedList<GetUserTypeDTO>> GetAllUserTypeDetails(UserTypeFilter userTypeFilter);
        public Task<GetUserTypeDTO> GetUserTypeDetailById(int id);
        public Task<GetUserTypeDTO> CreateUserTypeDetail(CreateUserTypeDTO createUserTypeDTO);
        public Task<GetUserTypeDTO> UpdateUserTypeDetail(int id, UpdateUserTypeDTO updateUserTypeDTO);
        public Task<bool> DeleteUserType(int id);
        void Dispose();
    }
}
