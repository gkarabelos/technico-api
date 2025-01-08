

namespace Technico.Data.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        protected readonly TechnicoDbContext _dbContext;

        public PropertyRepository(TechnicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Property>> GetAllAsync()
        {
            var data = await _dbContext.Properties.Include(p => p.Owner).ToListAsync();
            return data;
        }

        public async Task<Property?> GetByIdAsync(long id)
        {
            var data = await _dbContext.Properties.Include(p => p.Owner).FirstOrDefaultAsync(p => p.Id == id);
            return data;
        }

        public async Task<Property> AddAsync(Property entity)
        {
            await _dbContext.Properties.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Property entity)
        {
            _dbContext.Properties.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Property entity)
        {
            _dbContext.Properties.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByPropertyIdAsync(string propertyId)
        {
            return await _dbContext.Properties.AnyAsync(p => p.PropertyId == propertyId);
        }

        public async Task<bool> IsPropertyIdUniqueAsync(string propertyId, long excludedId)
        {
            return !await _dbContext.Properties
                .AnyAsync(p => p.PropertyId == propertyId && p.Id != excludedId);
        }

        public async Task<bool> ExistsAsync(long ownerId)
        {
            return await _dbContext.Owners
                .AnyAsync(o => o.Id == ownerId);
        }
    }
}
