using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserAssociates.Database.DBContext;
using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.FormulaBuilderService;

public class FormulaBuilderService : IFormulaBuilderService
{
    private readonly UserAndAssociatesdbcontext _dbContext;

    public FormulaBuilderService(UserAndAssociatesdbcontext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<FormulaBuilder>> Get() =>
        await _dbContext.FormulaBuilders.ToListAsync();

    public async Task<FormulaBuilder?> Get(int id)
    {
        var formulaBuilder = await _dbContext.FormulaBuilders.FirstOrDefaultAsync(x => x.KeyID == id);
        if (formulaBuilder is null)
            return null;
        return formulaBuilder;
    }

    public async Task<int> Delete(FormulaBuilder entity)
    {
        _ = _dbContext.FormulaBuilders.Remove(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<FormulaBuilder> Add(FormulaBuilder entity)
    {
        EntityEntry<FormulaBuilder> entityEntry = await _dbContext.FormulaBuilders.AddAsync(entity);
        _ = await _dbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<int> Update(FormulaBuilder formulaBuilder)
    {
        _dbContext.Entry(formulaBuilder).State = EntityState.Modified;
        return await _dbContext.SaveChangesAsync();
    }
}
