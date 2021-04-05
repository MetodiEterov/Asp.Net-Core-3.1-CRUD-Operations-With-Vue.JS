using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Entities.Models;

namespace Entities.Contracts
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        Task<IEnumerable<Owner>> GetOwners(OwnerParameters ownerParameters, bool isCacheIgnored = false);

        Task<IEnumerable<Owner>> GetAllOwnersAsync();

        Task<Owner> GetOwnerByIdAsync(Guid ownerId);

        Task<Owner> GetOwnerWithDetailsAsync(Guid ownerId);

        void CreateOwner(Owner owner);

        void UpdateOwner(Owner owner);

        void DeleteOwner(Owner owner);
    }
}
