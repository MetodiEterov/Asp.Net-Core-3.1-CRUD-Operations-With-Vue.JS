using Entities.Models;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace Entities.Contracts
{
    /// <summary>
    /// IOwnerRepository interface
    /// </summary>
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        /// <summary>
        /// CreateOwner contract
        /// </summary>
        /// <param name="owner"></param>
        void CreateOwner(Owner owner);

        /// <summary>
        /// DeleteOwner contract
        /// </summary>
        /// <param name="owner"></param>
        void DeleteOwner(Owner owner);

        /// <summary>
        /// GetAllOwnersAsync contract
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Owner>> GetAllOwnersAsync();

        /// <summary>
        /// GetOwnerByIdAsync contract
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        Task<Owner> GetOwnerByIdAsync(Guid ownerId);

        /// <summary>
        /// GetOwners contract
        /// </summary>
        /// <param name="ownerParameters"></param>
        /// <param name="isCacheIgnored"></param>
        /// <returns></returns>
        Task<IEnumerable<Owner>> GetOwners(OwnerParameters ownerParameters, bool isCacheIgnored = false);

        /// <summary>
        /// GetOwnerWithDetailsAsync contract
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>
        Task<Owner> GetOwnerWithDetailsAsync(Guid ownerId);

        /// <summary>
        /// UpdateOwner contract
        /// </summary>
        /// <param name="owner"></param>
        void UpdateOwner(Owner owner);
    }
}
