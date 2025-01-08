

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
            var data = await _dbContext.Repairs.ToListAsync();
            return data;
        }

        public async Task<Repair?> GetByIdAsync(long id)
        {
            var data = await _dbContext.Repairs.FindAsync(id).AsTask();
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
    }
}
