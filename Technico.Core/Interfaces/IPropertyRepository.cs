using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RetailApp.Dtos.Pagination;

namespace RetailApp.Interfaces;

public interface IPropertyRepository : IRepository<Property>
{
    Task<bool> ExistsByE9dAsync(string E9);
    Task<bool> IsE9UniqueAsync(string propertyId, long excludedId);
    Task<bool> ExistsAsync(long ownerId);
    Task DeactivateAsync(long propertyId); //New
    Task<int> GetTotalPropertyCountAsync();
    Task<IEnumerable<Property>> GetPaginatedPropertiesAsync(int skip, int take);

    
}

