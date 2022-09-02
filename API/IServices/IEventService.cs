using API.DTOs;
using API.DTOs.Event;
using API.Filters;
using System.Threading.Tasks;

namespace API.IServices
{
    public interface IEventService
    {
        public Task<PaginatedList<GetEventDTO>> GetAllEventDetails(EventFilter eventFilter);
        public Task<GetEventDTO> GetEventDetailById(int id);
        public Task<GetEventDTO> CreateEventDetail(CreateEventDTO eventDTO);
        public Task<GetEventDTO> UpdateEventDetail(int id, UpdateEventDTO updateEventDTO);
        public Task<bool> DeleteEvent(int id);
        void Dispose();
    }
}
