using Microsoft.EntityFrameworkCore;
using Technico.Core.Entities;
using Technico.Core.Interfaces;

namespace Technico.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        protected readonly TechnicoDbContext _dbContext;

        public OwnerRepository(TechnicoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Owner>> GetAllAsync()
        {
            var data = await _dbContext.Owners.ToListAsync();
            return data;
        }

        public async Task<Owner?> GetByIdAsync(long id)
        {
            var data = await _dbContext.Owners.FindAsync(id).AsTask();
            return data;
        }

        public async Task<Owner> AddAsync(Owner entity)
        {
            await _dbContext.Owners.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Owner entity)
        {
            _dbContext.Owners.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Owner entity)
        {
            _dbContext.Owners.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Owner?> ExistsByVatNumberAsync(string vatNumber)
        {
            return await _dbContext.Owners.FirstOrDefaultAsync(o => o.VatNumber == vatNumber);
        }

        public async Task<Owner?> ExistsByEmailAsync(string email)
        {
            return await _dbContext.Owners.FirstOrDefaultAsync(o => o.Email == email);
        }

        public async Task<bool> IsVatNumberUniqueAsync(string vatNumber, long excludedId)
        {
            return !await _dbContext.Owners
                .AnyAsync(o => o.VatNumber == vatNumber && o.Id != excludedId);
        }
    }
}
