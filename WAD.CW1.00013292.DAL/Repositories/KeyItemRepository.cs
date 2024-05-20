using Microsoft.EntityFrameworkCore;
using WAD.CW1._00013292.DAL.Interfaces;
using WAD.CW1._00013292.Data;
using WAD.CW1._00013292.Models;

namespace WAD.CW1._00013292.Repositories
{
    public class KeyItemRepository : IKeyItemRepository
    {
        private readonly ApplicationDbContext _context;

        public KeyItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KeyItem>> GetAllAsync()
        {
            return await _context.KeyItems.Include(k => k.KeyType).ToListAsync();
        }

        public async Task<KeyItem> GetByIdAsync(int keyItemId)
        {
            return await _context.KeyItems
                .Include(k => k.KeyType)
                .FirstOrDefaultAsync(k => k.KeyItemId == keyItemId);
        }

        public async Task<KeyItem> AddAsync(KeyItem keyItem)
        {
            _context.KeyItems.Add(keyItem);
            await _context.SaveChangesAsync();
            return keyItem;
        }

        public async Task<KeyItem> UpdateAsync(KeyItem keyItem)
        {
            _context.KeyItems.Update(keyItem);
            await _context.SaveChangesAsync();
            return keyItem;
        }

        public async Task DeleteAsync(int keyItemId)
        {
            var keyItem = await GetByIdAsync(keyItemId);
            if (keyItem != null)
            {
                _context.KeyItems.Remove(keyItem);
                await _context.SaveChangesAsync();
            }
        }
    }

}
