using API.DTOs;
using API.DTOs.Event;
using API.Entities;
using API.Filters;
using API.IRepositories;
using API.IServices;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace API.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public EventService(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _eventRepository = eventRepository;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _eventRepository.Dispose();
        }
        public async Task<GetEventDTO> CreateEventDetail(CreateEventDTO eventDTO)
        {
            eventDTO.CreatedAt = DateTime.UtcNow;
            var created = _eventRepository.Add(_mapper.Map<Event>(eventDTO));
            await _eventRepository.SaveChangesAsync();
            return _mapper.Map<GetEventDTO>(created);
        }

        public async Task<bool> DeleteEvent(int id)
        {
            var originalEvent = await _eventRepository.GetById(id);
            if (originalEvent == null) return false;
            originalEvent.IsDeleted = true;

            _eventRepository.Update(originalEvent);
            return await _eventRepository.SaveChangesAsync() > 0;
        }

        public async Task<PaginatedList<GetEventDTO>> GetAllEventDetails(EventFilter eventFilter)
        {
            eventFilter ??= new EventFilter();
            var result = _eventRepository.GetAll();
            //.WhereIf(!string.IsNullOrEmpty(subjectFilter.Name), x => EF.Functions.Like(x.AccommodationType, $"%{filter.AccommodationType}%"));

            return await _mapper.ProjectTo<GetEventDTO>(result).ToPaginatedListAsync(eventFilter.CurrentPage, eventFilter.PageSize);

        }

        public async Task<GetEventDTO> GetEventDetailById(int id)
        {
            return _mapper.Map<GetEventDTO>(await _eventRepository.GetById(id));
        }

        public async Task<GetEventDTO> UpdateEventDetail(int id, UpdateEventDTO updateEventDTO)
        {
            var originalEvent = await _eventRepository.GetById(id);
            if (originalEvent == null) return null;

            originalEvent.Name = updateEventDTO.Name;
            originalEvent.EventDate = updateEventDTO.EventDate;
            originalEvent.ModifiedAt = DateTime.UtcNow;
            //originalSubject.ModifiedBy = updateSubjectDTO.ModifiedBy;

            _eventRepository.Update(originalEvent);
            await _eventRepository.SaveChangesAsync();
            return _mapper.Map<GetEventDTO>(originalEvent);
        }
    }
}
