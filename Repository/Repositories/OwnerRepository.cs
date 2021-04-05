using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Entities.Contracts;
using Entities.DbContext;
using Entities.Models;

using Microsoft.EntityFrameworkCore;

namespace Repository.Layer
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        private readonly IOwnerMemoryCache _ownerMemoryCache;

        public OwnerRepository(RepositoryContext repositoryContext
            , IOwnerMemoryCache ownerMemoryCache)
            : base(repositoryContext)
        {
            _ownerMemoryCache = ownerMemoryCache;
        }

        public async Task<IEnumerable<Owner>> GetOwners(OwnerParameters ownerParameters, bool isCacheIgnored = false)
        {
            if (!isCacheIgnored)
            {
                IEnumerable<Owner> ownersCached = _ownerMemoryCache.GetOwnerMemoryCache();
                if (ownersCached.Any()) return ownersCached;
            }

            var result = await FindAll()
                .OrderBy(on => on.Name)
                .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                .Take(ownerParameters.PageSize)
                .ToListAsync();

            // store result to memory cache
            if (result != null) _ownerMemoryCache.SetOwnerMemoryCache(result);

            return result;
        }

        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.Name)
               .ToListAsync();
        }

        public async Task<Owner> GetOwnerByIdAsync(Guid ownerId)
        {
            return await FindByCondition(owner => owner.Id.Equals(ownerId))
                .FirstOrDefaultAsync();
        }

        public async Task<Owner> GetOwnerWithDetailsAsync(Guid ownerId)
        {
            return await FindByCondition(owner => owner.Id.Equals(ownerId))
                .Include(ac => ac.Accounts)
                .FirstOrDefaultAsync();
        }

        public void CreateOwner(Owner owner)
        {
            Create(owner);
        }

        public void UpdateOwner(Owner owner)
        {
            Update(owner);
        }

        public void DeleteOwner(Owner owner)
        {
            Delete(owner);
        }
    }
}
