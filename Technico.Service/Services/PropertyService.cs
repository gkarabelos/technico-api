using System.ComponentModel.DataAnnotations;
using AutoMapper;
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
            var entity = await _propertyRepository.GetByIdAsync(id);
            return _mapper.Map<PropertyDto>(entity);
        }

        public async Task<IEnumerable<PropertyDto>> GetPropertiesAsync()
        {
            var entities = await _propertyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PropertyDto>>(entities);
        }

        public async Task<PropertyDto> CreatePropertyAsync(CreatePropertyDto dto)
        {
            if (await _propertyRepository.ExistsByPropertyIdAsync(dto.PropertyId))
                throw new ValidationException("The Property ID already exists.");

            if (!await _propertyRepository.ExistsAsync(dto.OwnerId))
                throw new ValidationException("The Owner doesn't exists.");

            var entity = _mapper.Map<Property>(dto);
            var createdEntity = await _propertyRepository.AddAsync(entity);
            return _mapper.Map<PropertyDto>(createdEntity);
        }

        public async Task<bool> UpdatePropertyAsync(long id, UpdatePropertyDto dto)
        {
            if (!await _propertyRepository.IsPropertyIdUniqueAsync(dto.PropertyId, id))
                throw new ValidationException("Property ID already exists.");

            if (!await _propertyRepository.ExistsAsync(dto.OwnerId))
                throw new ValidationException("The Owner doesn't exists.");

            var entity = await _propertyRepository.GetByIdAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _propertyRepository.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> DeletePropertyAsync(long id)
        {
            var entity = await _propertyRepository.GetByIdAsync(id);
            if (entity == null) return false;

            await _propertyRepository.DeleteAsync(entity);
            return true;
        }
    }
}
