using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.VoucherTypeService
{
    public class VoucherTypeService : IVoucherTypeService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;
        public VoucherTypeService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<VoucherType> AddVoucherType(VoucherType voucherType)
        {
            EntityEntry<VoucherType> entityEntry = await _dbContext.AddAsync(voucherType);
            _ = await _dbContext.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<int> DeleteVoucherType(VoucherType voucherType)
        {
            _ = _dbContext.VoucherTypes.Remove(voucherType);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<VoucherType>> GetAllVoucherTypes()
        {
            return await _dbContext.VoucherTypes.ToListAsync();
        }
        public async Task<VoucherType?> GetVoucherType(int Id)
        {
            return await _dbContext.VoucherTypes.FirstOrDefaultAsync(x => x.ID == Id);
        }

        public async Task<int> UpdateVoucherType(VoucherType voucherType)
        {
            _dbContext.Entry(voucherType).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }

    }
}
