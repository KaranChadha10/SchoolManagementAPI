using API.DataContext;
using API.Entities;
using API.IRepositories;

namespace API.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
