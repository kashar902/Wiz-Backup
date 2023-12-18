using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.VisitTypeService
{
    public class VisitTypeService : IVisitTypeService
    {
        private readonly UserAndAssociatesdbcontext _dbContext;
        public VisitTypeService(UserAndAssociatesdbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<VisitType> AddVisitType(VisitType visitType)
        {
            EntityEntry<VisitType> entityEntry = await _dbContext.AddAsync(visitType);
            _ = await _dbContext.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<int> DeleteVisitType(VisitType visitType)
        {
            _ = _dbContext.VisitTypes.Remove(visitType);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<VisitType>> GetAllVisitTypes()
        {
            return await _dbContext.VisitTypes.ToListAsync();
        }

        public async Task<VisitType?> GetVisitType(int Id)
        {
            return await _dbContext.VisitTypes.FirstOrDefaultAsync(x => x.ID == Id);
        }

        public async Task<int> UpdateVisitType(VisitType visitType)
        {
            _dbContext.Entry(visitType).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
    }
}
