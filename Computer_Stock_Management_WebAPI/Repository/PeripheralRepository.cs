using Computer_Stock_Management_WebAPI.Data;
using Computer_Stock_Management_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Computer_Stock_Management_WebAPI.Repository
{
    public class PeripheralRepository : IRepository<Peripheral>
    {
        private readonly AppDbContext _context;

        public PeripheralRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Peripheral>> GetAllAsync()
        {
            return await _context.Peripherals.AsNoTracking().ToListAsync();
        }

        public async Task<Peripheral> GetByIdAsync(int id)
        {
            return await _context.Peripherals.FindAsync(id);
        }

        public async Task AddAsync(Peripheral entity)
        {
            await _context.Peripherals.AddAsync(entity);
        }

        public async Task UpdateAsync(Peripheral entity)
        {
            _context.Peripherals.Update(entity);
            await Task.CompletedTask; // just to match async signature
        }

        public async Task DeleteAsync(int id)
        {
            var peripheral = await GetByIdAsync(id);
            if (peripheral != null)
                _context.Peripherals.Remove(peripheral);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
