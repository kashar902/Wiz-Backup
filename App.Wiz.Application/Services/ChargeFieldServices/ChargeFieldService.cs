using App.Wiz.Application.Profiles.ChargeFieldProfile;
using App.Wiz.Common.GenericServiceResponse;
using App.Wiz.Common.ServiceViewModels.ChargeFieldViewModels;
using App.Wiz.Common.ServiceViewModels.DropdownViews;
using App.Wiz.Common.ServiceViewModels.FormulaBuilderResponse;
using App.Wiz.Domain.Repositories.ChargeFieldRepository;
using App.Wiz.Domain.Repositories.ChargeTypeRepository;
using App.Wiz.Domain.Repositories.FieldTypeRepository;
using App.Wiz.Domain.Repositories.FormulaBuilderRepository;
using App.Wiz.Domain.Repositories.FormulaChargeFieldRepository;
using App.Wiz.Domain.ServiceDtos.ChargeFieldDto;
using App.Wiz.Infrastructure.Entities;
using static App.Wiz.Common.Messages.Constants;

namespace App.Wiz.Application.Services.ChargeFieldServices;

public class ChargeFieldService : IChargeFieldService
{
    private readonly IChargeFieldRepository _repository;
    private readonly IChargeTypeRepository _chargeTypeRepository;
    private readonly IFieldTypeRepository _fieldTypeRepository;
    private readonly IFormulaChargeFieldRepository _formulaChargeFieldRepository;
    private readonly IFormulaBuilderRepository _formulaBuilderRepository;

    public ChargeFieldService(IChargeFieldRepository repository,
        IChargeTypeRepository chargeTypeRepository,
        IFieldTypeRepository fieldTypeRepository,
        IFormulaChargeFieldRepository formulaChargeFieldRepository,
        IFormulaBuilderRepository formulaBuilderRepository
        )
    {
        _repository = repository;
        _chargeTypeRepository = chargeTypeRepository;
        _fieldTypeRepository = fieldTypeRepository;
        _formulaChargeFieldRepository = formulaChargeFieldRepository;
        _formulaBuilderRepository = formulaBuilderRepository;
    }

    public async Task<ServiceResponse> Get()
    {
        IList<ChargeField> ChargeFields = await _repository.GetAllAsync(x => x.ChargeType!, x => x.FieldType!);
        List<ChargeFieldViewModel> viewModels = new();
        foreach (ChargeField item in ChargeFields)
        {
            ChargeFieldViewModel viewModel = ChargeFieldProfile.PrepareToViewModel(item);
            viewModels.Add(viewModel);
        }
        return ServiceResponse.Success(LoadDataSuccess, viewModels);
    }
    public async Task<ServiceResponse> Get(int id)
    {
        ChargeField? ChargeFields = await _repository.GetAsync(id);
        if (ChargeFields is null)
        {
            return ServiceResponse.Failure(NotFound);
        }
        ChargeFieldViewModel viewModels = ChargeFieldProfile.PrepareToViewModel(ChargeFields);
        return ServiceResponse.Success(LoadDataSuccess, viewModels);
    }
    public async Task<ServiceResponse> Delete(int id)
    {
        ChargeField? ChargeFields = await _repository.GetAsync(x => x.Id == id);
        if (ChargeFields is null)
        {
            return ServiceResponse.Failure(NotFound);
        }
        await _repository.DeleteAsync(ChargeFields);
        return ServiceResponse.Success(DeleteSuccessful);
    }
    public async Task<ServiceResponse> Add(CreateChargeFieldDto dto)
    {
        ChargeField entity = ChargeFieldProfile.PrepareToEntity(dto);
        _ = await _repository.AddAsync(entity);
        return ServiceResponse.Success(AddSuccessful);
    }
    public async Task<ServiceResponse> Update(UpdateChargeFieldDto dto)
    {
        ChargeField? ChargeFields = await _repository.GetAsync(x => x.Id == dto.Id);
        if (ChargeFields is null)
        {
            return ServiceResponse.Failure(NotFound);
        }
      
        

        IList<FormulaChargeFields> chargeFieldFormulas = await _formulaChargeFieldRepository
          .GetAllAsync(x => x.ChargeFieldId == dto.Id);

        foreach (FormulaChargeFields item in chargeFieldFormulas)
        {
            FormulaBuilder? formulaBuilder = await _formulaBuilderRepository.GetAsync(x => x.Id == item.FormulaId);
            if (formulaBuilder is null)
            {
                continue;
            }
            string newFormula = formulaBuilder.Formula.Replace(ChargeFields.Title, dto.Title);
            formulaBuilder.Formula = newFormula;
            await _formulaBuilderRepository.UpdateAsync(formulaBuilder);
        }
        ChargeField entity = ChargeFieldProfile.PrepareToEntity(dto, ChargeFields);
        await _repository.UpdateAsync(entity);
        return ServiceResponse.Success(UpdateSuccessful);
    }

    public async Task<ServiceResponse> GetChargeFieldFormData()
    {
        ChargeFieldFormModel chargeFieldFormModel = new();
        IList<ChargeType> chargeTypes = await _chargeTypeRepository.GetAllAsync();
        foreach (ChargeType item in chargeTypes)
        {
            chargeFieldFormModel.ChargeType.Add(new Dropdown
            {
                Key = item.Id,
                Value = item.Name
            });
        }
        IList<FieldType> fieldTypes = await _fieldTypeRepository.GetAllAsync();
        foreach (FieldType item in fieldTypes)
        {
            chargeFieldFormModel.FieldType.Add(new Dropdown()
            {
                Key = item.Id,
                Value = item.Name
            });
        }
        return ServiceResponse.Success(LoadDataSuccess, chargeFieldFormModel);
    }

    public async Task<ServiceResponse> GetChargeField()
    {
        ChargeFieldDropDown chargeFieldFormModel = new();
        IList<ChargeField> fieldTypes = await _repository.GetAllAsync();
        foreach (ChargeField item in fieldTypes)
        {
            chargeFieldFormModel.ChargeField.Add(new Dropdown()
            {
                Key = item.Id,
                Value = item.Title
            });
        }
        return ServiceResponse.Success(LoadDataSuccess, chargeFieldFormModel);
    }
}
