using API.DTOs;
using API.DTOs.Subject;
using API.Filters;
using System.Threading.Tasks;

namespace API.IServices
{
    public interface ISubjectService
    {
        public Task<PaginatedList<GetSubjectDTO>> GetAllSubjectDetails(SubjectFilter subjectFilter);
        public Task<GetSubjectDTO> GetSubjectDetailById(int id);
        public Task<GetSubjectDTO> CreateSubjectDetail(CreateSubjectDTO subjectDto);
        public Task<GetSubjectDTO> UpdateSubjectDetail(int id, UpdateSubjectDTO updateSubjectDTO);
        public Task<bool> DeleteSubject(int id);
        void Dispose();
    }
}
