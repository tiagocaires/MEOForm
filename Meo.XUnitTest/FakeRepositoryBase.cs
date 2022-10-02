using Meo.Data;
using Meo.Data.Repository.Interface;
using Meo.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Meo.XUnitTest
{
    public class FakeRepositoryBase<T> : IRepository<T> where T : AModelBase
    {
        protected readonly FakeDB<T> _db;
        public IUnitOfWork UnitOfWork => _db;
        protected readonly IQueryable<T> _dbFilter;
        private bool isDisposed;

        ~FakeRepositoryBase()
        {
            Dispose(false);
        }

        protected FakeRepositoryBase()
        {
            _db = new FakeDB<T> { Context = new List<T>() };
            _dbFilter = _db.Context.AsQueryable().AsNoTracking();
        }

        public void Add(T entity)
        {
            _db.Context.Add(entity);
        }

        public void Add(List<T> entities)
        {
            _db.Context.AddRange(entities);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;
            if (disposing) _db.Dispose();
        }

        public async virtual Task<T> GetById(int id)
        {
            return await Task.FromResult<T>(_db.Context.First(x => x.Id == id));
        }

        public IQueryable<T> QList(Expression<Func<T, bool>> filterExpression)
        {
            return filterExpression == null ? _dbFilter.AsNoTracking() : _dbFilter.AsNoTracking().Where(filterExpression);
        }

        public void Remove(T entity)
        {
            _db.Context.Remove(entity);
        }

        public void Remove(List<T> entities)
        {
            foreach (var entity in entities)
                _db.Context.Remove(entity);
        }

        public void Update(T entity)
        {
            _db.Context.Add(entity);
        }

        public void Update(List<T> entities)
        {
            _db.Context.AddRange(entities);
        }
    }
}
