using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailApp.Dtos.Owner;
using RetailApp.Dtos.Pagination;
using RetailApp.Dtos.Property;

namespace RetailApp.Interfaces;

public interface IPropertyService
{
    Task<PropertyDto?> FindByIdAsync(long Id);
    Task<PropertyDto> CreateAsync(PropertyDto propertyDto);
    Task DeactivateAsync(long Id); //new
    Task<bool> UpdatePropertyAsync(PropertyDto propertyDto);
    Task<PropertyDto?> FindByE9Async(string E9); //unique
    Task<PaginatedResult<PropertyDto>> GetPaginatedPropertiesAsync(int page,int pageSize);

}
