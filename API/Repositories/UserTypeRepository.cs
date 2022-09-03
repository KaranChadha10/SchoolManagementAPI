using API.DataContext;
using API.Entities;
using API.IRepositories;

namespace API.Repositories
{
    public class UserTypeRepository : Repository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
