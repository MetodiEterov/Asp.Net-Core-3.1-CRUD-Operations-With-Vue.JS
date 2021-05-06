using System.Threading.Tasks;

namespace Entities.Contracts
{
    /// <summary>
    /// IUnitOfWork interface
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// SaveAsync contract
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();

        /// <summary>
        /// Account contract
        /// </summary>
        IAccountRepository Account { get; }

        /// <summary>
        /// Owner contract
        /// </summary>
        IOwnerRepository Owner { get; }
    }
}
