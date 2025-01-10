using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailApp.Dtos.Pagination;
using RetailApp.Dtos.Property;
using RetailApp.Dtos.Repair;

namespace RetailApp.Interfaces;

public interface IRepairService
{
    Task<RepairDto?> GetByIdAsync(long id);
    Task<IEnumerable<RepairDto>> GetRepairsAsync();
    Task<RepairDto> CreateRepairAsync(CreateRepairDto dto);
    Task<bool> UpdateRepairAsync(long id, UpdateRepairDto dto);
    Task<bool> DeleteRepairAsync(long id);
    Task<PaginatedResult<RepairDto>> GetPaginatedRepairsAsync(int page, int pageSize);
}
