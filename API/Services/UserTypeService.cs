using API.DTOs;
using API.DTOs.UserType;
using API.Entities;
using API.Filters;
using API.IRepositories;
using API.IServices;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace API.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IMapper _mapper;
        private readonly IUserTypeRepository _userTypeRepository;

        public UserTypeService(IMapper mapper, IUserTypeRepository userTypeRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userTypeRepository = userTypeRepository;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _userTypeRepository.Dispose();
        }
        public async Task<GetUserTypeDTO> CreateUserTypeDetail(CreateUserTypeDTO createUserTypeDTO)
        {
            createUserTypeDTO.CreatedAt = DateTime.UtcNow;
            var created = _userTypeRepository.Add(_mapper.Map<UserType>(createUserTypeDTO));
            await _userTypeRepository.SaveChangesAsync();
            return _mapper.Map<GetUserTypeDTO>(created);

        }

        public async Task<PaginatedList<GetUserTypeDTO>> GetAllUserTypeDetails(UserTypeFilter userTypeFilter)
        {
            userTypeFilter ??= new UserTypeFilter();
            var result = _userTypeRepository.GetAll();
            //.WhereIf(!string.IsNullOrEmpty(subjectFilter.Name), x => EF.Functions.Like(x.AccommodationType, $"%{filter.AccommodationType}%"));

            return await _mapper.ProjectTo<GetUserTypeDTO>(result).ToPaginatedListAsync(userTypeFilter.CurrentPage, userTypeFilter.PageSize);

        }

        public async Task<GetUserTypeDTO> GetUserTypeDetailById(int id)
        {
            return _mapper.Map<GetUserTypeDTO>(await _userTypeRepository.GetById(id));
        }

        public async Task<GetUserTypeDTO> UpdateUserTypeDetail(int id, UpdateUserTypeDTO updateUserTypeDTO)
        {
            var originalUserType = await _userTypeRepository.GetById(id);
            if (originalUserType == null) return null;

            originalUserType.Type = updateUserTypeDTO.Type;
            originalUserType.ModifiedAt = DateTime.UtcNow;
            //originalSubject.ModifiedBy = updateSubjectDTO.ModifiedBy;

            _userTypeRepository.Update(originalUserType);
            await _userTypeRepository.SaveChangesAsync();
            return _mapper.Map<GetUserTypeDTO>(originalUserType);
        }
        public async Task<bool> DeleteUserType(int id)
        {
            var originalUserType = await _userTypeRepository.GetById(id);
            if (originalUserType == null) return false;
            originalUserType.IsDeleted = true;

            _userTypeRepository.Update(originalUserType);
            return await _userTypeRepository.SaveChangesAsync() > 0;
        }
    }
}
