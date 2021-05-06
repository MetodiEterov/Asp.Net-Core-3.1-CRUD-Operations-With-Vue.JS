using System;
using System.Collections.Generic;

using Entities.Models;

namespace Entities.Contracts
{
    /// <summary>
    /// IAccountRepository interface
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// AccountsByOwner contract
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        IEnumerable<Account> AccountsByOwner(Guid ownerId);
    }
}
