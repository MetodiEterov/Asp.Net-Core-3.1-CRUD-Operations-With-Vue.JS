using System.Threading.Tasks;

namespace Entities.Contracts
{
    public interface IUnitOfWork
    {
        Task SaveAsync();

        IAccountRepository Account { get; }

        IOwnerRepository Owner { get; }
    }
}
