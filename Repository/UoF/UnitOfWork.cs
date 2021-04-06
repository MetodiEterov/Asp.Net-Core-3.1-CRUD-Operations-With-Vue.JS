using System.Threading.Tasks;

using Entities.DbContext;
using Entities.Contracts;

namespace Repository.Layer
{
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

        public async Task SaveAsync() { await _repoContext.SaveChangesAsync(); }

        public IAccountRepository Account
        {
            get { return (_account == null) ? new AccountRepository(_repoContext) : _account; }
        }

        public IOwnerRepository Owner
        {
            get { return (_owner == null) ? new OwnerRepository(_repoContext, _ownerMemoryCache) : _owner; }
        }
    }
}
