using System.Threading.Tasks;

using Entities.DbContext;
using Entities.Contracts;

namespace Repository.Layer
{
    /// <summary>
    /// UnitOfWork class wrapping repository layer's classes
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAccountRepository _account;
        private readonly IOwnerRepository _owner;
        private readonly IOwnerMemoryCache _ownerMemoryCache;

        private RepositoryContext _repoContext;

        public UnitOfWork(RepositoryContext repositoryContext, IOwnerMemoryCache ownerMemoryCache)
        {
            _repoContext = repositoryContext;
            _ownerMemoryCache = ownerMemoryCache;
        }

        /// <summary>
        /// SaveAsync method
        /// </summary>
        /// <returns></returns>
        public async Task SaveAsync() { await _repoContext.SaveChangesAsync(); }

        /// <summary>
        /// Account property to access account repository
        /// </summary>
        public IAccountRepository Account
        {
            get { return (_account == null) ? new AccountRepository(_repoContext) : _account; }
        }

        /// <summary>
        /// Owner property to access owner repository
        /// </summary>
        public IOwnerRepository Owner
        {
            get { return (_owner == null) ? new OwnerRepository(_repoContext, _ownerMemoryCache) : _owner; }
        }
    }
}
