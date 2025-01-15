
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Technico.Core.DTOs.Pagination;
using Technico.Core.DTOs.Property;
using Technico.Core.DTOs.Repair;
using Technico.Core.Entities;
using Technico.Core.Interfaces;
using Technico.Data.Repositories;

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
            var repair = await _repairRepository.GetByIdAsync(id);
            return _mapper.Map<RepairDto>(repair);
        }

        public async Task<IEnumerable<RepairDto>> GetRepairsAsync()
        {
            var repairs = await _repairRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RepairDto>>(repairs);
        }

        public async Task<RepairDto> CreateRepairAsync(CreateRepairDto dto)
        {
            if (!await _repairRepository.ExistsAsync(dto.PropertyId))
                throw new ValidationException("The Property doesn't exists.");

            var repair = _mapper.Map<Repair>(dto);
            var createdRepair = await _repairRepository.AddAsync(repair);
            return _mapper.Map<RepairDto>(createdRepair);
        }

        public async Task<bool> UpdateRepairAsync(long id, UpdateRepairDto dto)
        {
            if (!await _repairRepository.ExistsAsync(dto.PropertyId))
                throw new ValidationException("The Property doesn't exists.");

            var repair = await _repairRepository.GetByIdAsync(id);
            if (repair == null) return false;

            _mapper.Map(dto, repair);
            await _repairRepository.UpdateAsync(repair);
            return true;
        }

        public async Task<bool> DeleteRepairAsync(long id)
        {
            var repair = await _repairRepository.GetByIdAsync(id);
            if (repair == null) return false;

            await _repairRepository.DeleteAsync(repair);
            return true;
        }

        public async Task<IEnumerable<RepairDto>> GetRepairsForTodayAsync()
        {
            var repairs = await _repairRepository.GetRepairsForTodayAsync();
            return _mapper.Map<IEnumerable<RepairDto>>(repairs);
        }

        public async Task<PaginatedResult<RepairDto>> GetPaginatedRepairsAsync(string? searchTerm, int page, int pageSize)
        {
            int skip = (page - 1) * pageSize;

            var properties = await _repairRepository.GetPaginatedRepairsAsync(searchTerm, skip, pageSize);

            var totalRecords = await _repairRepository.GetTotalRepairCountAsync();

            return new PaginatedResult<RepairDto>
            {
                Data = _mapper.Map<IEnumerable<RepairDto>>(properties),
                TotalRecords = totalRecords
            };
        }
    }
}
