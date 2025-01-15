using Microsoft.EntityFrameworkCore;
using Technico.Core.DTOs.Owner;
using Technico.Core.DTOs.Property;
using Technico.Core.Entities;
using Technico.Core.Enums;
using Technico.Core.Interfaces;

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

        public async Task<Property?> GetPropertyIdByE9Async(string E9)
        {
            return await _dbContext.Properties
                .FirstOrDefaultAsync(p => p.E9 == E9);
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

        public async Task<bool> ExistsByE9Async(string E9)
        {
            return await _dbContext.Properties.AnyAsync(p => p.E9 == E9);
        }

        public async Task<bool> IsE9UniqueAsync(string E9, long excludedId)
        {
            return !await _dbContext.Properties
                .AnyAsync(p => p.E9 == E9 && p.Id != excludedId);
        }

        public async Task<bool> ExistsAsync(long ownerId)
        {
            return await _dbContext.Owners
                .AnyAsync(o => o.Id == ownerId);
        }

        public async Task<IEnumerable<Property>> GetPaginatedPropertiesAsync(string? searchTerm, int skip, int take)
        {
            var propertyTypeValues = new Dictionary<string, int>
            {
                { "Detached House", 0 },
                { "Maisonet", 1 },
                { "Apartment Building", 2 }
            };

            var query = _dbContext.Properties.Include(p => p.Owner).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var matchedType = propertyTypeValues
                    .FirstOrDefault(kv => kv.Key.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

                query = query.Where(p =>
                    (matchedType.Key != null && p.Type == (PropertyType)matchedType.Value) ||
                    p.Id.ToString().Contains(searchTerm) ||
                    p.E9.Contains(searchTerm) ||
                    p.Address.Contains(searchTerm) ||
                    p.YearOfConstruction.ToString().Contains(searchTerm) ||
                    p.Owner.VatNumber.Contains(searchTerm)
                );
            }

            var data = await query.Skip(skip).Take(take).ToListAsync();
            return data;
        }

        public async Task<int> GetTotalPropertyCountAsync()
        {
            return await _dbContext.Properties.CountAsync();
        }
    }
}
