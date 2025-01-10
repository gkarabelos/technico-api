using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailApp.Dtos.Owner;

namespace RetailApp.Interfaces;

public interface IOwnerService
{
    Task<OwnerDto> CreateOwnerAsync(CreateOwnerDto createOwnerDto);
    Task<OwnerDto?> GetByIdAsync(long Id);
    Task<IEnumerable<OwnerDto>> GetAllOwnersAsync();
    Task<bool> UpdateOwnerAsync(long Id, UpdateOwnerDto updateOwnerDto); 
    Task<bool> DeleteOwnerAsync(long Id);
    Task<OwnerDto?> FindByVatNumberAsync(string VATNumber);





}
