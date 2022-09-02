using API.DataContext;
using API.Entities;
using API.IRepositories;

namespace API.Repositories
{
    public class DepartmentRepository :  Repository<Department>,  IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
