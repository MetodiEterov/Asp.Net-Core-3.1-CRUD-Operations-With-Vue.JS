using System.Threading.Tasks;

using Entities.DbContext;
using Entities.Contracts;

namespace Repository.Layer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IOwnerRepository _owner;
        private readonly IAccountRepository _account;
        private readonly IOwnerMemoryCache _ownerMemoryCache;

        private RepositoryContext _repoContext;

        public UnitOfWork(RepositoryContext repositoryContext
            , IOwnerMemoryCache ownerMemoryCache)
        {
            _repoContext = repositoryContext;
            _ownerMemoryCache = ownerMemoryCache;
        }

        public IOwnerRepository Owner
        {
            get
            {
                return (_owner == null) ? new OwnerRepository(_repoContext, _ownerMemoryCache) : _owner;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                return (_account == null) ? new AccountRepository(_repoContext) : _account;
            }
        }

        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
