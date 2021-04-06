using System;
using System.Collections.Generic;

using Entities.Models;

namespace Entities.Contracts
{
    public interface IAccountRepository
    {
        IEnumerable<Account> AccountsByOwner(Guid ownerId);
    }
}
