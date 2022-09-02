using API.DataContext;
using API.Entities;
using API.IRepositories;

namespace API.Repositories
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
