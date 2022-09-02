using API.DataContext;
using API.Entities;
using API.IRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected ApplicationDbContext Db { get; }

        protected DbSet<TEntity> DbSet { get; }
        
        public Repository(ApplicationDbContext dbContext)
        {
            Db = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            DbSet = Db.Set<TEntity>();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) Db.Dispose();
        }

        public virtual TEntity Add(TEntity entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public virtual IQueryable<TEntity> AddRange(IEnumerable<TEntity> entityList)
        {
            DbSet.AddRange(entityList);
            return entityList.AsQueryable();
        }

        public virtual async Task Delete(int id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity != null) DbSet.Remove(entity);
        }

        public virtual IEnumerable<TEntity> ExecuteStoredProcedure(string spName, params SqlParameter[] parameters)
        {
            if (parameters != null && parameters.Any())
            {
                var paramNames = new List<string>();
                foreach (var param in parameters)
                {
                    var name = param.ParameterName;
                    if (param.Direction == ParameterDirection.Output)
                    {
                        name = $"{param.ParameterName} OUT";
                    }
                    paramNames.Add(name);
                }



                var SS = DbSet.FromSqlRaw<TEntity>($"EXEC {spName} {string.Join(",", paramNames.ToArray())}", parameters).AsNoTracking();
                return DbSet.FromSqlRaw($"EXEC {spName} {string.Join(",", paramNames.ToArray())}", parameters).AsNoTracking();

            }

            return DbSet.FromSqlRaw($"EXEC {spName}").AsNoTracking();
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet.Where(e => e.IsDeleted == false); 
        }

        public virtual async Task<TEntity> GetById(long id)
        {
            return await DbSet
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted == false);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }

        public TEntity Update(TEntity entity)
        {
            DbSet.Update(entity);
            return entity;
        }

        public IQueryable<TEntity> UpdateRange(IEnumerable<TEntity> entityList)
        {
            DbSet.UpdateRange(entityList);
            return entityList.AsQueryable();
        }
    }
}
