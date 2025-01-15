using Technico.Core.Entities;

namespace Technico.Core.Interfaces
{
    public interface IRepairRepository : IRepository<Repair>
    {
        Task<bool> ExistsAsync(long propertyId);
        Task<IEnumerable<Repair>> GetRepairsForTodayAsync();
       
    }
}
