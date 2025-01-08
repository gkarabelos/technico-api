using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Technico.Core.DTOs.Owner;
using Technico.Core.Entities;
using Technico.Core.Interfaces;

namespace Technico.Service.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerService(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        public async Task<OwnerDto?> GetByIdAsync(long id)
        {
            var entity = await _ownerRepository.GetByIdAsync(id);
            return _mapper.Map<OwnerDto>(entity);
        }

        public async Task<IEnumerable<OwnerDto>> GetOwnersAsync()
        {
            var entities = await _ownerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OwnerDto>>(entities);
        }

        public async Task<OwnerDto> CreateOwnerAsync(CreateOwnerDto dto)
        {
            if (await _ownerRepository.ExistsByVatNumberAsync(dto.VatNumber) != null)
            {
                throw new ValidationException("The VAT number already exists.");
            }

            var entity = _mapper.Map<Owner>(dto);
            var createdEntity = await _ownerRepository.AddAsync(entity);
            return _mapper.Map<OwnerDto>(createdEntity);
        }

        public async Task<bool> UpdateOwnerAsync(long id, UpdateOwnerDto dto)
        {
            if (!await _ownerRepository.IsVatNumberUniqueAsync(dto.VatNumber, id))
            {
                throw new ValidationException("VAT Number already exists.");
            }

            var entity = await _ownerRepository.GetByIdAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _ownerRepository.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> DeleteOwnerAsync(long id)
        {
            var entity = await _ownerRepository.GetByIdAsync(id);
            if (entity == null) return false;

            await _ownerRepository.DeleteAsync(entity);
            return true;
        }

        public async Task<OwnerDto?> FindByVatNumberAsync(string vatNumber)
        {
            var entity = await _ownerRepository.ExistsByVatNumberAsync(vatNumber);
            return _mapper.Map<OwnerDto>(entity);
        }
    }
}
