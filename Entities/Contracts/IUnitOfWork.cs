using System.Threading.Tasks;

namespace Entities.Contracts
{
    public interface IUnitOfWork
    {
        IOwnerRepository Owner { get; }

        IAccountRepository Account { get; }

        Task SaveAsync();
    }
}
