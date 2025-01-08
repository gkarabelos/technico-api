using Technico.Core.DTOs.Property;

namespace Technico.Core.Interfaces
{
    public interface IPropertyService
    {
        Task<PropertyDto?> GetByIdAsync(long id);
        Task<IEnumerable<PropertyDto>> GetPropertiesAsync();
        Task<PropertyDto> CreatePropertyAsync(CreatePropertyDto dto);
        Task<bool> UpdatePropertyAsync(long id, UpdatePropertyDto dto);
        Task<bool> DeletePropertyAsync(long id);
    }
}
