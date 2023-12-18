using UserAssociates.Business.Dtos.ChargeFieldDto;
using UserAssociates.Business.Viewmodels;
using UserAssociates.Database.Models;
using UserAssociates.Database.Services.ChargeFieldService;

namespace UserAssociates.Business.Logic.ChargeFieldBusinessLogic;

public class ChargeFieldBusinessLogic : IChargeFieldBusinessLogic
{
    private readonly IChargeFieldService _chargeFieldService;

    public ChargeFieldBusinessLogic(IChargeFieldService chargeFieldService)
    {
        _chargeFieldService = chargeFieldService;
    }

    public async Task<ChargeFieldViewModel> Create(CreateChargeFieldDto dto)
    {
        try
        {

            ChargeField entity = new()
            {
                FieldCode = dto.FieldCode,
                ChargeFieldName = dto.ChargeFieldName,
                FieldType = dto.FieldType,
                ChargeType = dto.ChargeType,
                Position = dto.Position,
                Percentage = dto.Percentage.ToString(),
                RoundOff = dto.RoundOff,
                IsReadOnly = dto.IsReadOnly,
                Description = dto.Description

            };

            ChargeField chargeField = await _chargeFieldService.Add(entity);

            ChargeFieldViewModel viewModel = new()
            {
                ID = chargeField.KeyID,
                FieldCode = chargeField.FieldCode,
                ChargeFieldName = chargeField.ChargeFieldName,
                FieldType = chargeField.FieldType,
                ChargeType = chargeField.ChargeType,
                Position = chargeField.Position,
                Percentage = chargeField.Percentage,
                RoundOff = chargeField.RoundOff,
                IsReadOnly = chargeField.IsReadOnly,
                Description = chargeField.Description
            };

            return viewModel;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<ChargeFieldViewModel>?> GetAll()
    {
        try
        {
            List<ChargeFieldViewModel> viewModelsList = new();
            List<ChargeField> chargeFields = await _chargeFieldService.Get();
            foreach (var chargeField in chargeFields)
            {
                ChargeFieldViewModel viewModel = new()
                {
                    ID = chargeField.KeyID,
                    FieldCode = chargeField.FieldCode,
                    ChargeFieldName = chargeField.ChargeFieldName,
                    FieldType = chargeField.FieldType,
                    ChargeType = chargeField.ChargeType,
                    Position = chargeField.Position,
                    Percentage = chargeField.Percentage,
                    RoundOff = chargeField.RoundOff,
                    IsReadOnly = chargeField.IsReadOnly,
                    Description = chargeField.Description
                };
                viewModelsList.Add(viewModel);
            }
            return viewModelsList;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<ChargeFieldViewModel?> GetById(int Id)
    {
        try
        {
            ChargeField? chargeField = await _chargeFieldService.Get(Id);
            if (chargeField == null)
                return null;
            ChargeFieldViewModel viewModel = new()
            {
                ID = chargeField.KeyID,
                FieldCode = chargeField.FieldCode,
                ChargeFieldName = chargeField.ChargeFieldName,
                FieldType = chargeField.FieldType,
                ChargeType = chargeField.ChargeType,
                Position = chargeField.Position,
                Percentage = chargeField.Percentage,
                RoundOff = chargeField.RoundOff,
                IsReadOnly = chargeField.IsReadOnly,
                Description = chargeField.Description
            };
            return viewModel;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<ChargeFieldViewModel>?> Delete(int Id)
    {
        try
        {
            ChargeField? checkChargeField = await _chargeFieldService.Get(Id);
            if (checkChargeField is null)
                return null;

            _ = await _chargeFieldService.Delete(checkChargeField);

            return await GetAll();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<ChargeFieldViewModel>?> Update(UpdateChargeFieldDto chargeField)
    {
        try
        {
            ChargeField? checkChargeField = await _chargeFieldService.Get(chargeField.Id);
            if (checkChargeField is null)
                return null;

            checkChargeField.KeyID = chargeField.Id;
            checkChargeField.FieldCode = chargeField.FieldCode;
            checkChargeField.ChargeFieldName = chargeField.ChargeFieldName;
            checkChargeField.FieldType = chargeField.FieldType;
            checkChargeField.ChargeType = chargeField.ChargeType;
            checkChargeField.Position = chargeField.Position;
            checkChargeField.Percentage = chargeField.Percentage.ToString();
            checkChargeField.RoundOff = chargeField.RoundOff;
            checkChargeField.IsReadOnly = chargeField.IsReadOnly;
            checkChargeField.Description = chargeField.Description;

            _ = await _chargeFieldService.Update(checkChargeField);

            return await GetAll();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
