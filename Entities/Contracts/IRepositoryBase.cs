using System;
using System.Linq;
using System.Linq.Expressions;

namespace Entities.Contracts
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);

        void Delete(T entity);

        IQueryable<T> FindAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        void Update(T entity);
    }
}
