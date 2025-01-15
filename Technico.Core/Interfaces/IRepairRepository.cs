using Technico.Core.Entities;

namespace Technico.Core.Interfaces
{
    public interface IRepairRepository : IRepository<Repair>
    {
        Task<bool> ExistsAsync(long propertyId);
        Task<IEnumerable<Repair>> GetRepairsForTodayAsync();
        Task<IEnumerable<Repair>> GetPaginatedRepairsAsync(string? searchTerm, int skip, int take);
        Task<int> GetTotalRepairCountAsync();
    }
}
