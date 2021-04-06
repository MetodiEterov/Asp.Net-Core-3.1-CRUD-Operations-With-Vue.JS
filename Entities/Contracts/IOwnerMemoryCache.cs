using System.Collections.Generic;

using Entities.Models;

namespace Entities.Contracts
{
    public interface IOwnerMemoryCache
    {
        void SetOwnerMemoryCache(IEnumerable<Owner> windowsGroups);

        IEnumerable<Owner> GetOwnerMemoryCache();
    }
}
