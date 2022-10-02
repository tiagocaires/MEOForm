using Meo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Data.Repository.Interface
{
    public interface IRepository<T> : IDisposable where T : AModelBase
    {
        IUnitOfWork UnitOfWork { get; }
        void Add(T entity);
        void Add(List<T> entities);
        void Update(T entity);
        void Update(List<T> entities);
        void Remove(T entity);
        void Remove(List<T> entities);
        Task<T> GetById(int id);
        IQueryable<T> QList(Expression<Func<T, bool>> filterExpression);
    }
}
