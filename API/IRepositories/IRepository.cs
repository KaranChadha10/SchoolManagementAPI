using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.IRepositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(long id);

        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        IQueryable<TEntity> AddRange(IEnumerable<TEntity> entityList);
        IQueryable<TEntity> UpdateRange(IEnumerable<TEntity> entityList);
        Task Delete(int id);
        Task<int> SaveChangesAsync();

        IEnumerable<TEntity> ExecuteStoredProcedure(string spName, params SqlParameter[] parameters);
    }
}
