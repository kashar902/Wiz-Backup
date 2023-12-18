using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.ChargeFieldService;

public class ChargeFieldService : IChargeFieldService
{
    private readonly UserAndAssociatesdbcontext _dbContext;

    public ChargeFieldService(UserAndAssociatesdbcontext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ChargeField>> Get() =>
        await _dbContext.ChargeFields.ToListAsync();

    public async Task<ChargeField?> Get(int id)
    {
        ChargeField? chargeField = await _dbContext.ChargeFields.FirstOrDefaultAsync(x => x.KeyID == id);
        if (chargeField is null)
            return null;
        return chargeField;
    }

    public async Task<int> Delete(ChargeField entity)
    {
        _ = _dbContext.ChargeFields.Remove(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<ChargeField> Add(ChargeField entity)
    {
        EntityEntry<ChargeField> entityEntry = await _dbContext.ChargeFields.AddAsync(entity);
        _ = await _dbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<int> Update(ChargeField chargeField)
    {
        _dbContext.Entry(chargeField).State = EntityState.Modified;
        return await _dbContext.SaveChangesAsync();
    }
}
