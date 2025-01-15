using Technico.Core.DTOs.Property;
using Technico.Core.Entities;

namespace Technico.Core.Interfaces
{
    public interface IPropertyRepository : IRepository<Property>
    {
        Task<bool> ExistsByE9Async(string E9);
        Task<bool> IsE9UniqueAsync(string E9, long excludedId);
        Task<bool> ExistsAsync(long ownerId);
        Task<IEnumerable<Property>> GetPaginatedPropertiesAsync(string? searchTerm, int skip, int take);
        Task<int> GetTotalPropertyCountAsync();
        Task<Property?> GetPropertyIdByE9Async(string E9);
    }
}
 