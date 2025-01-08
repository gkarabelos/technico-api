using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Technico.Core.DTOs.Repair;
using Technico.Core.Entities;
using Technico.Core.Interfaces;

namespace Technico.Service.Services
{
    public class RepairService : IRepairService
    {
        private readonly IRepairRepository _repairRepository;
        private readonly IMapper _mapper;

        public RepairService(IRepairRepository repairRepository, IMapper mapper)
        {
            _repairRepository = repairRepository;
            _mapper = mapper;
        }

        public async Task<RepairDto?> GetByIdAsync(long id)
        {
            var entity = await _repairRepository.GetByIdAsync(id);
            return _mapper.Map<RepairDto>(entity);
        }

        public async Task<IEnumerable<RepairDto>> GetRepairsAsync()
        {
            var entities = await _repairRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RepairDto>>(entities);
        }

        public async Task<RepairDto> CreateRepairAsync(CreateRepairDto dto)
        {
            if (!await _repairRepository.ExistsAsync(dto.PropertyId))
                throw new ValidationException("The Property doesn't exists.");

            var entity = _mapper.Map<Repair>(dto);
            var createdEntity = await _repairRepository.AddAsync(entity);
            return _mapper.Map<RepairDto>(createdEntity);
        }

        public async Task<bool> UpdateRepairAsync(long id, UpdateRepairDto dto)
        {
            if (!await _repairRepository.ExistsAsync(dto.PropertyId))
                throw new ValidationException("The Property doesn't exists.");

            var entity = await _repairRepository.GetByIdAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _repairRepository.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> DeleteRepairAsync(long id)
        {
            var entity = await _repairRepository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repairRepository.DeleteAsync(entity);
            return true;
        }
    }
}
