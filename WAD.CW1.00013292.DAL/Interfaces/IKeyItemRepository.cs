using WAD.CW1._00013292.Models;

namespace WAD.CW1._00013292.DAL.Interfaces
{
    public interface IKeyItemRepository
    {
        Task<IEnumerable<KeyItem>> GetAllAsync();
        Task<KeyItem> GetByIdAsync(int keyItemId);
        Task<KeyItem> AddAsync(KeyItem keyItem);
        Task<KeyItem> UpdateAsync(KeyItem keyItem);
        Task DeleteAsync(int keyItemId);
    }
}
