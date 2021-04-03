﻿// <auto-generated />
namespace Repository.Layer
{
    using System.Threading.Tasks;

    using Entities.DbContext;
    using Entities.Contracts;

    /// <summary>
    /// UnitOfWork class
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IOwnerRepository _owner;
        private readonly IAccountRepository _account;
        private readonly IOwnerMemoryCache _ownerMemoryCache;

        private RepositoryContext _repoContext;

        /// <summary>
        /// UnitOfWork constructor
        /// </summary>
        /// <param name="repositoryContext"></param>
        public UnitOfWork(RepositoryContext repositoryContext
            , IOwnerMemoryCache ownerMemoryCache)
        {
            _repoContext = repositoryContext;
            _ownerMemoryCache = ownerMemoryCache;
        }

        /// <summary>
        /// Owner property
        /// </summary>
        public IOwnerRepository Owner
        {
            get
            {
                return (_owner == null) ? new OwnerRepository(_repoContext, _ownerMemoryCache) : _owner;
            }
        }

        /// <summary>
        /// Account property
        /// </summary>
        public IAccountRepository Account
        {
            get
            {
                return (_account == null) ? new AccountRepository(_repoContext) : _account;
            }
        }

        /// <summary>
        /// SaveAsync method
        /// </summary>
        /// <returns></returns>
        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}