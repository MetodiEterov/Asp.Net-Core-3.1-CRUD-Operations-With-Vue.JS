using System;
using System.Linq;
using System.Linq.Expressions;

using Entities.Contracts;
using Entities.DbContext;

using Microsoft.EntityFrameworkCore;

namespace Repository.Layer
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        public RepositoryBase(RepositoryContext repositoryContext) { this.RepositoryContext = repositoryContext; }

        protected RepositoryContext RepositoryContext { get; set; }

        public void Create(T entity) { this.RepositoryContext.Set<T>().Add(entity); }

        public void Delete(T entity) { this.RepositoryContext.Set<T>().Remove(entity); }

        public IQueryable<T> FindAll() { return this.RepositoryContext.Set<T>().AsNoTracking(); }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        { return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking(); }

        public void Update(T entity) { this.RepositoryContext.Set<T>().Update(entity); }
    }
}
