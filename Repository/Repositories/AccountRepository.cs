using System;
using System.Collections.Generic;
using System.Linq;

using Entities.Contracts;
using Entities.DbContext;
using Entities.Models;

namespace Repository.Layer
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Account> AccountsByOwner(Guid ownerId)
        { return FindByCondition(a => a.OwnerId.Equals(ownerId)).ToList(); }
    }
}
