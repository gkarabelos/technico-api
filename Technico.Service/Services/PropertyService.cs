using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Technico.Core.DTOs.Owner;
using Technico.Core.DTOs.Pagination;
using Technico.Core.DTOs.Property;
using Technico.Core.Entities;
using Technico.Core.Interfaces;

namespace Technico.Service.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public PropertyService(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<PropertyDto?> GetByIdAsync(long id)
        {
            var property = await _propertyRepository.GetByIdAsync(id);
            return _mapper.Map<PropertyDto>(property);
        }

        public async Task<IEnumerable<PropertyDto>> GetPropertiesAsync()
        {
            var properties = await _propertyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PropertyDto>>(properties);
        }

        public async Task<PropertyDto> CreatePropertyAsync(CreatePropertyDto dto)
        {
            if (await _propertyRepository.ExistsByE9Async(dto.E9))
                throw new ValidationException("The Property ID already exists.");

            if (!await _propertyRepository.ExistsAsync(dto.OwnerId))
                throw new ValidationException("The Owner doesn't exists.");

            var property = _mapper.Map<Property>(dto);
            var createdProperty = await _propertyRepository.AddAsync(property);
            return _mapper.Map<PropertyDto>(createdProperty);
        }

        public async Task<bool> UpdatePropertyAsync(long id, UpdatePropertyDto dto)
        {
            if (!await _propertyRepository.IsE9UniqueAsync(dto.E9, id))
                throw new ValidationException("Property ID already exists.");

            if (!await _propertyRepository.ExistsAsync(dto.OwnerId))
                throw new ValidationException("The Owner doesn't exists.");

            var property = await _propertyRepository.GetByIdAsync(id);
            if (property == null) return false;

            _mapper.Map(dto, property);
            await _propertyRepository.UpdateAsync(property);
            return true;
        }

        public async Task<bool> DeletePropertyAsync(long id)
        {
            var property = await _propertyRepository.GetByIdAsync(id);
            if (property == null) return false;

            await _propertyRepository.DeleteAsync(property);
            return true;
        }

        public async Task<PaginatedResult<PropertyDto>> GetPaginatedPropertiesAsync(string? searchTerm, int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;

            var properties = await _propertyRepository.GetPaginatedPropertiesAsync(searchTerm, skip, pageSize);

            var totalRecords = await _propertyRepository.GetTotalPropertyCountAsync();

            return new PaginatedResult<PropertyDto>
            {
                Data = _mapper.Map<IEnumerable<PropertyDto>>(properties),
                TotalRecords = totalRecords
            };
        }

        public async Task<bool> DeactivatePropertyAsync(long id)
        {
            var property = await _propertyRepository.GetByIdAsync(id);
            if (property == null) return false;

            property.IsActive = false;
            await _propertyRepository.UpdateAsync(property);
            return true;
        }

        public async Task<PropertyDto> GetPropertyByE9Async(string E9)
        {
            var property = await _propertyRepository.GetPropertyIdByE9Async(E9);
            return _mapper.Map<PropertyDto>(property);
        }
    }
}
