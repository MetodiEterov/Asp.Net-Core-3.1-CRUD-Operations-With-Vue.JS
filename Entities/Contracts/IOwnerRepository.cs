using Entities.Models;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Entities.Contracts
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        void CreateOwner(Owner owner);

        void DeleteOwner(Owner owner);

        Task<IEnumerable<Owner>> GetAllOwnersAsync();

        Task<Owner> GetOwnerByIdAsync(Guid ownerId);

        Task<IEnumerable<Owner>> GetOwners(OwnerParameters ownerParameters, bool isCacheIgnored = false);

        Task<Owner> GetOwnerWithDetailsAsync(Guid ownerId);

        void UpdateOwner(Owner owner);
    }
}
