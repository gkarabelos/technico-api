using Technico.Core.DTOs.Pagination;
using Technico.Core.DTOs.Repair;

namespace Technico.Core.Interfaces
{
    public interface IRepairService
    {
        Task<RepairDto?> GetByIdAsync(long id);
        
        Task<IEnumerable<RepairDto>> GetRepairsAsync();
        Task<RepairDto> CreateRepairAsync(CreateRepairDto dto);
        Task<bool> UpdateRepairAsync(long id, UpdateRepairDto dto);
        Task<bool> DeleteRepairAsync(long id);
        Task<IEnumerable<RepairDto>> GetRepairsForTodayAsync();
    }
}
