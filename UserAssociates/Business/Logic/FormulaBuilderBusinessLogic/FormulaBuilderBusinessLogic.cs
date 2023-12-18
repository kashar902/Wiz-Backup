using UserAssociates.Business.Dtos.FormulaBuilder;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;
using UserAssociates.Database.Services.FormulaBuilderService;

namespace UserAssociates.Business.Logic.FormulaBuilderBusinessLogic;

public class FormulaBuilderBusinessLogic : IFormulaBuilderBusinessLogic
{
    private readonly IFormulaBuilderService _formulaBuilderService;

    public FormulaBuilderBusinessLogic(IFormulaBuilderService formulaBuilderService)
    {
        _formulaBuilderService = formulaBuilderService;
    }

    public async Task<FormulaBuilderViewModel> Create(CreateFormulaBuilderDto dto)
    {
        try
        {
            FormulaBuilder entity = new()
            {
                FormulaCode = dto.FormulaCode,
                FormulaName = dto.FormulaName,
                Category = dto.Category,
                Description = dto.Description,
                Formula = dto.Formula,
                Active = dto.Active
            };
            FormulaBuilder formulaBuilder = await _formulaBuilderService.Add(entity);
            FormulaBuilderViewModel viewModel = new()
            {
                KeyID = formulaBuilder.KeyID,
                FormulaCode = formulaBuilder.FormulaCode,
                FormulaName = formulaBuilder.FormulaName,
                Category = formulaBuilder.Category,
                Description = formulaBuilder.Description,
                Formula = formulaBuilder.Formula,
                Active = formulaBuilder.Active
            };
            return viewModel;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<FormulaBuilderViewModel>> GetAll()
    {
        try
        {
            List<FormulaBuilderViewModel> viewModelList = new();
            List<FormulaBuilder> formulaBuilders = await _formulaBuilderService.Get();
            foreach (var formulaBuilder in formulaBuilders)
            {
                FormulaBuilderViewModel viewModel = new()
                {
                    KeyID = formulaBuilder.KeyID,
                    FormulaCode = formulaBuilder.FormulaCode,
                    FormulaName = formulaBuilder.FormulaName,
                    Category = formulaBuilder.Category,
                    Description = formulaBuilder.Description,
                    Formula = formulaBuilder.Formula,
                    Active = formulaBuilder.Active
                };
                viewModelList.Add(viewModel);
            }
            return viewModelList;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<FormulaBuilderViewModel?> GetById(int Id)
    {
        try
        {
            FormulaBuilder? formulaBuilder = await _formulaBuilderService.Get(Id);
            if (formulaBuilder is null) return null;
            FormulaBuilderViewModel viewModel = new()
            {
                KeyID = formulaBuilder.KeyID,
                FormulaCode = formulaBuilder.FormulaCode,
                FormulaName = formulaBuilder.FormulaName,
                Category = formulaBuilder.Category,
                Description = formulaBuilder.Description,
                Formula = formulaBuilder.Formula,
                Active = formulaBuilder.Active
            };
            return viewModel;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<FormulaBuilderViewModel>?> Delete(int Id)
    {
        try
        {
            FormulaBuilder? formulaBuilder = await _formulaBuilderService.Get(Id);
            if (formulaBuilder is null) return null;

            _ = await _formulaBuilderService.Delete(formulaBuilder);

            return await GetAll();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<FormulaBuilderViewModel>?> Update(UpdateFormulaBuilderDto dto)
    {
        try
        {
            FormulaBuilder? formulaBuilder = await _formulaBuilderService.Get(dto.KeyID);
            if (formulaBuilder is null)
                return null;

            formulaBuilder.KeyID = dto.KeyID;
            formulaBuilder.FormulaCode = dto.FormulaCode;
            formulaBuilder.FormulaName = dto.FormulaName;
            formulaBuilder.Category = dto.Category;
            formulaBuilder.Description = dto.Description;
            formulaBuilder.Formula = dto.Formula;
            formulaBuilder.Active = dto.Active;

            _ = await _formulaBuilderService.Update(formulaBuilder);

            return await GetAll();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
