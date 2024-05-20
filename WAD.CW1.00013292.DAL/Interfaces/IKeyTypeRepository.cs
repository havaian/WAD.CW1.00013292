using WAD.CW1._00013292.Models;

namespace WAD.CW1._00013292.DAL.Interfaces
{
    public interface IKeyTypeRepository
    {
        Task<IEnumerable<KeyType>> GetAllAsync();
        Task<KeyType> GetByIdAsync(int keyTypeId);
        Task<KeyType> AddAsync(KeyType keyType);
        Task<KeyType> UpdateAsync(KeyType keyType);
        Task DeleteAsync(int keyTypeId);
    }
}
