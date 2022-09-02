using API.DTOs;
using API.DTOs.Department;
using API.Entities;
using API.Filters;
using API.IRepositories;
using API.IServices;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _departmentRepository = departmentRepository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _departmentRepository.Dispose();
        }
        public async Task<GetDepartmentDTO> CreateDepartmentDetail(CreateDepartmentDTO departmentDTO)
        {
            departmentDTO.CreatedAt = DateTime.UtcNow;
            var created = _departmentRepository.Add(_mapper.Map<Department>(departmentDTO));
            await _departmentRepository.SaveChangesAsync();
            return _mapper.Map<GetDepartmentDTO>(created);
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var originalDepartment = await _departmentRepository.GetById(id);
            if (originalDepartment == null) return false;
            originalDepartment.IsDeleted = true;

            _departmentRepository.Update(originalDepartment);
            return await _departmentRepository.SaveChangesAsync() > 0;
        }
        public async Task<PaginatedList<GetDepartmentDTO>> GetAllDepartmentDetails(DepartmentFilter departmentFilter)
        {
            departmentFilter ??= new DepartmentFilter();
            var result = _departmentRepository.GetAll();
            //.WhereIf(!string.IsNullOrEmpty(subjectFilter.Name), x => EF.Functions.Like(x.AccommodationType, $"%{filter.AccommodationType}%"));

            return await _mapper.ProjectTo<GetDepartmentDTO>(result).ToPaginatedListAsync(departmentFilter.CurrentPage, departmentFilter.PageSize);

        }

        public async Task<GetDepartmentDTO> GetDepartmentDetailById(int id)
        {
            return _mapper.Map<GetDepartmentDTO>(await _departmentRepository.GetById(id));
        }

        public async Task<GetDepartmentDTO> UpdateDepartmentDetail(int id, UpdateDepartmentDTO updatedepartmentDTO)
        {
            var originalDepartment = await _departmentRepository.GetById(id);
            if (originalDepartment == null) return null;

            originalDepartment.Name = updatedepartmentDTO.Name;
            originalDepartment.HOD = updatedepartmentDTO.HOD;
            originalDepartment.StartYear = updatedepartmentDTO.StartYear;
            originalDepartment.StudentsCount = updatedepartmentDTO.StudentsCount;
            originalDepartment.ModifiedAt = DateTime.UtcNow;
            //originalSubject.ModifiedBy = updateSubjectDTO.ModifiedBy;

            _departmentRepository.Update(originalDepartment);
            await _departmentRepository.SaveChangesAsync();
            return _mapper.Map<GetDepartmentDTO>(originalDepartment);
        }
    }
}
