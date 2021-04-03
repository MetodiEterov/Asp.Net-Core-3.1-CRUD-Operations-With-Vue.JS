﻿// <auto-generated />
namespace Entities.Contracts
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// RepositoryBase generic interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Method contract
        /// </summary>
        /// <returns></returns>
        IQueryable<T> FindAll();

        /// <summary>
        /// Method contract
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Method contract
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);

        /// <summary>
        /// Method contract
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Method contract
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}