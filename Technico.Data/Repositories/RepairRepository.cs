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

        public async Task<IEnumerable<Repair>> GetPaginatedRepairsAsync(string? searchTerm, int skip, int take)
        {
            var repairStatusValues = new Dictionary<string, int>
            {
                { "Pending", 0 },
                { "In Progress", 1 },
                { "Complete", 2 }
            };

            var query = _dbContext.Repairs.Include(p => p.Property).ThenInclude(o => o.Owner).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var matchedType = repairStatusValues
                    .FirstOrDefault(kv => kv.Key.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

                query = query.Where(r =>
                    (matchedType.Key != null && r.Status == (RepairStatus)matchedType.Value) ||
                    r.Id.ToString().Contains(searchTerm) ||
                    r.Date.ToString().Contains(searchTerm) ||
                    r.Type.Contains(searchTerm) ||
                    r.Property.Address.Contains(searchTerm) ||
                    r.Cost.ToString().Contains(searchTerm) ||
                    r.Property.Owner.Name.Contains(searchTerm) ||
                    r.Property.Owner.Surname.Contains(searchTerm)
                );
            }

            var data = await query.Skip(skip).Take(take).ToListAsync();
            return data;
        }

        public async Task<int> GetTotalRepairCountAsync()
        {
            return await _dbContext.Repairs.CountAsync();
        }
    }
}
