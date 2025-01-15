using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Technico.Core.DTOs.Owner;
using Technico.Core.DTOs.Property;
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
            var owner = await _ownerRepository.GetByIdAsync(id);
            return _mapper.Map<OwnerDto>(owner);
        }

        public async Task<IEnumerable<OwnerDto>> GetOwnersAsync()
        {
            var owners = await _ownerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OwnerDto>>(owners);
        }

        public async Task<OwnerDto> CreateOwnerAsync(CreateOwnerDto dto)
        {
            if (await _ownerRepository.ExistsByVatNumberAsync(dto.VatNumber) != null)
                throw new ValidationException("The VAT number already exists.");

            if (await _ownerRepository.ExistsByEmailAsync(dto.Email) != null)
                throw new ValidationException("The Email already exists.");

            var owner = _mapper.Map<Owner>(dto);
            var createdOwner = await _ownerRepository.AddAsync(owner);
            return _mapper.Map<OwnerDto>(createdOwner);
        }

        public async Task<bool> UpdateOwnerAsync(long id, UpdateOwnerDto dto)
        {
            if (!await _ownerRepository.IsVatNumberUniqueAsync(dto.VatNumber, id))
            {
                throw new ValidationException("VAT Number already exists.");
            }

            var owner = await _ownerRepository.GetByIdAsync(id);
            if (owner == null) return false;

            _mapper.Map(dto, owner);
            await _ownerRepository.UpdateAsync(owner);
            return true;
        }

        public async Task<bool> DeleteOwnerAsync(long id)
        {
            var owner = await _ownerRepository.GetByIdAsync(id);
            if (owner == null) return false;

            await _ownerRepository.DeleteAsync(owner);
            return true;
        }

        public async Task<OwnerDto?> FindByVatNumberAsync(string vatNumber)
        {
            var owner = await _ownerRepository.ExistsByVatNumberAsync(vatNumber);
            return _mapper.Map<OwnerDto>(owner);
        }

        public async Task<IEnumerable<OwnerDto>> GetFilteredOwnersAsync(string? vatNumber, string? email)
        {
            if (string.IsNullOrWhiteSpace(vatNumber) && string.IsNullOrWhiteSpace(email))
            {
                return Enumerable.Empty<OwnerDto>();
            }

            var owners = await _ownerRepository.GetFilteredOwnersAsync(vatNumber, email);
            return _mapper.Map<IEnumerable<OwnerDto>>(owners);
        }

        public async Task<bool> ValidateEmailAsync(string email)
        {
            var owner = await _ownerRepository.ExistsByEmailAsync(email);
            return owner != null; // returns true if the email exists, false otherwise
        }

        public async Task<bool> ValidatePasswordAsync(string email, string password)
        {
            var owner = await _ownerRepository.ExistsByEmailAsync(email);
            if (owner == null) return false;
            return owner.Password == password;
        }



    }



}
