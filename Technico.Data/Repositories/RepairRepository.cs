using Microsoft.EntityFrameworkCore;
using Technico.Core.Entities;
using Technico.Core.Enums;
using Technico.Core.Interfaces;

namespace Technico.Data.Repositories
{
    public class RepairRepository : IRepairRepository
    {
        protected readonly TechnicoDbContext _dbContext;

        public RepairRepository(TechnicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Repair>> GetAllAsync()
        {
            var data = await _dbContext.Repairs.Include(r => r.Property).ThenInclude(p => p.Owner).ToListAsync();
            return data;
        }

        public async Task<Repair?> GetByIdAsync(long id)
        {
            var data = await _dbContext.Repairs.Include(r => r.Property).ThenInclude(p => p.Owner).FirstOrDefaultAsync(r => r.Id == id); ;
            return data;
        }

        public async Task<Repair> AddAsync(Repair entity)
        {
            await _dbContext.Repairs.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Repair entity)
        {
            _dbContext.Repairs.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Repair entity)
        {
            _dbContext.Repairs.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(long propertyId)
        {
            return await _dbContext.Properties
                .AnyAsync(p => p.Id == propertyId);
        }

        public async Task<IEnumerable<Repair>> GetRepairsForTodayAsync()
        {
            var today = DateTime.UtcNow.Date;
            var repairsForToday = await _dbContext.Repairs
                .Include(r => r.Property)
                .ThenInclude(p => p.Owner)
                .Where(r => r.Date.Date == today && r.Status == RepairStatus.Pending)
                .ToListAsync();

            return repairsForToday;
        }

    }
}
