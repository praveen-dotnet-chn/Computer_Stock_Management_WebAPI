using Computer_Stock_Management_WebAPI.Models;

namespace Computer_Stock_Management_WebAPI.Services
{
    public interface IPeripheralService
    {
        Task<IEnumerable<Peripheral>> GetAllAsync();
        Task<Peripheral> GetByIdAsync(int id);
        Task<Peripheral> CreateAsync(Peripheral peripheral);
        Task<bool> UpdateAsync(int id, Peripheral peripheral);
        Task<bool> DeleteAsync(int id);
    }
}
