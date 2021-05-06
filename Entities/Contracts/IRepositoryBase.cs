using System;
using System.Linq;
using System.Linq.Expressions;

namespace Entities.Contracts
{
    /// <summary>
    /// IRepositoryBase generic interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Create contract
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);

        /// <summary>
        /// Delete contract
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// FindAll contract
        /// </summary>
        /// <returns></returns>
        IQueryable<T> FindAll();

        /// <summary>
        /// FindByCondition contract
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Update contract
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
    }
}
