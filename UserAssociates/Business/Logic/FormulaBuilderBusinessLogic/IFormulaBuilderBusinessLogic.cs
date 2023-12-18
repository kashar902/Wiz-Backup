using UserAssociates.Business.Dtos.FormulaBuilder;
using UserAssociates.Business.Viewmodels;

namespace UserAssociates.Business.Logic.FormulaBuilderBusinessLogic;

public interface IFormulaBuilderBusinessLogic
{
    Task<FormulaBuilderViewModel> Create(CreateFormulaBuilderDto dto);
    Task<List<FormulaBuilderViewModel>> GetAll();
    Task<FormulaBuilderViewModel?> GetById(int id);
    Task<List<FormulaBuilderViewModel>?> Delete(int id);
    Task<List<FormulaBuilderViewModel>?> Update(UpdateFormulaBuilderDto dto);
}
