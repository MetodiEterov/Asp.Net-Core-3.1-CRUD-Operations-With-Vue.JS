using System;
using System.Collections.Generic;
using System.Linq;

using Entities.Contracts;
using Entities.DbContext;
using Entities.Models;

namespace Repository.Layer
{
    /// <summary>
    /// AccountRepository class
    /// </summary>
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        /// <summary>
        /// AccountsByOwner method
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public IEnumerable<Account> AccountsByOwner(Guid ownerId)
        {
            return FindByCondition(a => a.OwnerId.Equals(ownerId)).ToList();
        }
    }
}
