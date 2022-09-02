using API.DataContext;
using API.Entities;
using API.IRepositories;

namespace API.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext context) : base(context) 
        {

        }
    }
}
