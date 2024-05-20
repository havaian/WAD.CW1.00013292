using Microsoft.EntityFrameworkCore;
using WAD.CW1._00013292.DAL.Interfaces;
using WAD.CW1._00013292.Data;
using WAD.CW1._00013292.Models;

namespace WAD.CW1._00013292.Repositories
{
    public class KeyTypeRepository : IKeyTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public KeyTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KeyType>> GetAllAsync()
        {
            return await _context.KeyTypes.ToListAsync();
        }

        public async Task<KeyType> GetByIdAsync(int keyTypeId)
        {
            return await _context.KeyTypes.FindAsync(keyTypeId);
        }

        public async Task<KeyType> AddAsync(KeyType keyType)
        {
            _context.KeyTypes.Add(keyType);
            await _context.SaveChangesAsync();
            return keyType;
        }

        public async Task<KeyType> UpdateAsync(KeyType keyType)
        {
            _context.KeyTypes.Update(keyType);
            await _context.SaveChangesAsync();
            return keyType;
        }

        public async Task DeleteAsync(int keyTypeId)
        {
            var keyType = await GetByIdAsync(keyTypeId);
            if (keyType != null)
            {
                _context.KeyTypes.Remove(keyType);
                await _context.SaveChangesAsync();
            }
        }
    }

}
