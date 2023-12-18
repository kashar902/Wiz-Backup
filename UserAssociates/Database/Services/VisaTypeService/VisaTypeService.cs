using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.VisaTypeService
{
    public class VisaTypeService : IVisaTypeService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;
        public VisaTypeService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<VisaType> AddVisaType(VisaType visaType)
        {
            EntityEntry<VisaType> entityEntry = await _dbContext.AddAsync(visaType);
            _ = await _dbContext.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<int> DeleteVisaType(VisaType visaType)
        {
            _ = _dbContext.VisaTypes.Remove(visaType);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<VisaType>> GetAllVisaTypes()
        {
            return await _dbContext.VisaTypes.ToListAsync();
        }

        public async Task<VisaType?> GetVisaType(int Id)
        {
            return await _dbContext.VisaTypes.FirstOrDefaultAsync(x => x.ID == Id);
        }

        public async Task<int> UpdateVisaType(VisaType visaType)
        {
            _dbContext.Entry(visaType).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }

    }
}
