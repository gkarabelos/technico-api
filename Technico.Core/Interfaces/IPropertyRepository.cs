using Technico.Core.Entities;

namespace Technico.Core.Interfaces
{
    public interface IPropertyRepository : IRepository<Property>
    {
        Task<bool> ExistsByPropertyIdAsync(string propertyId);
        Task<bool> IsPropertyIdUniqueAsync(string propertyId, long excludedId);
        Task<bool> ExistsAsync(long ownerId);
    }
}
