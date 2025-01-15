using Technico.Core.DTOs.Owner;
using Technico.Core.Entities;

namespace Technico.Core.Interfaces
{
    public interface IOwnerService
    {
        Task<OwnerDto?> GetByIdAsync(long id);
        Task<IEnumerable<OwnerDto>> GetOwnersAsync();
        Task<OwnerDto> CreateOwnerAsync(CreateOwnerDto dto);
        Task<bool> UpdateOwnerAsync(long id, UpdateOwnerDto dto);
        Task<bool> DeleteOwnerAsync(long id);
        Task<OwnerDto?> FindByVatNumberAsync(string vatNumber);
        Task<IEnumerable<OwnerDto>> GetFilteredOwnersAsync(string? vatNumber, string? email);
    }
}
