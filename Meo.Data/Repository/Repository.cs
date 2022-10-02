using Meo.Data.Repository.Interface;
using Meo.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : AModelBase
    {
        protected readonly MeoContext _db;
        protected readonly DbSet<T> _dbSet;
        protected readonly IQueryable<T> _dbFilter;
        private bool isDisposed;
        public IUnitOfWork UnitOfWork => _db;

        ~Repository()
        {
            Dispose(false);
        }

        protected Repository(MeoContext repository)
        {
            _db = repository;
            _dbSet = repository.Set<T>();
            _dbFilter = _dbSet.AsQueryable().AsNoTracking();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;
            if (disposing) _db.Dispose();
            isDisposed = true;
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Add(List<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Update(List<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Remove(List<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async virtual Task<T> GetById(int id)
        {
            return await _dbFilter.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<T> QList(Expression<Func<T, bool>> filterExpression)
        {
            return filterExpression == null ? _dbFilter.AsNoTracking() : _dbFilter.AsNoTracking().Where(filterExpression);
        }
    }
}
