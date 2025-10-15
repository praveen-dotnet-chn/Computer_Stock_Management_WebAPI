using Computer_Stock_Management_WebAPI.Models;
using Computer_Stock_Management_WebAPI.Repository;

namespace Computer_Stock_Management_WebAPI.Services
{
    public class PeripheralService : IPeripheralService
    {
        private readonly IRepository<Peripheral> _repository;

        public PeripheralService(IRepository<Peripheral> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Peripheral>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Peripheral> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Peripheral> CreateAsync(Peripheral peripheral)
        {
            await _repository.AddAsync(peripheral);
            await _repository.SaveAsync();
            return peripheral;
        }

        public async Task<bool> UpdateAsync(int id, Peripheral peripheral)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return false;

            existing.Name = peripheral.Name;
            existing.Category = peripheral.Category;
            existing.QuantityInStock = peripheral.QuantityInStock;
            existing.Price = peripheral.Price;
            existing.AddedDate = peripheral.AddedDate;

            await _repository.UpdateAsync(existing);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
            return true;
        }
    }
}
