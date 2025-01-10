using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailApp.Models;

namespace RetailApp.Interfaces;

public interface IRepairRepository : IRepository<Repair>
{
    Task<bool> ExistsAsync(long propertyId);
    Task<int> GetTotalRepairCountAsync();
    Task<IEnumerable<Repair>> GetPaginatedRepairsAsync(int skip, int take);

}
