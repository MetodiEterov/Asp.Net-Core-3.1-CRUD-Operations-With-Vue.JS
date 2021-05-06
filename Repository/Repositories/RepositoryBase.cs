using System;
using System.Linq;
using System.Linq.Expressions;

using Entities.Contracts;
using Entities.DbContext;

using Microsoft.EntityFrameworkCore;

namespace Repository.Layer
{
    /// <summary>
    /// RepositoryBase generic abstraction class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        /// <summary>
        /// Create method
        /// </summary>
        /// <param name="entity"></param>
        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        /// <summary>
        /// Delete method
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        /// <summary>
        /// FindAll method
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// FindByCondition method
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }
    }
}
