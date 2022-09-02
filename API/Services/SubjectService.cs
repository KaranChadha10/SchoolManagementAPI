using API.DTOs;
using API.DTOs.Subject;
using API.Entities;
using API.Filters;
using API.IRepositories;
using API.IServices;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace API.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;


        public SubjectService(IMapper mapper,ISubjectRepository subjectRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _subjectRepository = subjectRepository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _subjectRepository.Dispose();
        }

        public async Task<PaginatedList<GetSubjectDTO>> GetAllSubjectDetails(SubjectFilter subjectFilter)
        {
            subjectFilter ??= new SubjectFilter();
            var result = _subjectRepository.GetAll();
                //.WhereIf(!string.IsNullOrEmpty(subjectFilter.Name), x => EF.Functions.Like(x.AccommodationType, $"%{filter.AccommodationType}%"));

            return await _mapper.ProjectTo<GetSubjectDTO>(result).ToPaginatedListAsync(subjectFilter.CurrentPage, subjectFilter.PageSize);
        }

        public async Task<GetSubjectDTO> GetSubjectDetailById(int id)
        {
            return _mapper.Map<GetSubjectDTO>(await _subjectRepository.GetById(id));
        }

        public async Task<GetSubjectDTO> CreateSubjectDetail(CreateSubjectDTO subjectDto)
        {
            subjectDto.CreatedAt = DateTime.UtcNow;
            var created = _subjectRepository.Add(_mapper.Map<Subject>(subjectDto));
            await _subjectRepository.SaveChangesAsync();
            return _mapper.Map<GetSubjectDTO>(created);
        }
        public async Task<GetSubjectDTO> UpdateSubjectDetail(int id, UpdateSubjectDTO updateSubjectDTO)
        {
            var originalSubject = await _subjectRepository.GetById(id);
            if (originalSubject == null) return null;

            originalSubject.Name = updateSubjectDTO.Name;
            originalSubject.SubjectClass = updateSubjectDTO.SubjectClass;
            originalSubject.ModifiedAt = DateTime.UtcNow;
            //originalSubject.ModifiedBy = updateSubjectDTO.ModifiedBy;

            _subjectRepository.Update(originalSubject);
            await _subjectRepository.SaveChangesAsync();
            return _mapper.Map<GetSubjectDTO>(originalSubject);
        }
        public async Task<bool> DeleteSubject(int id)
        {
            var originalSubject = await _subjectRepository.GetById(id);
            if (originalSubject == null) return false;
            originalSubject.IsDeleted = true;

            _subjectRepository.Update(originalSubject);
            return await _subjectRepository.SaveChangesAsync() > 0;
        }
    }
}
