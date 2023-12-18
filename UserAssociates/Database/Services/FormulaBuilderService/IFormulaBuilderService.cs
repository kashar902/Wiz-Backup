using UserAssociates.Database.Models;

namespace UserAssociates.Database.Services.FormulaBuilderService;

public interface IFormulaBuilderService
{
    Task<List<FormulaBuilder>> Get();
    Task<FormulaBuilder?> Get(int id);
    Task<int> Delete(FormulaBuilder entity);
    Task<FormulaBuilder> Add(FormulaBuilder entity);
    Task<int> Update(FormulaBuilder formulaBuilder);
}
