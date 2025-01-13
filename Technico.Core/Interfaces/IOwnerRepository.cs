using Technico.Core.Entities;

namespace Technico.Core.Interfaces
{
    public interface IOwnerRepository : IRepository<Owner>
    {
        Task<Owner?> ExistsByVatNumberAsync(string vatNumber);
        Task<bool> IsVatNumberUniqueAsync(string vatNumber, long excludedId);
        Task<Owner?> ExistsByEmailAsync(string email);
    }
}
