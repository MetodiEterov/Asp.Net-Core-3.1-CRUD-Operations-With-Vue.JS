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
    /// <summary>
    /// OwnerRepository class contains all logic to access DB
    /// </summary>
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        private readonly IOwnerMemoryCache _ownerMemoryCache;

        public OwnerRepository(RepositoryContext repositoryContext, IOwnerMemoryCache ownerMemoryCache) : base(
            repositoryContext)
        { _ownerMemoryCache = ownerMemoryCache; }

        /// <summary>
        /// CreateOwner method
        /// </summary>
        /// <param name="owner"></param>
        public void CreateOwner(Owner owner) { Create(owner); }

        /// <summary>
        /// DeleteOwner method
        /// </summary>
        /// <param name="owner"></param>
        public void DeleteOwner(Owner owner) { Delete(owner); }

        /// <summary>
        /// GetAllOwnersAsync method
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        { return await FindAll().OrderBy(ow => ow.Name).ToListAsync(); }

        /// <summary>
        /// GetOwnerByIdAsync
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public async Task<Owner> GetOwnerByIdAsync(Guid ownerId)
        { return await FindByCondition(owner => owner.Id.Equals(ownerId)).FirstOrDefaultAsync(); }

        /// <summary>
        /// GetOwners method
        /// </summary>
        /// <param name="ownerParameters"></param>
        /// <param name="isCacheIgnored"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Owner>> GetOwners(OwnerParameters ownerParameters, bool isCacheIgnored = false)
        {
            // return the cached owners if there is an entry in the memory cache
            if(!isCacheIgnored)
            {
                IEnumerable<Owner> ownersCached = _ownerMemoryCache.GetOwnerMemoryCache();
                if(ownersCached.Any())
                    return ownersCached;
            }

            var result = await FindAll()
                .OrderBy(on => on.Name)
                .Skip((ownerParameters.PageNumber - 1) * ownerParameters.PageSize)
                .Take(ownerParameters.PageSize)
                .ToListAsync();

            // store result to memory cache
            if(result != null)
                _ownerMemoryCache.SetOwnerMemoryCache(result);

            return result;
        }

        /// <summary>
        /// GetOwnerWithDetailsAsync method
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        public async Task<Owner> GetOwnerWithDetailsAsync(Guid ownerId)
        {
            return await FindByCondition(owner => owner.Id.Equals(ownerId))
                .Include(ac => ac.Accounts)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// UpdateOwner method
        /// </summary>
        /// <param name="owner"></param>
        public void UpdateOwner(Owner owner) { Update(owner); }
    }
}
