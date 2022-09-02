using API.DTOs;
using API.DTOs.Department;
using API.Filters;
using System.Threading.Tasks;

namespace API.IServices
{
    public interface IDepartmentService
    {
        public Task<PaginatedList<GetDepartmentDTO>> GetAllDepartmentDetails(DepartmentFilter departmentFilter);
        public Task<GetDepartmentDTO> GetDepartmentDetailById(int id);
        public Task<GetDepartmentDTO> CreateDepartmentDetail(CreateDepartmentDTO departmentDTO);
        public Task<GetDepartmentDTO> UpdateDepartmentDetail(int id, UpdateDepartmentDTO updatedepartmentDTO);
        public Task<bool> DeleteDepartment(int id);
        void Dispose();
    }
}
